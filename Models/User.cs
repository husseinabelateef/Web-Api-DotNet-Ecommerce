using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class User: IdentityUser
    {
        public string name { get; set; }
        public string street { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string Pass { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }

    }
}
