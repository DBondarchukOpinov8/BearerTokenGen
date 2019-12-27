using System;

namespace BearerTokenGen.Models {
    public class TokenModel {
        public String AccessToken { get; set; }
        public Boolean IsValid { get; set; }
        public String ErrorMessage { get; set; }
    }
}
