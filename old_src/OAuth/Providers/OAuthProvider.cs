using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OAuth.Providers
{
    abstract class OAuthProvider
    {
        public enum Provider
        {
            FacebookProvider
        }

        public enum OAuthProperty
        {
            AppID,
            AppSecret,
            DialogURI,
            RedirectURI,
            DefaultRedirectURI
        }

        public enum Flow
        {
            AuthorizationCode,
            Implicit,
            ResourceOwnerPasswordCredentials,
            ClientCredentials
        }

        public abstract void SetKeys(string[] keys);
        public abstract GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow UsedFlow { get; set; }
        public abstract Task<GenericLoginFramework.OAuth.Resources.OAuthResource> GetResourceFromToken(string token);
    }
}
