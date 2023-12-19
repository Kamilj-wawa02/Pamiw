using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Library.Shared.Auth
{
    public class FacebookAuthDTO
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }


}
