using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using whHireCar.Common;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace whHireCar.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Customer> persons = new ObservableCollection<Customer>();
        private const string apiRoute = "/api/Customers/";
        private HttpClient client;

        private Customer personToPost = new Customer();
        public MainPage()
        {
            this.InitializeComponent();
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:49833")
            };
        }

        private async Task GetPersons()
        {
            var response = await client.GetAsync(apiRoute);
            var content = await response.Content.ReadAsAsync<IEnumerable<Customer>>();

            persons.Clear();
            lstBx.Items.Clear();
            foreach (var it in content)
            {
                persons.Add(it);
                lstBx.Items.Add(it.Name);
            }
        }

        private async void ButtonGet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await GetPersons();
            }
            catch (Exception ex)
            {
                await DisplayMessage(ex.Message);
            }
        }


        private async Task DisplayMessage(string message)
        {
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }

        

        //public class Brand
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
        //public class Car
        //{
        //    public int Id { get; set; }
        //    public string Number { get; set; }
        //    public string Model { get; set; }
        //    public virtual Brand Brand { get; set; }
        //    public bool IsHired { get; set; }
        //}
        //public class CustomerX
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
        //public class Hire
        //{
        //    public int Id { get; set; }
        //    public DateTime HireDate { get; set; }
        //    public DateTime? ReturnDate { get; set; }
        //    public virtual Customer HiringCustomer { get; set; }
        //    public virtual Car HiredCar { get; set; }
        //}


    }
}
