using Bogus;
using P06Shop.Shared.Library;

namespace P07Shop.DataSeeder
{
    public class BookSeeder
    {
        public static List<Book> GenerateBookData()
        {
            int productId = 1;
            var productFaker = new Faker<Book>()
                .RuleFor(x=>x.Title, x=>x.Internet.DomainWord())
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x=>x.Id, x=> productId++);

            return productFaker.Generate(10).ToList();

        }
    }
}
