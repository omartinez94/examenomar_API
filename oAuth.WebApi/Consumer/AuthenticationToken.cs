using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oAuth.WebAPI.Consumer
{
    public class AuthenticationToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
