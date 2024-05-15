using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GG1RKK_HFT_2023241.WpfClient
{
    public class MainWindowViewModell :ObservableRecipient
    {
        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set 
            { 
                SetProperty(ref selectedOrder,value);
                (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateOrderCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private int _newOrderId;
        public int NewOrderId
        {
            get { return _newOrderId; }
            set
            {
                _newOrderId = value;
                OnPropertyChanged(nameof(NewOrderId)); // Notify property changed
            }
        }

        private int _newAdventurerId;
        public int NewAdventurerId
        {
            get { return _newAdventurerId; }
            set
            {
                _newAdventurerId = value;
                OnPropertyChanged(nameof(NewAdventurerId));
            }
        }

        private int _newItemId;
        public int NewItemId
        {
            get { return _newItemId; }
            set
            {
                _newItemId = value;
                OnPropertyChanged(nameof(NewItemId));
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RestCollection<Order> Orders { get; set; }
        public RestCollection<Item> Items { get; set; }
        public RestCollection<Adventurer> Adventurers { get; set; }
        public RestCollection<Category> Categories { get; set; }

        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand UpdateOrderCommand { get; set; }
        public MainWindowViewModell()
        {
            if (!IsInDesignMode)
            {

                Orders = new RestCollection<Order>("http://localhost:4112/", "Order", "hub");
                Items = new RestCollection<Item>("http://localhost:4112/", "Item", "hub");
                Adventurers = new RestCollection<Adventurer>("http://localhost:4112/", "Adventurer", "hub");
                Categories = new RestCollection<Category>("http://localhost:4112/", "Category", "hub");

                CreateOrderCommand = new RelayCommand(
                    () => {
                        Adventurer newOrderAdventurer = Adventurers.Where(t => t.AdventurerId == NewAdventurerId).First();
                        Item newOrderItem = Items.Where(t => t.ItemId == NewItemId).First();
                        Order newOrder = new Order()
                        {
                            OrderId = NewOrderId,
                            AdventurerId = NewAdventurerId,
                            Adventurer = newOrderAdventurer,
                            ItemId = NewItemId,
                            Item = newOrderItem
                        };
                        Orders.Add(newOrder); 
                    });


                DeleteOrderCommand = new RelayCommand(
                    () => { Orders.Delete(SelectedOrder.OrderId); }
                    ,() => { return SelectedOrder != null; }
                    );


                UpdateOrderCommand = new RelayCommand(
                    () =>
                    {
                        Orders.Update(SelectedOrder);
                    }
                    ,() => { return SelectedOrder != null; }
                    );
            }
        }
    }
}
