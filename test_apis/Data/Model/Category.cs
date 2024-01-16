using System.ComponentModel.DataAnnotations;

namespace test_apis.Data.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        public string? notes { get; set; }

        public List<Items> Items { get; set; }
    }
}
