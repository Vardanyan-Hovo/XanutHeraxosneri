using System.ComponentModel.DataAnnotations;

namespace XanutHeraxosneri.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "3 ic 30 simvol")]
        public string PeopleName { get; set;}
        public uint Age { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public bool Masnaget { get; set; } = false;
        public string ? CartId { get; set; }
        public string? session { get; set; }
        public List<Cart>? Carts{ get; set; }  

    }
}
