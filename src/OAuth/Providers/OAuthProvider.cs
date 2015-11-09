using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OAuth.Providers
{
    abstract class OAuthProvider
    {
        public enum Flow
        {
            AuthorizationCode,
            Implicit,
            ResourceOwnerPasswordCredentials,
            ClientCredentials
        }

        public abstract void SetKeys(string[] keys);
    }
}
