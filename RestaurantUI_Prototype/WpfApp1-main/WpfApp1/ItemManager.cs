using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;

namespace WpfApp1
{
    public class ItemManager:INotifyPropertyChanged
    {
        public enum CurrentList
        {
            Beverages,
            Entrees,
            Appetizers,
            Sides,
            Desserts
        }

        public CurrentList CurrentMenuList { get; set; } = CurrentList.Beverages;

        public static EventHandler<EventArgs> Initialized; 

        public static ItemManager Instance { get; set; }

        public ObservableCollection<Item> Beverages { get; set; }
        public ObservableCollection<Item> Entrees { get; set; }
        public ObservableCollection<Item> Appetizers { get; set; }
        public ObservableCollection<Item> Sides { get; set; }
        public ObservableCollection<Item> Desserts { get; set; }

        public ObservableCollection<Item> OrderQueue { get; set; }

        public ObservableCollection<Item> MenuList
        {
            get
            {
                switch (CurrentMenuList)
                {
                    case CurrentList.Beverages:
                    {
                        return Beverages;
                    }
                    case CurrentList.Appetizers:
                    {
                        return Appetizers;
                    }
                    case CurrentList.Desserts:
                    {
                        return Desserts;
                    }
                    case CurrentList.Entrees:
                    {
                        return Entrees;
                    }
                    case CurrentList.Sides:
                    {
                        return Sides;
                    }
                }

                return Beverages;
            }
        }


        public ItemManager()
        {
            Instance = this;
            Initialized?.Invoke(this, EventArgs.Empty);
            OrderQueue = new ObservableCollection<Item>();

            // add beverages here
            Beverages = new ObservableCollection<Item>();
            Beverages.Add(new Item("Water", 0f));
            Beverages.Add(new Item("Coffee w/ cream and sugar", 3.25f));
            Beverages.Add(new Item("Hot Chai", 4.25f));
            Beverages.Add(new Item("Iced Matcha", 3.25f));
            Beverages.Add(new Item("Hot Chocolate", 4.25f));
            Beverages.Add(new Item("Sweet Iced Tea", 2.25f));
            
            //add entrees here
            Entrees = new ObservableCollection<Item>();
            Entrees.Add(new Item("Turkey Sandwich", 8));
            Entrees.Add(new Item("Ham and Swiss Sandwich", 6.25f));
            Entrees.Add(new Item("Veggie Ban Mi Wrap", 7.50f));
            Entrees.Add(new Item("Caeser Salad", 5.25f));


            //add appetizers here
            Appetizers = new ObservableCollection<Item>();
            Appetizers.Add(new Item("6 Bagel Bites", 5.50f));
            Appetizers.Add(new Item("Mushroom and Feta Quiche", 6.75f));
            Appetizers.Add(new Item("Bacon and Greyure Quiche", 5.25f));
            Appetizers.Add(new Item("2 Maple Hashbrowns", 3.25f));
            Appetizers.Add(new Item("Everything Bagel", 2.50f));
            Appetizers.Add(new Item("Sprouted Grain Bagel", 2.50f));
            Appetizers.Add(new Item("Cinnamon Rasin Bagel", 2.50f));

            //add sides here
            Sides = new ObservableCollection<Item>();
            Sides.Add(new Item("Cream Cheese", .75f));
            Sides.Add(new Item("Starwberry Jam", .75f));
            Sides.Add(new Item("Apricot Jam", .75f));
            Sides.Add(new Item("Blueberry Jam", .75f));

            // add desserts
            Desserts = new ObservableCollection<Item>();
            Desserts.Add(new Item("Banana Nut Bread", 3.50f));
            Desserts.Add(new Item("Pumpkin Bread", 2.50f));
            Desserts.Add(new Item("Vanilla Bean Scone", 1.25f));
            Desserts.Add(new Item("Warm Blueberry Scone", 2.25f));
            Desserts.Add(new Item("Banana Nut Muffin", 2.50f));
            Desserts.Add(new Item("Blueberry Muffin", 2.50f));
            Desserts.Add(new Item("Chocolate Muffin", 2.50f));

        }

        public void ChangeList(CurrentList list)
        {
            CurrentMenuList = list;
            OnPropertyChanged(nameof(MenuList));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
