using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TUSUR.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TUSUR.Services
{
    public class FacebookService
    {
        
        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.7/me/?fields=name,email&access_token="
                + "EAADAv8wjxlEBADdhNRhVw4ogH0VvPIV6kwGOq7JZC6zZBQKBWGk5r4ntMrTrkRgrWfIor6e4UWwal2mZA4ZAOngBhIJA3ZAinG3VMo4kkoEve2CZC8bgqYs82pLppjbe5l95niNXDx0fePbMJ66m1aA9ji66NX9ydD9bXFUcNQ5JrlxRmeYtID";

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }
    }
}
