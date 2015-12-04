using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
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

            User user = null;

            using(GLFDbContext db = new GLFDbContext(DbName, IsConnString))
            {

                if (pro == OAuthProviderEnum.FacebookProvider)
                {
                    user = db.Users.Where(u => u.FacebookResource.ID == resource.ID)
                                   .Include(u => u.FacebookResource)
                                   .Include(u => u.GoogleResource)
                                   .FirstOrDefault();
                }


                if (user != null)
                {
                    if(pro == OAuthProviderEnum.FacebookProvider)
                    {
                        db.Entry(user.FacebookResource).CurrentValues.SetValues(resource);
                    }
                }
                else
                {
                    Type type = typeof(User);
                    PropertyInfo property = type.GetProperty(resource.GetType().Name, BindingFlags.Public | BindingFlags.Instance);
                    user = new User ();
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
