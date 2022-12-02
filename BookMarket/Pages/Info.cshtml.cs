using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BookMarket.Pages
{
    [IgnoreAntiforgeryToken]
    public class InfoModel : PageModel
    {

        public List<BooksShop> booksShop { get; set; }
        [BindProperty]
        public BooksShop book { get; set; }
        public string Message { get; set; }
        public void OnGet(string id)
        {
            using (StreamReader sr=new StreamReader("books.json"))
            {
                booksShop = JsonConvert.DeserializeObject<List<BooksShop>>(sr.ReadToEnd());
            }
            book = booksShop.Where(o => o.Id == id).FirstOrDefault();
            Message = $"Id:{book.Id} / {book.Name} / {book.AuthoName} / Style:{book.Style} ";
        }
    }
}
