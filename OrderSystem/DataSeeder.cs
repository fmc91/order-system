using Common;
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

            var speakers = new Category(0, "Speakers");
            var microphones = new Category(0, "Microphones");
            var decks = new Category(0, "Mixing Decks");

            db.Category.AddRange(speakers, microphones, decks);
            db.SaveChanges();

            db.Product.AddRange(
                new Product(0, speakers.CategoryId, "12\" Reever Professional Speakers", ProductSize.Large, 240),
                new Product(0, speakers.CategoryId, "16\" Bulgari Live Audio Speakers", ProductSize.Large, 280),
                new Product(0, microphones.CategoryId, "Allure A68 Vocal Microphone", ProductSize.Small, 180),
                new Product(0, microphones.CategoryId, "Mannheim M250 Heavy-Duty PA Microphone", ProductSize.Small, 150),
                new Product(0, decks.CategoryId, "Apocalypsis AX800 Professional Mixing Deck", ProductSize.ExtraLarge, 1200),
                new Product(0, decks.CategoryId, "Systemik Platinum P5 Live Mixing Deck", ProductSize.ExtraLarge, 980));

            db.SaveChanges();
        }
    }
}
