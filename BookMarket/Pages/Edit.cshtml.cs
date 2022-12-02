using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BookMarket.Pages
{
    public class EditModel : PageModel
    {
        public List<BooksShop>? books { get; set; }
        public BooksShop booksShop { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            using (StreamReader sr=new StreamReader("books.json"))
            {
                books=JsonConvert.DeserializeObject<List<BooksShop>>(sr.ReadToEnd());
            }
            booksShop = books.Where(o=>o.Id==id).FirstOrDefault();
            if (booksShop==null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
                
        }

        public async Task<IActionResult> OnPostAsync(string id,string nameBooks,string authorName,string styleBooks,string publisherBooks,string year)
        {
            using (StreamReader sr=new StreamReader("books.json"))
            {
                books = JsonConvert.DeserializeObject<List<BooksShop>>(sr.ReadToEnd());
            }
            booksShop = books.Where(o=>o.Id==id).FirstOrDefault();
            if (booksShop==null)
            {
                return NotFound();
            }
            else
            {
                booksShop.Name=nameBooks;
                booksShop.AuthoName=authorName;
                booksShop.Style=styleBooks;
                booksShop.Publisher=publisherBooks;
                booksShop.Year=int.Parse(year);
            }
            using(StreamWriter sw=new StreamWriter("books.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(books));
            }
            return RedirectToPage("/Index");
        }
    }
}
