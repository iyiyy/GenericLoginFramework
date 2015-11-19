using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public override GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow UsedFlow { get; set; }

        public override async Task<GenericLoginFramework.OAuth.Resources.OAuthResource> GetResourceFromToken(string token)
        {
            if (UsedFlow == GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.Implicit)
            {
                using (var client = new HttpClient())
                {
                    string resourceString = await client.GetStringAsync(String.Format("https://graph.facebook.com/me?access_token={0}&fields=id,name,first_name,last_name,link,gender,locale,timezone,updated_time,verified", token));
                    Dictionary<string, string> resourceJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceString);
                    return new GenericLoginFramework.OAuth.Resources.FacebookResource
                    {
                        ID = resourceJSON["id"],
                        Name = resourceJSON["name"],
                        FirstName = resourceJSON["first_name"],
                        LastName = resourceJSON["last_name"],
                        Link = resourceJSON["link"],
                        Gender = resourceJSON["gender"],
                        Locale = resourceJSON["locale"],
                        Timezone = resourceJSON["timezone"],
                        UpdatedTime = resourceJSON["updated_time"],
                        Verified = resourceJSON["verified"]
                    };
                }
            }
            else if (UsedFlow == GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.AuthorizationCode)
            {
                using (var client = new HttpClient())
                { 
                    string responseString = await client.GetStringAsync(String.Format("https://graph.facebook.com/v2.5/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", AppID, RedirectURI, AppSecret, token));
                    Dictionary<string, string> responseJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                    token = responseJSON["access_token"];

                    string resourceString = await client.GetStringAsync(String.Format("https://graph.facebook.com/me?access_token={0}&fields=id,name,first_name,last_name,link,gender,locale,timezone,updated_time,verified", token));
                    Dictionary<string, string> resourceJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceString);
                    return new GenericLoginFramework.OAuth.Resources.FacebookResource {
                        ID = resourceJSON["id"],
                        Name = resourceJSON["name"],
                        FirstName = resourceJSON["first_name"],
                        LastName = resourceJSON["last_name"],
                        Link = resourceJSON["link"],
                        Gender = resourceJSON["gender"],
                        Locale = resourceJSON["locale"],
                        Timezone = resourceJSON["timezone"],
                        UpdatedTime = resourceJSON["updated_time"],
                        Verified = resourceJSON["verified"]
                    };
                }
            }
            else
                throw new NotImplementedException();
        }

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
