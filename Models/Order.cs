namespace XanutHeraxosneri.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string img { get; set; }
        public DateTime Date { get; set; }
        public int Idcart { get; set; }
        public Cart cart { get; set; }
        public int Idpeople { get; set; }
        public People Peopleorder { get; set; }
    }
}
