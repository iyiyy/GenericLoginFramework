using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GenericLoginFramework.Providers;
using System.Windows;

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
            throw new NotImplementedException();
        }

		public async Task<User> LoginWithFacebook(ProjectType type)
		{
            User ret = null;
            string response = "";
            Window window;

            switch (type)
            {
                case ProjectType.WPF:
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = new Views.GLFRedirectWPF()
                    };
                    window.ShowDialog();
                    break;
                case ProjectType.WF:
                    window = new Window
                    {
                        Title = "Facebook Login",
                        Content = new Views.GLFRedirectWPF()
                    };
                    window.ShowDialog();
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }

            if (FacebookProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode || FacebookProvider.Instance.UsedFlow == ProviderFlow.Implicit)
            {
                if (FacebookProvider.Instance.UsedFlow == ProviderFlow.AuthorizationCode)
                {
                    response = await FacebookProvider.Instance.GetTokenFromGrant(response);
                }

                Resource resource = await FacebookProvider.Instance.GetResourceFromToken(response);
                ret = FacebookProvider.Instance.GetUserFromResource(resource);
            }
            else
                throw new NotImplementedException();

            return ret;
        }

		public async Task<User> LoginWithGoogle(ProjectType type)
        {
            User ret = null;
            string response = "";

            switch (type)
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

		public User LoginWithCustomProvider<T>(ProjectType type) where T : OAuthProvider
		{
            switch (type)
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
            return null;
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

        public static byte[] Hash(string value, string salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(salt));
        }

        public static byte[] Hash(byte[] value, string salt)
        {
            return Hash(value, Encoding.UTF8.GetBytes(salt));
        }

        public static byte[] Hash(string value, byte[] salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), salt);
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            return new SHA256Managed().ComputeHash(value.Concat(salt).ToArray());
        }
        #endregion
    }
}
