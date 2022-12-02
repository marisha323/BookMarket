namespace BookMarket
{
    public class BooksShop
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? AuthoName { get; set; }
        public string? Style { get; set; }
        public string? Publisher { get; set; }
        public int Year { get; set; }

        public string getBooks()
        {
            return $"Title: {Name}, Author Name: {AuthoName}, Style: {Style}, Publisher: {Publisher}, Year: {Year}";
        }
    }
}
