using System.ComponentModel.DataAnnotations;

namespace XanutHeraxosneri.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "2 Ից մինչև 30 սիմվոլ")]
        public string Name { get; set; }
        public string DescCategory { get; set; }
      //  public List<Apranq> ?Apranqner { get; set; }

    }
}
