using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.Providers
{
	public abstract class OpenIDProvider : OAuthProvider
    {
        public override string FullyQualifiedLoginEndpoint()
        {
            return String.Format("{0}?client_id={1}&response_type={2}&redirect_uri={3}&scope={4}", LoginEndpoint, AppID, ResponseType, RedirectURI, Scope);
        }
    }
}
