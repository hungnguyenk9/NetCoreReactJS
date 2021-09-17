using System;

namespace NetCoreReactJS.Models
{
    public class AuthRes
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
