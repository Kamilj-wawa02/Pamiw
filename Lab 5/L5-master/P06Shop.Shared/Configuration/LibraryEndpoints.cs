using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Configuration
{
    public class LibraryEndpoints
    {
        public string Base_url { get; set; }
        public string GetBooksEndpoint { get; set; }
        public string GetBookEndpoint {  get; set; }
        public string UpdateBookEndpoint { get; set; }
        public string DeleteBookEndpoint { get; set; }
        public string AddBookEndpoint { get; set; }

    }
}
