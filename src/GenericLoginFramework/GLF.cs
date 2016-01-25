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

        public string GetFacebookToken()
        {
            if (!FacebookProvider.Instance.Enabled)
                throw new Exception("Facebook provider is not enable.");

            string response = "";
            Window window;

            switch (TypeOfProject)
            {
                case ProjectType.WPF:
                    Views.GLFRedirectWPF contentWPF = new Views.GLFRedirectWPF(FacebookProvider.Instance.FullyQualifiedLoginEndpoint(), FacebookProvider.Instance.RedirectURI, FacebookProvider.Instance.UsedFlow);
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWPF
                    };
                    window.ShowDialog();
                    response = contentWPF.Response;
                    break;
                case ProjectType.WF:
                    Views.GLFRedirectWF contentWF = new Views.GLFRedirectWF(FacebookProvider.Instance.FullyQualifiedLoginEndpoint(), FacebookProvider.Instance.RedirectURI, FacebookProvider.Instance.UsedFlow);
                    contentWF.Dock = System.Windows.Forms.DockStyle.Fill;
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = contentWF
                    };
                    contentWF.ParentWindow = window;
                    window.ShowDialog();
                    response = contentWF.Response;
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }

            return response;
        }

        public async Task<User> GetUserFromFacebookToken(string token)
        {
            User user = null;

            if (FacebookProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode)
            {
                token = await FacebookProvider.Instance.GetTokenFromGrant(token);
                Resource resource = await FacebookProvider.Instance.GetResourceFromToken(token);
                user = FacebookProvider.Instance.GetUserFromResource(resource);
            }
            else if (FacebookProvider.Instance.UsedFlow == ProviderFlow.Implicit)
            {
                Resource resource = await FacebookProvider.Instance.GetResourceFromToken(token);
                user = FacebookProvider.Instance.GetUserFromResource(resource);
            }
            else
                throw new NotImplementedException(String.Format("Flow {0} not support.", FacebookProvider.Instance.UsedFlow.ToString()));

            return user;
        }

        public string GetGoogleToken()
        {
            if (!GoogleProvider.Instance.Enabled)
                throw new Exception("Google provider is not enable.");

            string response = "";
            Window window;

            switch (TypeOfProject)
            {
                case ProjectType.WPF:
                    Views.GLFRedirectWPF contentWPF = new Views.GLFRedirectWPF(GoogleProvider.Instance.FullyQualifiedLoginEndpoint(), GoogleProvider.Instance.RedirectURI, GoogleProvider.Instance.UsedFlow);
                    window = new Window
                    {
                        Title = "Google Login",
                        Content = contentWPF
                    };
                    window.ShowDialog();
                    response = contentWPF.Response;
                    break;
                case ProjectType.WF:
                    Console.WriteLine(GoogleProvider.Instance.FullyQualifiedLoginEndpoint());
                    Views.GLFRedirectWF contentWF = new Views.GLFRedirectWF(GoogleProvider.Instance.FullyQualifiedLoginEndpoint(), GoogleProvider.Instance.RedirectURI, GoogleProvider.Instance.UsedFlow);
                    contentWF.Dock = System.Windows.Forms.DockStyle.Fill;
                    window = new Window
                    {
                        Title = "Google Login",
                        Content = contentWF
                    };
                    contentWF.ParentWindow = window;
                    window.ShowDialog();
                    response = contentWF.Response;
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }

            return response;
        }

        public async Task<User> GetUserFromGoogleToken(string token)
        {
            User user = null;

            if (GoogleProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode)
            {
                token = await GoogleProvider.Instance.GetTokenFromGrant(token);
                Resource resource = await GoogleProvider.Instance.GetResourceFromToken(token);
                user = GoogleProvider.Instance.GetUserFromResource(resource);
            }
            else if (GoogleProvider.Instance.UsedFlow == ProviderFlow.Implicit)
            {
                Resource resource = await GoogleProvider.Instance.GetResourceFromToken(token);
                user = GoogleProvider.Instance.GetUserFromResource(resource);
            }
            else
                throw new NotImplementedException(String.Format("Flow {0} not support.", GoogleProvider.Instance.UsedFlow.ToString()));

            return user;
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

        public void AddUserToContext(User user)
        {
            if (user != null)
            {
                using (GLFDbContext db = new GLFDbContext(DBName, DBIsConnName))
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }

        public void AddResourceToExistingUser(User user, Resource resource)
        {
            if (user != null && resource != null)
            {
                using (GLFDbContext db = new GLFDbContext(DBName, DBIsConnName))
                {
                    User dbUser = db.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                    resource.User = dbUser;
                    db.Resources.Add(resource);
                    db.SaveChanges();
                }
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
            if(user == null)
                return "Empty user.";
            string ret = "";

            ret += String.Format("ID: {0}\r\nVerified: {1}\r\nUsername: {2}\r\nPassword: {3}", user.ID.ToString(), user.Verified, user.Username, (user.Password != null ? BitConverter.ToString(user.Password) : ""));

            foreach (var resource in user.Resources)
            {
                ret += "\r\n-----Resource-----\r\n";
                ret += String.Format("ID: {0}\r\nName: {1}\r\nLastname: {2}\r\nAge: {3}\r\nEmail: {4}\r\nType: {5}\r\n", resource.ID, resource.Name, resource.LastName, resource.Age, resource.Email, resource.Type);
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
