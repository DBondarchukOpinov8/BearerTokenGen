using System;
using System.ComponentModel.DataAnnotations;

namespace BearerTokenGen.Models {
    public class BearerTokenParamsModel {
        public String SigningKey { get; set; }

        public String ValidIssuer { get; set; }

        public String ValidAudience { get; set; }
    }
}
