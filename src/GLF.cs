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

        public void EnableOauthProvider<T>(params string[] args) where T : GenericLoginFramework.OAuth.Providers.OAuthProvider
        {
            Type providerType = typeof(T);

            OAuth.Providers.OAuthProvider provider = (OAuth.Providers.OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            provider.SetKeys(args);
        }

        public void EnableOpenIDProvider()
        {
        }
    }
}
