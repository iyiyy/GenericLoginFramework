using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GenericLoginFramework.Providers;
using System.Windows;
using System.Data.Entity;

namespace GenericLoginFramework
{
    public class GLF
    {
		#region Enums
		public enum ProjectType
		{
			WPF,
			WF,
			ASP
		}

		public enum ProviderFlow
		{
			AuthorizationCode,
			Implicit,
			ResourceOwnerPasswordCredentials,
			ClientCredentials
		}
        #endregion

        private static GLF _instance;

		#region Properties
		public bool DBInitialized { get; private set; }
        public string DBName { get; set; } = "GenericLoginFramework";
        public bool DBIsConnName { get; set; } = false;
        public ProjectType TypeOfProject { get; set; }

        public static GLF Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GLF();

                return _instance;
            }
        }
        #endregion Properties

        #region Methods
        private GLF()
        {

        }

        public User LoginWithGeneric(string username, string password)
        {
            using (GLFDbContext db = new GLFDbContext(DBName, DBIsConnName))
            {
                User user = db.Users.Where(u => u.Username == username).Include(u => u.Resources).FirstOrDefault();
                if (user != null && (BitConverter.ToString(user.Password) == BitConverter.ToString(Hash(password, user.ID.ToByteArray()))))
                    return user;
            }
            return null;
        }

		public async Task<User> LoginWithFacebook()
		{
            User ret = null;
            string response = "";
            Window window;

            switch (TypeOfProject)
            {
                case ProjectType.WPF:
                    Views.GLFRedirectWPF contentWPF = new Views.GLFRedirectWPF(FacebookProvider.Instance.FullyQualifiedLoginEndpoint(), FacebookProvider.Instance.UsedFlow);
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWPF
                    };
                    window.ShowDialog();
                    response = contentWPF.Response;
                    Console.WriteLine(response);
                    break;
                case ProjectType.WF:
                    Views.GLFRedirectWF contentWF = new Views.GLFRedirectWF();
                    contentWF.Dock = System.Windows.Forms.DockStyle.Top;
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWF
                    };
                    window.ShowDialog();
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }

            if (FacebookProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode)
            {
                response = await FacebookProvider.Instance.GetTokenFromGrant(response);
                Resource resource = await FacebookProvider.Instance.GetResourceFromToken(response);
                ret = FacebookProvider.Instance.GetUserFromResource(resource);
            }
            else if (FacebookProvider.Instance.UsedFlow == ProviderFlow.Implicit)
            {
                Resource resource = await FacebookProvider.Instance.GetResourceFromToken(response);
                ret = FacebookProvider.Instance.GetUserFromResource(resource);
            }
            else
                throw new NotImplementedException(String.Format("Flow {0} not support.", FacebookProvider.Instance.UsedFlow.ToString()));
            
            return ret;
        }

		public async Task<User> LoginWithGoogle()
        {
            User ret = null;
            string response = "";

            switch (TypeOfProject)
            {
                case ProjectType.WPF:
                    break;
                case ProjectType.WF:
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }

            if (GoogleProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode)
            {
                string token = await GoogleProvider.Instance.GetTokenFromGrant(response);
                Resource resource = await GoogleProvider.Instance.GetResourceFromToken(token);
                ret = GoogleProvider.Instance.GetUserFromResource(resource);
            }
            else if (GoogleProvider.Instance.UsedFlow == ProviderFlow.Implicit)
            {
                Resource resource = await GoogleProvider.Instance.GetResourceFromToken(response);
                ret = GoogleProvider.Instance.GetUserFromResource(resource);
            }
            else
                throw new NotImplementedException();

            return ret;
        }

		public User LoginWithCustomProvider<T>() where T : OAuthProvider
        {
            User ret = null;
            string response = "";
            Window window;

           /* switch (TypeOfProject)
            {
                case ProjectType.WPF:
                    Views.GLFRedirectWPF contentWPF = new Views.GLFRedirectWPF(T.Instance().FullyQualifiedLoginEndpoint(), FacebookProvider.Instance.UsedFlow);
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWPF
                    };
                    window.ShowDialog();
                    response = contentWPF.Response;
                    Console.WriteLine(response);
                    break;
                case ProjectType.WF:
                    Views.GLFRedirectWF contentWF = new Views.GLFRedirectWF();
                    contentWF.Dock = System.Windows.Forms.DockStyle.Top;
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWF
                    };
                    window.ShowDialog();
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }*/
            return ret;
        }

        public void InitializeDB(string name = "GenericLoginFramework", bool isConnName = false)
        {
            if (!DBInitialized)
            {
                DBName = name;
                DBIsConnName = isConnName;

                using (GLFDbContext db = new GLFDbContext(DBName, DBIsConnName))
                {
                    DBInitialized = true;
                }
            }
        }

        public void AddResourceToExistingUser(User user, Resource resource)
        {
            //resource.User = user;
            using (GLFDbContext db = new GLFDbContext(DBName, DBIsConnName))
            {
                User dbUser = db.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                resource.User = dbUser;
                db.Resources.Add(resource);
                db.SaveChanges();
            }
        }

		public static string FlowToResponseType(ProviderFlow flow)
		{
			string result = "";

			switch (flow)
			{
				case ProviderFlow.AuthorizationCode:
					result = "code";
					break;
				case ProviderFlow.Implicit:
					result = "token";
					break;
				case ProviderFlow.ResourceOwnerPasswordCredentials:
					throw new NotImplementedException("ResourceOwnerPasswordCredentials is currently not supported.");
				case ProviderFlow.ClientCredentials:
					throw new NotImplementedException("ClientCredentials is currently not supported.");
				default:
					break;
			}

			return result;
		}

        public static string UserToString(User user)
        {
            string ret = "";

            ret += String.Format("ID: {0}\nVerified: {1}\nUsername: {2}\nPassword: {3}", user.ID.ToString(), user.Verified, user.Username, BitConverter.ToString(user.Password));

            foreach (var resource in user.Resources)
            {
                ret += "\n-----Resource-----\n";
                ret += String.Format("ID: {0}\nName: {1}\nLastname: {2}\nAge: {3}\nEmail: {4}\nType: {5}\n", resource.ID, resource.Name, resource.LastName, resource.Age, resource.Email, resource.Type);
            }
            
            return ret;
        }

        public static byte[] Hash(string value, string salt)
        {
            byte[] valuebytes = new byte[value.Length * sizeof(char)];
            System.Buffer.BlockCopy(value.ToCharArray(), 0, valuebytes, 0, valuebytes.Length);

            byte[] saltbytes = new byte[salt.Length * sizeof(char)];
            System.Buffer.BlockCopy(salt.ToCharArray(), 0, saltbytes, 0, saltbytes.Length);

            return Hash(valuebytes, saltbytes);
        }

        public static byte[] Hash(byte[] value, string salt)
        {
            byte[] saltbytes = new byte[salt.Length * sizeof(char)];
            System.Buffer.BlockCopy(salt.ToCharArray(), 0, saltbytes, 0, saltbytes.Length);

            return Hash(value, saltbytes);
        }

        public static byte[] Hash(string value, byte[] salt)
        {
            byte[] valuebytes = new byte[value.Length * sizeof(char)];
            System.Buffer.BlockCopy(value.ToCharArray(), 0, valuebytes, 0, valuebytes.Length);

            return Hash(valuebytes, salt);
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            return new SHA256Managed().ComputeHash(value.Concat(salt).ToArray());
        }
        #endregion
    }
}
