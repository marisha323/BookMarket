using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace BookMarket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<BooksShop>? books = new List<BooksShop>();/*{ new BooksShop() { Id=Guid.NewGuid().ToString(),Name="Narnia",AuthoName="Rouling",Publisher="USA",Style="Fantasi", Year = 2004 } };*/
       
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            using (StreamReader fs = new StreamReader("books.json"))
            {
                books = JsonConvert.DeserializeObject<List<BooksShop>>(fs.ReadToEnd());
            }

            if (books==null)
            {
                books = new List<BooksShop>();
            }
        }

        public async Task OnPostDeleteAsync(string id)
        {
            BooksShop? booksShop = books.Where(o => o.Id == id).FirstOrDefault();
            if (booksShop!=null)
            {
                books.Remove(booksShop);
                using (StreamWriter sw = new StreamWriter("books.json"))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(books));
                }
            }
        }
        public List<BooksShop>? books2 = new List<BooksShop>();
        public async Task OnPostSearhcAsync(string PoickName)
        {
            try
            {
            books2 = books.Where(o=>o.Name.ToLower().Contains(PoickName.ToLower())).ToList();

            }
            catch (Exception)
            {

              
            }
        }

        }
}