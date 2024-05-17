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

        #region NewProperties
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

        private string _advNewAdventurerName;
        public string AdvNewAdventurerName
        {
            get { return _advNewAdventurerName; }
            set
            {
                _advNewAdventurerName = value;
                OnPropertyChanged(nameof(AdvNewAdventurerName));
            }
        }

        private int _advNewAdventurerId;

        public int AdvNewAdventurerId
        {
            get { return _advNewAdventurerId; }
            set 
            {
                _advNewAdventurerId = value;
                OnPropertyChanged(nameof(AdvNewAdventurerName));
            }
        }
        private int _advNewAdventurerLevel;

        public int AdvNewAdventurerLevel
        {
            get { return _advNewAdventurerLevel; }
            set 
            {
                _advNewAdventurerLevel = value;
                OnPropertyChanged(nameof(AdvNewAdventurerName));
            }
        }
        private string _advNewAdventurerClass;

        public string AdvNewAdventurerClass
        {
            get { return _advNewAdventurerClass; }
            set 
            {
                _advNewAdventurerClass = value;
                OnPropertyChanged(nameof(AdvNewAdventurerName));
            }
        }


        private int _itmNewItemId;

        public int ItmNewItemId
        {
            get { return _itmNewItemId; }
            set 
            {
                _itmNewItemId = value;
                OnPropertyChanged(nameof(ItmNewItemId));
            }
        }

        private string _itmNewItemName;

        public string ItmNewItemName
        {
            get { return _itmNewItemName; }
            set
            {
                _itmNewItemName = value;
                OnPropertyChanged(nameof(ItmNewItemName));
            }
        }


        private int _itmNewItemPrice;

        public int ItmNewItemPrice
        {
            get { return _itmNewItemPrice; }
            set
            {
                _itmNewItemPrice = value;
                OnPropertyChanged(nameof(ItmNewItemPrice));
            }
        }

        private int _itmNewItemCategoryId;

        public int ItmNewItemCategoryId
        {
            get { return _itmNewItemCategoryId; }
            set
            {
                _itmNewItemCategoryId = value;
                OnPropertyChanged(nameof(ItmNewItemCategoryId));
            }
        }


        private string _ctgrNewCategoryName;

        public string CtgrNewCategoryName
        {
            get { return _ctgrNewCategoryName; }
            set
            {
                _ctgrNewCategoryName = value;
                OnPropertyChanged(nameof(CtgrNewCategoryName));
            }
        }

        #endregion
        #region Selected
        private Order selectedOrder;
        private Adventurer selectedAdventurer;
        private Item selectedItem;
        private Category selectedCategory;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                SetProperty(ref selectedOrder, value);
                (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateOrderCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Adventurer SelectedAdventurer
        {
            get { return selectedAdventurer; }
            set {
                SetProperty(ref selectedAdventurer, value);
                (DeleteAdventurerCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateAdventurerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Item SelectedItem
        {
            get { return selectedItem; }
            set {
                SetProperty(ref selectedItem, value);
                (DeleteItemCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateItemCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set {
                SetProperty(ref selectedCategory, value);
                (DeleteCategoryCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCategoryCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        #endregion

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        #region RestCollections&ICommands
        public RestCollection<Order> Orders { get; set; }
        public RestCollection<Item> Items { get; set; }
        public RestCollection<Adventurer> Adventurers { get; set; }
        public RestCollection<Category> Categories { get; set; }

        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand UpdateOrderCommand { get; set; }

        public ICommand CreateItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand UpdateItemCommand { get; set; }

        public ICommand CreateAdventurerCommand { get; set; }
        public ICommand DeleteAdventurerCommand { get; set; }
        public ICommand UpdateAdventurerCommand { get; set; }

        public ICommand CreateCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }
        #endregion


        public MainWindowViewModell()
        {
            if (!IsInDesignMode)
            {

                Orders = new RestCollection<Order>("http://localhost:4112/", "Order", "hub");
                Items = new RestCollection<Item>("http://localhost:4112/", "Item", "hub");
                Adventurers = new RestCollection<Adventurer>("http://localhost:4112/", "Adventurer", "hub");
                Categories = new RestCollection<Category>("http://localhost:4112/", "Category", "hub");

                #region OrderRelayCommands
                CreateOrderCommand = new RelayCommand(
                    () => {
                        Adventurer newOrderAdventurer = Adventurers.Where(t => t.AdventurerId == NewAdventurerId).First();
                        Item newOrderItem = Items.Where(t => t.ItemId == NewItemId).First();
                        Order newOrder = new Order()
                        {
                            //OrderId = NewOrderId,
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
                #endregion
                #region AdventurerRelayCommands

                CreateAdventurerCommand = new RelayCommand(
                   () => {
                       Adventurers.Add(new Adventurer()
                       {
                           AdventurerId = AdvNewAdventurerId,
                           AdventurerName = AdvNewAdventurerName,
                           Class = AdvNewAdventurerClass,
                           Orders = null, 
                           Level = AdvNewAdventurerLevel
                           
                       });
                   });


                DeleteAdventurerCommand = new RelayCommand(
                    () => { Adventurers.Delete(SelectedAdventurer.AdventurerId); },
                    () => { return SelectedAdventurer != null; }
                    );


                UpdateAdventurerCommand = new RelayCommand(
                    () => { Adventurers.Update(SelectedAdventurer);},
                    () => { return SelectedAdventurer != null; }
                    );

                #endregion
                #region ItemRelayCommands

                CreateItemCommand = new RelayCommand(
                   () => {
                       Items.Add(new Item()
                       {
                           ItemName = ItmNewItemName,
                           Price = ItmNewItemPrice,
                           CategoryId = ItmNewItemCategoryId,
                           Category = Categories.Where(t => t.CategoryId == ItmNewItemCategoryId).First(),
                           Orders = null

                       });
                   });


                DeleteItemCommand = new RelayCommand(
                    () => { Items.Delete(SelectedItem.ItemId); },
                    () => { return SelectedItem != null; }
                    );


                UpdateItemCommand = new RelayCommand(
                    () => { Items.Update(SelectedItem); },
                    () => { return SelectedItem != null; }
                    );

                #endregion
                #region CategoryRelayCommands

                CreateCategoryCommand = new RelayCommand(
                   () => {
                       Categories.Add(new Category()
                       {
                           CategoryName = CtgrNewCategoryName
                       });
                   });


                DeleteCategoryCommand = new RelayCommand(
                    () => { Categories.Delete(SelectedCategory.CategoryId); },
                    () => { return SelectedCategory != null; }
                    );


                UpdateCategoryCommand = new RelayCommand(
                    () => { Categories.Update(SelectedCategory); },
                    () => { return SelectedCategory != null; }
                    );

                #endregion
            }
        }


    }
}