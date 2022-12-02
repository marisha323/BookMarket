using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BookMarket.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddBookModel : PageModel
    {
        BooksShop bookShop = new BooksShop();
        public async Task<IActionResult> OnPostAsync(string nameBooks,string authorName,string styleBooks,string publisherBooks, string year)
        {
            bookShop.Id = Guid.NewGuid().ToString();
            bookShop.Name = nameBooks;
            bookShop.AuthoName = authorName;
            bookShop.Publisher = publisherBooks;
            bookShop.Style = styleBooks;
            bookShop.Year = int.Parse(year);

          
            List<BooksShop> books = new List<BooksShop>();



            using (StreamReader sr = new StreamReader("books.json"))
            {
                books = JsonConvert.DeserializeObject<List<BooksShop>>(sr.ReadToEnd());
            }
            books.Add(bookShop);



            using (StreamWriter sw = new StreamWriter("books.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(books));
            }



            return RedirectToPage("Index");
        
    }
    }
}
