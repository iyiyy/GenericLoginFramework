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
        private string DbName { get; set; }
        private bool IsConnString { get; set; }

        public void InitializeGLFDb(string name, bool isConnString)
        {
            if (!DbIsInitialized)
            {
                DbName = name;
                IsConnString = isConnString;
                using (GenericLoginFramework.Database.GLFDbContext db = new GenericLoginFramework.Database.GLFDbContext(DbName, IsConnString)) { };
            }

            DbIsInitialized = true;
        }

        public void EnableOauthProvider(GenericLoginFramework.GLF.OAuthProvider pro, params string[] args)
        {
            GenericLoginFramework.OAuth.Providers.OAuthProvider provider = GetOAuthProvider(pro);

            provider.SetKeys(args);

            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOAuthProviderProperty(GenericLoginFramework.GLF.OAuthProvider pro, GenericLoginFramework.GLF.OAuthProperty prop)
        {
            GenericLoginFramework.OAuth.Providers.OAuthProvider provider = GetOAuthProvider(pro);

            PropertyInfo pi = provider.GetType().GetProperty(prop.ToString());

            return (string)pi.GetValue(provider, null);
        }

        public async Task<GenericLoginFramework.User> GetUserFromOAuthToken(GenericLoginFramework.GLF.OAuthProvider pro, string token)
        {
            GenericLoginFramework.OAuth.Providers.OAuthProvider provider = GetOAuthProvider(pro);
            GenericLoginFramework.OAuth.Resources.OAuthResource resource = await provider.GetResourceFromToken(token);

            GenericLoginFramework.User user;
            using(GenericLoginFramework.Database.GLFDbContext db = new GenericLoginFramework.Database.GLFDbContext(DbName, IsConnString))
            {

                user = db.Users.Where(u => (u.GetType().GetProperty(pro.ToString()).GetValue(u)).GetType().GetProperty("ID").GetValue((u.GetType().GetProperty(pro.ToString()).GetValue(u))).ToString() == resource.ID).FirstOrDefault();

                /*user = (from u in db.Users
                        where u.FacebookResource.ID == resource.ID
                        select u).FirstOrDefault();*/

                Type type = user.GetType();
                PropertyInfo property = type.GetProperty(resource.GetType().ToString(), BindingFlags.Public | BindingFlags.Instance);

                if (user != null)
                {
                    property.SetValue(user, resource, null);
                }
                else
                {
                    user = new GenericLoginFramework.User { ID = new Guid().ToString() };
                    property.SetValue(user, resource, null);
                    db.Users.Add(user);
                    
                }
                db.SaveChanges();
            }

            return user;
        }

        public void EnableOpenIDProvider(GenericLoginFramework.GLF.OpenIDProvider pro)
        {
            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOpenIDProvicerProperty(GenericLoginFramework.GLF.OpenIDProvider pro, GenericLoginFramework.GLF.OpenIDProperty prop)
        {
            return "";
        }

        private GenericLoginFramework.OAuth.Providers.OAuthProvider GetOAuthProvider(GenericLoginFramework.GLF.OAuthProvider pro)
        {
            Type providerType = Type.GetType(String.Format("GenericLoginFramework.OAuth.Providers.{0}", pro.ToString()));

            GenericLoginFramework.OAuth.Providers.OAuthProvider provider = (GenericLoginFramework.OAuth.Providers.OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            return provider;
        }
    }
}
