using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.Providers
{
    public class GoogleProvider : OpenIDProvider
    {
        private static GoogleProvider _instance;
        private string _redirectURI = "https://www.facebook.com/connect/login_success.html";
        public override string RedirectURI
        {
            get
            {
                if (UsedFlow == GLF.ProviderFlow.AuthorizationCode)
                    return "urn:ietf:wg:oauth:2.0:oob:auto";
                else if (UsedFlow == GLF.ProviderFlow.Implicit)
                    return _redirectURI;
                else
                    throw new NotImplementedException();
            }
            set
            {
                _redirectURI = value;
            }
        } //= //("urn:ietf:wg:oauth:2.0:oob:auto";
        public override string LoginEndpoint { get; set; } = "https://accounts.google.com/o/oauth2/v2/auth";
        public override string ResourceEndpoint { get; set; } = "https://www.googleapis.com/userinfo/v2/me";//"https://www.googleapis.com/oauth2/v2/userinfo";
        public override string Scope { get; set; } = "email%20profile";

        public static GoogleProvider Instance
        {
            get
            {
                if (_instance == null)  
                    _instance = new GoogleProvider();

                return _instance;
            }
        }

        private GoogleProvider() { }

        public override async Task<string> GetTokenFromGrant(string grant)
        {
            string token = "";

            using (var client = new HttpClient())
            {
                Dictionary<string, string> postvalues = new Dictionary<string, string>
                {
                   { "code", grant },
                   { "client_id", AppID },
                   { "client_secret", AppSecret },
                   { "redirect_uri", RedirectURI },
                   { "grant_type", "authorization_code" }
                };

                var content = new FormUrlEncodedContent(postvalues);

                var response = await client.PostAsync("https://www.googleapis.com/oauth2/v4/token", content);

                var responseString = await response.Content.ReadAsStringAsync();
                Dictionary<string, string> responseJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                token = responseJSON["access_token"];

                Console.WriteLine(responseString);
            }

            return token;
        }

        public async override Task<Resource> GetResourceFromToken(string token)
        {
            string resource = "";

            using (var client = new HttpClient())
            {
                resource = await client.GetStringAsync(String.Format("{0}?access_token={1}", ResourceEndpoint, token));
            }

            return ConvertJSONToResource(resource);
        }

        protected override Resource ConvertJSONToResource(string JSONString)
        {
            Dictionary<string, string> JSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSONString);

            return new Resource
            {
                ID = JSON["id"],
                Name = JSON["given_name"],
                LastName = JSON["family_name"],
                Email = JSON["email"],
                Type = "Google"
            };
        }
    }
}
