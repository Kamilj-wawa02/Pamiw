using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Library.Shared.Configuration
{
    public class LibraryEndpoints
    {
        public string Base_url { get; set; }
        public string GetBooksEndpoint { get; set; }
        public string GetBookEndpoint {  get; set; }
        public string UpdateBookEndpoint { get; set; }
        public string DeleteBookEndpoint { get; set; }
        public string AddBookEndpoint { get; set; }
        public string SearchBooksEndpoint { get; set; }

        public string GetBooksCountEndpoint { get; set; }
        public string GetAllBooksCountEndpoint { get; set; }

    }
}
