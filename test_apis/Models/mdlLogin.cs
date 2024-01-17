using System.ComponentModel.DataAnnotations;

namespace test_apis.Models
{
    public class mdlLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
