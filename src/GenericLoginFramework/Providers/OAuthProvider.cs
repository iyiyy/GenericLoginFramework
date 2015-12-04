using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.Providers
{
	public abstract class OAuthProvider
	{
		#region Properties
		public bool Enabled { get; private set; }
		public string AppID { get; set; }
		public string AppSecret { get; set; }
		public string Scope { get; set; }
		public string State { get; set; }
		public GLF.ProviderFlow UsedFlow { get; set; } = GLF.ProviderFlow.AuthorizationCode;
		public abstract string LoginEndpoint { get; set; }
		public abstract string ResourceEndpoint { get; set; }

		public string ResponseType
		{
			get
			{
				return GLF.FlowToResponseType(this.UsedFlow);
			}
		}
		#endregion

		#region Methods
		public virtual void Enable(string appID)
		{
			this.AppID = appID;
			this.UsedFlow = GLF.ProviderFlow.Implicit;
			this.Enabled = true;
		}

		public virtual void Enable(string appID, string appSecret)
		{
			this.AppID = appID;
			this.AppSecret = appSecret;
			this.UsedFlow = GLF.ProviderFlow.AuthorizationCode;
			this.Enabled = true;
		}

		public abstract string GetTokenFromGrant(string grant);
		public abstract Resource GetResourceFromToken(string token);
		public abstract User GetUserFromResource(Resource resource);
        public virtual string FullyQualifiedLoginEndpoint()
        {
            throw new NotImplementedException();
        }
        protected abstract Resource ConvertJSONToResource(string JSON);
		#endregion
	}
}
