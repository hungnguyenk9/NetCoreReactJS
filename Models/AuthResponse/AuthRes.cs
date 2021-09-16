using System;

namespace NetCoreReactJS.Models.AuthResponse
{
    public class AuthRes
    {
        public string FullName { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
