using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using whHireCar.Common;

namespace hireCarWpf
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Hire> story = new ObservableCollection<Hire>();
        private const string apiRoute = "/api/HireStory/";
        HttpClient client;
        public MainWindow()
        {
           InitializeComponent();
          
           client = new HttpClient()
           {
               BaseAddress = new Uri("http://localhost:49833")
           };
        }

        private async void btnApi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await GetStory();                
            }
            catch (Exception ex)
            {
               // await DisplayMessage(ex.Message);
            }

        }

        private async Task GetStory()
        {
            var response = await client.GetAsync(apiRoute);
            var content = await response.Content.ReadAsAsync<IEnumerable<Hire>>();
            story.Clear();
            lstBx.Items.Clear();
            for (int i = 0; i < content.Count(); i++)
            {
                story.Add(content.ElementAt(i));
                var it = story.ElementAt(i);
                lstBx.Items.Add(it.HiredCar.Model + ", " + it.HiringCustomer.Name + ", " + it.HireDate + "->" + it.ReturnDate);
            }
        }
    }
}
