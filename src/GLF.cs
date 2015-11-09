using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework
{
    class GLF
    {
        public GLF()
        {
        }

        public void EnableOauthProvider<T>(params string[] args)
        {
            Type providerType = typeof(T);

            if (!providerType.IsSubclassOf(typeof(OAuth.Providers.OAuthProvider)))
                throw new Exception("Generic type T must be of subclass of OAuthProvider");

            OAuth.Providers.OAuthProvider provider = (OAuth.Providers.OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            provider.SetKeys(args);
        }

        public void EnableOpenIDProvider()
        {
           EnableOauthProvider<OAuth.Providers.FacebookProvider>();
        }
    }
}
