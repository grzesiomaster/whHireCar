using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace hireCarWpf
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Rent> story = new ObservableCollection<Rent>();
        private const string apiRoute = "/api/HireStory/";
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
           InitializeComponent();
          
           client = new HttpClient()
           {
               BaseAddress = new Uri("https://localhost:44311")
           };
        }

        private async void btnApi_Click(object sender, RoutedEventArgs e)
        {
            await GetStory();
        }

        private async Task GetStory()
        {
            var response = await client.GetAsync(apiRoute);
            var content = await response.Content.ReadAsAsync<IEnumerable<Rent>>();
            story.Clear();
            lstBx.Items.Clear();
            for (int i = 0; i < content.Count(); i++)
            {
                story.Add(content.ElementAt(i));
                var it = story.ElementAt(i);
                lstBx.Items.Add(it.HiredCar.Model + ", " + it.HiringCustomer.Name + ", " + it.HireDate + "->" + it.ReturnDate);
            }
        }
        public class Brand
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Car
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public string Model { get; set; }
            public virtual Brand Brand { get; set; }
            public bool IsHired { get; set; }
        }
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Rent
        {
            public int Id { get; set; }
            public DateTime HireDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public virtual Customer HiringCustomer { get; set; }
            public virtual Car HiredCar { get; set; }
        }
    }
}
