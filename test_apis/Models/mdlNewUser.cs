using System.ComponentModel.DataAnnotations;

namespace test_apis.Models
{
    public class mdlNewUser
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string email { get; set; }

        public string? phoneNumber { get; set; }

    }
}
