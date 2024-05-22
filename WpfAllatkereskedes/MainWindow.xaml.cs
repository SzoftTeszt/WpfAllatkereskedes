using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAllatkereskedes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public ObservableCollection<Animal> Allatok;
        public AnimalContext db;
        public MainWindow()
        {
            InitializeComponent();
            Allatok= new ObservableCollection<Animal>();
            db = new AnimalContext();
            //Init();
            ReflesAnimals();
            lbAllatok.ItemsSource = Allatok;
            spInput.DataContext = Allatok;
        }
        private void Init() {
            db.Animals.Add(new Animal("Ópium", "Macska", 70));
            db.Animals.Add(new Animal("Bodri", "Kutya", 100));
            db.SaveChanges();
        }

        private void ReflesAnimals() {
            Allatok.Clear();
            if (db.Animals.Any())
                foreach (var item in db.Animals)
                            Allatok.Add((Animal)item);
            else Allatok.Add(new Animal());
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Animal allat = lbAllatok.SelectedItem as Animal;

            if (allat.Name!=null)
            {
                allat.Id = 0;
                db.Animals.Add(allat);
                db.SaveChanges();

                ReflesAnimals();
                lbAllatok.SelectedItem = allat;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Animal allat = lbAllatok.SelectedItem as Animal;
            if (allat.Name != null)
            {              
                db.Animals.Update(allat);
                db.SaveChanges();
                ReflesAnimals();
                lbAllatok.SelectedItem = allat;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Animal allat = lbAllatok.SelectedItem as Animal;
            if (allat != null && allat.Id!=0)
            {
                int index = lbAllatok.SelectedIndex;
                db.Animals.Remove(allat);
                db.SaveChanges();
                ReflesAnimals();
                lbAllatok.SelectedIndex= index<lbAllatok.Items.Count?index:lbAllatok.Items.Count-1;
            }
        }
    }
}
