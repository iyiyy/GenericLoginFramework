using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework
{
    public class GLF
    {
        public GLF()
        {
            DbIsInitialized = false;
        }

        public enum OAuthProvider
        {
            FacebookProvider
        }

        public enum OpenIDProvider
        {
            GoogleProvider
        }

        public enum OAuthProperty
        {
            AppID,
            AppSecret,
            DialogURI,
            RedirectURI,
            DefaultRedirectURI
        }

        public enum OpenIDProperty
        {
            RedirectURI
        }

        private bool DbIsInitialized { get; set; }

        public void InitializeGLFDb(string name, bool isConnName)
        {
            if (!DbIsInitialized)
                using (GenericLoginFramework.Database.GLFDbContext db = new GenericLoginFramework.Database.GLFDbContext(name, isConnName)) { };

            DbIsInitialized = true;
        }

        public void EnableOauthProvider(GenericLoginFramework.GLF.OAuthProvider pro, params string[] args)
        {
            Type providerType = Type.GetType(String.Format("GenericLoginFramework.OAuth.Providers.{0}", pro.ToString()));

            OAuth.Providers.OAuthProvider provider = (OAuth.Providers.OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            provider.SetKeys(args);

            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOAuthProviderProperty(GenericLoginFramework.GLF.OAuthProvider pro, GenericLoginFramework.GLF.OAuthProperty prop)
        {
            Type providerType = Type.GetType(String.Format("GenericLoginFramework.OAuth.Providers.{0}", pro.ToString()));

            OAuth.Providers.OAuthProvider provider = (OAuth.Providers.OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            PropertyInfo pi = provider.GetType().GetProperty(prop.ToString());

            return (string)pi.GetValue(provider, null);
        }

        public void EnableOpenIDProvider(GenericLoginFramework.GLF.OpenIDProvider pro)
        {
            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOpenIDProvicerProperty(GenericLoginFramework.GLF.OpenIDProvider pro, GenericLoginFramework.GLF.OpenIDProperty prop)
        {
            return "";
        }
    }
}
