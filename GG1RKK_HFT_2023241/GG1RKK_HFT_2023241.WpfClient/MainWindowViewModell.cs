using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GG1RKK_HFT_2023241.WpfClient
{
    public class MainWindowViewModell :ObservableRecipient
    {
        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { SetProperty(ref selectedOrder,value); }
        }

        public RestCollection<Order> Orders { get; set; }
        //public RestCollection<Item> Items { get; set; }
        //public RestCollection<Adventurer> Adventurers { get; set; }
        //public RestCollection<Category> Categories { get; set; }

        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand UpdateOrderCommand { get; set; }
        public MainWindowViewModell()
        {
            Orders = new RestCollection<Order>("http://localhost:4112/", "Order");
            //Items = new RestCollection<Item>("http://localhost:4112/", "Item");
            //Adventurers = new RestCollection<Adventurer>("http://localhost:4112/", "Adventurer");
            //Categories = new RestCollection<Category>("http://localhost:4112/", "Category");

            CreateOrderCommand = new RelayCommand(
                () => { Orders.Add(new Order() { AdventurerId = 1, ItemId = 20 }); }
                );
            DeleteOrderCommand = new RelayCommand(
                () => { Orders.Delete(SelectedOrder.OrderId); }
                //,() => { return SelectedOrder != null;} 
                );

            UpdateOrderCommand = new RelayCommand(
                () => { Orders.Update(SelectedOrder); }
                //,() => { return SelectedOrder != null; }
                );
        }
    }
}
