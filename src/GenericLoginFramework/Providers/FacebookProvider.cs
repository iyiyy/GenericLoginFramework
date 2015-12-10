using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace GenericLoginFramework.Providers
{
    public class FacebookProvider : OAuthProvider
    {
        private static FacebookProvider _instance;
        public override string RedirectURI { get; set; } = "https://www.facebook.com/connect/login_success.html";
        public override string LoginEndpoint { get; set; } = "https://www.facebook.com/dialog/oauth";
        public override string ResourceEndpoint { get; set; } = "https://graph.facebook.com/me";
        public override string Scope { get; set; } = "email";

        public override dynamic Instance()
        {
            if (_instance == null)
                _instance = new FacebookProvider();
            return _instance;
        }

        /*public static FacebookProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FacebookProvider();
                return _instance;
            }
        }*/

        private FacebookProvider() { }

        public override async Task<string> GetTokenFromGrant(string grant)
        {
            string token = "";

            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync(String.Format("https://graph.facebook.com/v2.5/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}&scope={4}", AppID, RedirectURI, AppSecret, grant, Scope));
                Dictionary<string, string> responseJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                token = responseJSON["access_token"];
            }

            return token;
        }

        public override async Task<Resource> GetResourceFromToken(string token)
        {
            string resource = "";

            using (var client = new HttpClient())
            {
                resource = await client.GetStringAsync(String.Format("{0}?access_token={1}&fields=id,first_name,last_name,link,gender,locale,timezone,updated_time,verified", ResourceEndpoint, token));
            }

            return ConvertJSONToResource(resource);
        }

        protected override Resource ConvertJSONToResource(string JSONString)
        {
            Dictionary<string, string> JSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSONString);

            return new Resource
            {
                ID = JSON["id"],
                Name = JSON["first_name"],
                LastName = JSON["last_name"],
                Type = "Facebook"
            };
        }
    }
}
