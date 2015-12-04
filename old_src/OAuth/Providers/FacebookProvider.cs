using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GenericLoginFramework.OAuth.Resources;

namespace GenericLoginFramework.OAuth.Providers
{
    class FacebookProvider : OAuthProvider
    {
        private static FacebookProvider instance;
        private string appID;
        private string appSecret;
        private string redirectURI;

        private FacebookProvider(){}

        public static FacebookProvider Instance
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

                return string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&response_type={1}&redirect_uri={2}", AppID, responseType, RedirectURI);
            }
        }

        public string DefaultRedirectURI
        {
            get
            {
                return "https://www.facebook.com/connect/login_success.html";
            }
        }

        public string RedirectURI
        {
            get
            {
                if (redirectURI == null || redirectURI.Length == 0)
                    return DefaultRedirectURI;

                return redirectURI;
            }
            set
            {
                redirectURI = value;
            }
        }

        public override OAuthProvider.Flow UsedFlow { get; set; }

        public override async Task<OAuthResource> GetResourceFromToken(string token)
        {
            if (UsedFlow == OAuthProvider.Flow.Implicit)
            {
                using (var client = new HttpClient())
                {
                    string resourceString = await client.GetStringAsync(String.Format("https://graph.facebook.com/me?access_token={0}&fields=id,name,first_name,last_name,link,gender,locale,timezone,updated_time,verified", token));
                    Dictionary<string, string> resourceJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceString);
                    return new FacebookResource
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
            else if (UsedFlow == OAuthProvider.Flow.AuthorizationCode)
            {
                using (var client = new HttpClient())
                {
                    //string input = String.Format("https://graph.facebook.com/v2.5/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", AppID, RedirectURI, AppSecret, token);
                    string input = String.Format("https://graph.facebook.com/v2.5/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", AppID, RedirectURI, AppSecret, token);
                    //string input = "https://graph.facebook.com/v2.5/oauth/access_token?client_id=624408054367639&redirect_uri=" + RedirectURI + "&client_secret=3ee73a2a0c243edff171618669a7b1a3&code=" + token;
                    Console.WriteLine(input);
                    string responseString = await client.GetStringAsync(input);
                    Dictionary<string, string> responseJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                    token = responseJSON["access_token"];

                    string resourceString = await client.GetStringAsync(String.Format("https://graph.facebook.com/me?access_token={0}&fields=id,name,first_name,last_name,link,gender,locale,timezone,updated_time,verified", token));
                    Dictionary<string, string> resourceJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceString);
                    return new FacebookResource {
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
                UsedFlow = OAuthProvider.Flow.Implicit;
            }
            else if (keys.Length > 1)
            {
                AppID = keys[0];
                AppSecret = keys[1];
                UsedFlow = OAuthProvider.Flow.AuthorizationCode;
            }
        }
    }
}
