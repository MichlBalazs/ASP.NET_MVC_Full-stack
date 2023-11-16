using GG1RKK_HFT_202324.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Repository.Database
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ShopDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("shop");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(item => item
                .HasOne<Manufacturer>()
                .WithMany()
                .HasForeignKey(item => item.Manufacturer.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Manufacturer>(m => m
                .HasMany<Item>()
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Order>(o => o
            .HasMany<Item>()
            .WithOne()
            );

modelBuilder.Entity<Item>().HasData(new Item[]
{
            new Item {ItemId = 1, ItemName = "Claymore", Price = 100, Manufacturer = { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" }},
            new Item {ItemId = 2, ItemName = "Potion of Invisibility", Price = 50, Manufacturer = { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" }},
            new Item {ItemId = 3, ItemName = "Rune Staff", Price = 200, Manufacturer = { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" }},
            new Item {ItemId = 4, ItemName = "Celestial Ring", Price = 150, Manufacturer = { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." }},
            new Item {ItemId = 5, ItemName = "Sorcerer's Spellbook", Price = 120, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 6, ItemName = "Ring of Shadows", Price = 300, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 7, ItemName = "Cloak of Shadows", Price = 300, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 8, ItemName = "Legendary Helm", Price = 500, Manufacturer = { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" }},
            new Item {ItemId = 9, ItemName = "Amulet of Eternal Wisdom", Price = 800, Manufacturer = { ManufacturerId = 8, ManufacturerName = "Astral Armaments Agency" }},
            new Item {ItemId = 10, ItemName = "Sorcerer's Robe", Price = 120, Manufacturer = { ManufacturerId = 1, ManufacturerName = "EnchantCraft Emporium" }},
            new Item {ItemId = 11, ItemName = "Phoenix Feather Wand", Price = 180, Manufacturer = { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" }},
            new Item {ItemId = 12, ItemName = "Dragon Scale Armor", Price = 400, Manufacturer = { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" }},
            new Item {ItemId = 13, ItemName = "Cursed Dagger", Price = 60, Manufacturer = { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" }},
            new Item {ItemId = 14, ItemName = "Elven Bow", Price = 150, Manufacturer = { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." }},
            new Item {ItemId = 15, ItemName = "Crystal Ball", Price = 250, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 16, ItemName = "Staff of Time Manipulation", Price = 700, Manufacturer = { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" }},
            new Item {ItemId = 17, ItemName = "Scepter of the Elements", Price = 1000, Manufacturer = { ManufacturerId = 8, ManufacturerName = "Astral Armaments Agency" }},
            new Item {ItemId = 18, ItemName = "Thief's Toolkit", Price = 30, Manufacturer = { ManufacturerId = 1, ManufacturerName = "EnchantCraft Emporium" }},
            new Item {ItemId = 19, ItemName = "Mystic Crystal", Price = 90, Manufacturer = { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" }},
            new Item {ItemId = 20, ItemName = "Aegis Shield", Price = 300, Manufacturer = { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" }},
            new Item {ItemId = 21, ItemName = "Helm of the Dragonborn", Price = 600, Manufacturer = { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" }},
            new Item {ItemId = 22, ItemName = "Venomous Dagger", Price = 70, Manufacturer = { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." }},
            new Item {ItemId = 23, ItemName = "Wand of Ice", Price = 160, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 24, ItemName = "Mystical Robes", Price = 250, Manufacturer = { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" }},
            new Item {ItemId = 25, ItemName = "Ancient Tome", Price = 180, Manufacturer = { ManufacturerId = 8, ManufacturerName = "Astral Armaments Agency" }},
            new Item {ItemId = 26, ItemName = "Soulstone Amulet", Price = 400, Manufacturer = { ManufacturerId = 1, ManufacturerName = "EnchantCraft Emporium" }},
            new Item {ItemId = 27, ItemName = "Blazing Sword", Price = 300, Manufacturer = { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" }},
            new Item {ItemId = 28, ItemName = "Dwarven Gauntlets", Price = 120, Manufacturer = { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" }},
            new Item {ItemId = 29, ItemName = "Enchanted Mirror", Price = 180, Manufacturer = { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" }},
            new Item {ItemId = 30, ItemName = "Lunar Staff", Price = 600, Manufacturer = { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." }},
            new Item {ItemId = 31, ItemName = "Cloak of Ethereal Shadows", Price = 350, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 32, ItemName = "Scepter of Arcane Mastery", Price = 900, Manufacturer = { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" }},
            new Item {ItemId = 33, ItemName = "Crystal Crown", Price = 500, Manufacturer = { ManufacturerId = 8, ManufacturerName = "Astral Armaments Agency" }},
            new Item {ItemId = 34, ItemName = "Bard's Lute", Price = 80, Manufacturer = { ManufacturerId = 1, ManufacturerName = "EnchantCraft Emporium" }},
            new Item {ItemId = 35, ItemName = "Silent Bow", Price = 200, Manufacturer = { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" }},
            new Item {ItemId = 36, ItemName = "Thunderstone Hammer", Price = 450, Manufacturer = { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" }},
            new Item {ItemId = 37, ItemName = "Crown of Eternal Wisdom", Price = 1000, Manufacturer = { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" }},
            new Item {ItemId = 38, ItemName = "Assassin's Cloak", Price = 300, Manufacturer = { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." }},
            new Item {ItemId = 39, ItemName = "Eagle Eye Amulet", Price = 150, Manufacturer = { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" }},
            new Item {ItemId = 40, ItemName = "Astral Compass", Price = 120, Manufacturer = { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" }},
        });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[]
            {
                new Manufacturer { ManufacturerId = 1, ManufacturerName = "EnchantCraft Emporium" },
                new Manufacturer { ManufacturerId = 2, ManufacturerName = "MystiForge Merchants" },
                new Manufacturer { ManufacturerId = 3, ManufacturerName = "Potion Pantheon Providers" },
                new Manufacturer { ManufacturerId = 4, ManufacturerName = "RuneRealm Traders" },
                new Manufacturer { ManufacturerId = 5, ManufacturerName = "Celestial Artifacts Co." },
                new Manufacturer { ManufacturerId = 6, ManufacturerName = "Sorcery Supplies Syndicate" },
                new Manufacturer { ManufacturerId = 7, ManufacturerName = "Arcane Arsenal Associates" },
                new Manufacturer { ManufacturerId = 8, ManufacturerName = "Astral Armaments Agency" },
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { OrderId = 1, CustomerName = "Ordan, the eater of magic crystals", ItemIdList = { 7, 37} },
                new Order { OrderId = 2, CustomerName = "Elara Shadowblade, the Whispering Night", ItemIdList = { 3, 18, 22, 1 , 16 } },
                new Order { OrderId = 3, CustomerName = "Thrain Ironheart, the Dwarven Defender", ItemIdList = { 5, 14, 29, 40,7 } },
                new Order { OrderId = 4, CustomerName = "Aeris Stormweaver, the Tempest Mage", ItemIdList = { 9 } },
                new Order { OrderId = 5, CustomerName = "Lyra Moonshadow, the Lunar Enchantress", ItemIdList = { 11, 27, 40 } },
                new Order { OrderId = 6, CustomerName = "Zephyr Blackthorn, the Silent Assassin", ItemIdList = { 16, 30 } },
                new Order { OrderId = 7, CustomerName = "Selene Frostfire, the Ice Sorceress", ItemIdList = { 21, 36, 39, 11, 9 } },
                new Order { OrderId = 8, CustomerName = "Galen Stormrider, the Thunder Lord", ItemIdList = { 24, 32, 33 } },
                new Order { OrderId = 9, CustomerName = "Eowyn Starlight, the Celestial Priestess", ItemIdList = { 28, 34, 37, 32, 24, 12, 35 } },
                new Order { OrderId = 10, CustomerName = "Kaela Swiftwind, the Elven Huntress", ItemIdList = { 31, 39, 40 } },
                new Order { OrderId = 11, CustomerName = "Jimmy, the guy", ItemIdList = { 1} },

            });
        }
    }
}
