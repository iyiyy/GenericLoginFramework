using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OAuth.Providers
{
    class FacebookProvider : GenericLoginFramework.OAuth.Providers.OAuthProvider
    {
        private static GenericLoginFramework.OAuth.Providers.FacebookProvider instance;
        private string appID;
        private string appSecret;

        private FacebookProvider(){}

        public static GenericLoginFramework.OAuth.Providers.FacebookProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new FacebookProvider();

                return instance;
            }
        }

        public string AppID
        {
            get
            {
                return appID;
            }
            set
            {
                if (appID == null)
                    appID = value;
            }
        }

        public string AppSecret
        {
            get
            {
                return appSecret;
            }
            set
            {
                if (appSecret == null)
                    appSecret = value;
            }
        }

        public string DialogURI
        {
            get
            {
                if (AppID == null || AppID.Length == 0)
                    throw new Exception("Can't return dialog URI since the app ID has not been set!");

                string responseType = (UsedFlow == GenericLoginFramework.OAuth.Providers.FacebookProvider.Flow.AuthorizationCode ? "code" : "token");
                string redirectURI = (RedirectURI == null || RedirectURI.Length == 0) ? DefaultRedirectURI : RedirectURI;

                return string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&response_type={1}&redirect_uri={2}", AppID, responseType, redirectURI);
            }
        }

        public string DefaultRedirectURI
        {
            get
            {
                return "https://www.facebook.com/connect/login_success.html";
            }
        }

        public string RedirectURI { get; set; }

        public GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow UsedFlow { get; set; }

        public override void SetKeys(string[] keys)
        {
            if (keys.Length == 1)
            {
                AppID = keys[0];
                UsedFlow = GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.Implicit;
            }
            else if (keys.Length > 1)
            {
                AppID = keys[0];
                AppSecret = keys[1];
                UsedFlow = GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.AuthorizationCode;
            }
        }
    }
}
