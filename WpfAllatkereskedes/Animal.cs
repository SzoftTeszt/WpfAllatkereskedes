using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAllatkereskedes
{
    public class Animal : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                CicaMica();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; CicaMica(); }
        }

        private string species;

        public string Species
        {
            get { return species; }
            set { species = value; CicaMica(); }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; CicaMica(); }
        }

        public Animal(string name, string species, int price)
        {
            Name = name;
            Species = species;
            Price = price;
        } 
        public Animal()
        {          
        }

        public override string? ToString()
        {
            return Name != null ? $"{Species} - {Name}; ({Price}$)" : "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void CicaMica([CallerMemberName]string propertyName=null) { 
            if (PropertyChanged !=null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
