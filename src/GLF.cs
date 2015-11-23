using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GenericLoginFramework.Database;
using GenericLoginFramework.OAuth.Resources;
using GenericLoginFramework.OAuth.Providers;
using GenericLoginFramework.OpenID.Resources;
using GenericLoginFramework.OpenID.Providers;

namespace GenericLoginFramework
{
    public class GLF
    {
        public GLF()
        {
            DbIsInitialized = false;
        }

        public enum OAuthProviderEnum
        {
            FacebookProvider
        }

        public enum OpenIDProviderEnum
        {
            GoogleProvider
        }

        public enum OAuthPropertyEnum
        {
            AppID,
            AppSecret,
            DialogURI,
            RedirectURI,
            DefaultRedirectURI
        }

        public enum OpenIDPropertyEnum
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
                using (GLFDbContext db = new GLFDbContext(DbName, IsConnString)) { };
            }

            DbIsInitialized = true;
        }

        public void EnableOauthProvider(OAuthProviderEnum pro, params string[] args)
        {
            OAuthProvider provider = GetOAuthProvider(pro);

            provider.SetKeys(args);

            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOAuthProviderProperty(OAuthProviderEnum pro, OAuthPropertyEnum prop)
        {
            OAuthProvider provider = GetOAuthProvider(pro);

            PropertyInfo pi = provider.GetType().GetProperty(prop.ToString());

            return (string)pi.GetValue(provider, null);
        }

        public async Task<User> GetUserFromOAuthToken(OAuthProviderEnum pro, string token)
        {
            OAuthProvider provider = GetOAuthProvider(pro);
            OAuthResource resource = await provider.GetResourceFromToken(token);

            User user;
            using(GLFDbContext db = new GLFDbContext(DbName, IsConnString))
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
                    user = new User { ID = Guid.NewGuid() };
                    property.SetValue(user, resource, null);
                    db.Users.Add(user);
                    
                }
                db.SaveChanges();
            }

            return user;
        }

        public void EnableOpenIDProvider(OpenIDProviderEnum pro)
        {
            InitializeGLFDb("GenericLoginFramework", false);
        }

        public string GetOpenIDProvicerProperty(OpenIDProviderEnum pro, OpenIDPropertyEnum prop)
        {
            return "";
        }

        private OAuthProvider GetOAuthProvider(OAuthProviderEnum pro)
        {
            Type providerType = Type.GetType(String.Format("GenericLoginFramework.OAuth.Providers.{0}", pro.ToString()));

            OAuthProvider provider = (OAuthProvider)providerType.GetProperty("Instance").GetValue(null, null);

            return provider;
        }
    }
}
