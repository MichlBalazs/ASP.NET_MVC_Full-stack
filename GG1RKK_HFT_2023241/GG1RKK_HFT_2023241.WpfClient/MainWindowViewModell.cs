using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.WpfClient
{
    public class MainWindowViewModell
    {
        public RestCollection<Order> Orders { get; set; }
        public RestCollection<Item> Items { get; set; }
        public RestCollection<Adventurer> Adventurers { get; set; }
        public RestCollection<Category> Categories { get; set; }
        public MainWindowViewModell()
        {
            Orders = new RestCollection<Order>("http://localhost:4112/", "Order");
            Items = new RestCollection<Item>("http://localhost:4112/", "Item");
            Adventurers = new RestCollection<Adventurer>("http://localhost:4112/", "Adventurer");
            Categories = new RestCollection<Category>("http://localhost:4112/", "Category");
        }
    }
}
