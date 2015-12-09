using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericLoginFramework.Providers
{
	public abstract class OAuthProvider
	{
		#region Properties
		public bool Enabled { get; private set; }
		public string AppID { get; set; }
		public string AppSecret { get; set; }
		public abstract string Scope { get; set; }
		public string State { get; set; }
		public GLF.ProviderFlow UsedFlow { get; set; } = GLF.ProviderFlow.AuthorizationCode;
        public abstract string RedirectURI { get; set; }
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
        public abstract Task<string> GetTokenFromGrant(string grant);
        public abstract Task<Resource> GetResourceFromToken(string token);
        protected abstract Resource ConvertJSONToResource(string JSONString);

        public virtual User GetUserFromResource(Resource resource)
        {
            CheckIfEnabled();

            User user = null;
            using (GLFDbContext db = new GLFDbContext(GLF.Instance.DBName, GLF.Instance.DBIsConnName))
            {
                Resource res = db.Resources.Where(r => r.ID == resource.ID).Include(r => r.User).FirstOrDefault();

                if(res != null)
                    user = res.User;

                if (user != null)
                {
                        db.Entry(res).CurrentValues.SetValues(resource);
                }
                else
                {
                    user = new User();
                    resource.User = user;
                    user.Resources.Add(resource);
                    db.Users.Add(user);
                }

                db.SaveChanges();
            }

            return user;
        }

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

        public virtual string FullyQualifiedLoginEndpoint()
        {
            return String.Format("{0}?client_id={1}&response_type={2}&redirect_uri={3}", LoginEndpoint, AppID, ResponseType, RedirectURI);
        }

        public virtual void CheckIfEnabled()
        {
            if (!Enabled)
                throw new Exception(String.Format("{0} has not been enabled yet. Please enable if before calling this method.", this.GetType().Name));
        }
		#endregion
	}
}
