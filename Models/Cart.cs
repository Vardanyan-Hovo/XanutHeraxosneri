using System.ComponentModel.DataAnnotations;

namespace XanutHeraxosneri.Models
{
    public class Cart
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApranqName { get; set; }
        public int IdApranq { get; set; }
        public Apranq Apranq { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        
        public string sessionId { get; set; }
        public int Price { get; set; }
        public string img { get; set; }
        public DateTime CardsessionTime { get; set; } = DateTime.Now;

    }
}
