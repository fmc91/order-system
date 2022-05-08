using DataLayer;
using DataLayer.Model;

namespace OrderSystem
{
    public static class DataSeeder
    {
        public static void SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<OrderSystemContext>();

            if (db.Product.Any()) return;

            var electricGuitar = new Category(0, "Electric Guitar");
            var acousticGuitar = new Category(0, "Acoustic Guitar");
            var bassGuitar = new Category(0, "Bass Guitar");
            var guitarAmp = new Category(0, "Guitar Amplifier");

            db.Category.AddRange(electricGuitar, acousticGuitar, bassGuitar, guitarAmp);
            db.SaveChanges();

            db.Product.AddRange(
                new Product(0, electricGuitar.CategoryId, "Ibanez RG421", 399)
                {
                    Description = "A lean, mean shredding machine with mahogany body, alder neck and twin humbucking pickups.",
                    Weight = 4.5,
                    Length = 1280,
                    Width = 480,
                    Height = 200
                },
                new Product(0, electricGuitar.CategoryId, "Schecter Omen Extreme 6", 439)
                {
                    Description = "The high-output twin humbucking pickups on this metal monster deliver bone-crushingly awesome distortion tones.",
                    Weight = 4.8,
                    Length = 1280,
                    Width = 480,
                    Height = 200
                },
                new Product(0, electricGuitar.CategoryId, "Gibson Les Paul Classic", 2499)
                {
                    Description = "An iconic (albeit overpriced) guitar with a defining legacy spanning a range of genres " +
                        "from blues to heavy metal - the warm crunch delivered by its twin PAFs won't disappoint.",
                    Weight = 4.4,
                    Length = 1280,
                    Width = 480,
                    Height = 200
                },
                new Product(0, electricGuitar.CategoryId, "Fender Player Telecaster", 799)
                {
                    Description = "An age-old classic at an affordable price, the unmistakable tone of this guitar makes it " +
                        "well-suited for a variety of genres, from blues to psychedelic rock.",
                    Weight = 4.2,
                    Length = 1280,
                    Width = 480,
                    Height = 200
                },
                new Product(0, acousticGuitar.CategoryId, "Yamaha FG800 Acoustic Guitar", 349)
                {
                    Description = "A versatile and reliable offering from Yamaha with a dreadnought body style, well suited " +
                        "for country music and singer-songwriters.",
                    Weight = 3.8,
                    Length = 1280,
                    Width = 480,
                    Height = 200
                },
                new Product(0, bassGuitar.CategoryId, "Fender Player P-Bass", 899)
                {
                    Description = "With warm, round tones and a wide, accessible fretboard, this budget alternative gives the " +
                        "original 1960s P-Bass a run for its money.",
                    Weight = 4.8,
                    Length = 1520,
                    Width = 480,
                    Height = 200
                },
                new Product(0, bassGuitar.CategoryId, "Ibanez SR-370E Bass Guitar", 329)
                {
                    Description = "A stylish bass guitar with a modern, versatile sound, highly configurable electronics and " +
                        "comfortable fretboard, Ibanez have really hit the mark with this one",
                    Weight = 4.9,
                    Length = 1520,
                    Width = 480,
                    Height = 200
                });

            db.SaveChanges();
        }
    }
}
