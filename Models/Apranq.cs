using System.ComponentModel.DataAnnotations;

namespace XanutHeraxosneri.Models
{
    public class Apranq
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =2,ErrorMessage ="2 Ից մինչև 30 սիմվոլ")]
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Longdesc { get; set; }
        public bool IsFavorit { get; set; }
        public uint Price { get; set; }
        public string img { get; set; }
        public int Available { get; set; }
        public DateTime Apranctime { get; set; } = DateTime.Now;
        public int? idCategory { get; set; }
        public Category categoryA { get; set; }
    }
}