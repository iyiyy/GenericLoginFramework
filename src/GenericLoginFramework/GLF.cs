using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		#region Properties
		public bool DBInitialized { get; private set; }
        #endregion Properties

        #region Methods
        public User LoginWithGeneric(string username, string password)
        {
            throw new NotImplementedException();
        }

		public User LoginWithFacebook()
		{
			throw new NotImplementedException();
		}

		public User LoginWithGoogle()
		{
			throw new NotImplementedException();
		}

		public User LoginWithCustomProvider<T>()
		{
			throw new NotImplementedException();
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
		#endregion
	}
}
