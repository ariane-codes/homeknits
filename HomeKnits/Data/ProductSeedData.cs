using HomeKnits.Models;

namespace HomeKnits.Data
{
    public class ProductSeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetService<HomeKnitsContext>();

            if (context == null || context.Product.Any())
            {
                return; // DB has been seeded
            }

            await context.Product.AddRangeAsync(
                new Product
                {
                    Id = Guid.Parse("7135ca82-6fa7-4126-bcca-95104d524cbb"),
                    Name = "Yellow crochet hat",
                    ImageUrl = "https://sarahmaker.com/wp-content/uploads/2020/11/crochet-ribbed-beanie-1-2-683x1024.jpg",
                    Category = "Hats",
                    Colour = "Yellow",
                    Technique = "Crochet",
                    Description = "A lovely and practical hat for the winter season."
                },
                new Product
                {
                    Id = Guid.Parse("d2c948eb-e955-4c78-8184-41a16395c8e8"),
                    Name = "Knitted sweater",
                    ImageUrl = "https://i.etsystatic.com/24064068/r/il/bfa885/3572625842/il_fullxfull.3572625842_nsa3.jpg",
                    Category = "Sweater",
                    Colour = "Green",
                    Technique = "Knit",
                    Description = "A comfy sweater made of acrylic, machine-washable but not scratchy!"
                }
                );
            
            context.SaveChanges();
        }
    }
}
