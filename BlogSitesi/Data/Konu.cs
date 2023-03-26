namespace BlogSitesi.Data
{
    public class Konu
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Makale> Makaleler { get; set; } = new();
    }
}
