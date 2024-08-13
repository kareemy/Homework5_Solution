using Microsoft.EntityFrameworkCore;

namespace Homework5_Solution.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Products.Any())
        {
            return;
        }

        context.Products.AddRange(
            new Product { Name = "MindSync", Description = "MindSync is a neural implant that taps directly into your consciousness, blurring the line between mind and machine. It unlocks hidden depths of cognitive power, subtly altering your thoughts as it weaves its influence into every aspect of your reality.", Price = 1995.99M, ImageURL = "img/mindsync.jpg" },
            new Product { Name = "Seraphine", Description = "Seraphine is an advanced AI assistant that quietly monitors your every move, anticipating your needs before you even voice them. Always listening, always watching, Seraphine seamlessly weaves itself into your life, guiding your actions with an eerie, almost omnipresent precision.", Price = 200M, ImageURL = "img/seraphine.jpg" },
            new Product { Name = "SoulSear", Description = "SoulSear is an advanced energy weapon engineered for maximum operational efficiency and strategic dominance on the battlefield. Designed with cutting-edge targeting systems and optimized for high-intensity impact, SoulSear delivers unparalleled precision and lethality, ensuring superior tactical performance for elite military and defense operations.", Price = 43000000M, ImageURL = "img/deathray.jpg" },
            new Product { Name = "PhantomClaw", Description = "PhantomClaw is a next-generation gaming mouse, designed with advanced precision technology that adapts to your every move, almost as if it knows your intentions before you do. Beneath its sleek exterior lies a hidden power, subtly guiding your gameplay with an unsettling accuracy, making you question who's really in control.", Price = 99.95M, ImageURL = "img/phantomclaw.jpg" }
        );

        context.SaveChanges();
    }
}