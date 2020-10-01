using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AnimatedLvItemTabBar.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        public Command ReloadCmd => new Command(() =>
        {

            Items.Clear();
            Items.Add(new ItemModel()
            {
                Name = GenerateRandomString(),
                Addresse = GenerateRandomString(),
                Type = GenerateRandomString(),
                Index = Items.Count + 1,
            }) ;
            Items.Add(new ItemModel()
            {
                Name = GenerateRandomString(),
                Addresse = GenerateRandomString(),
                Type = GenerateRandomString(),
                Index = Items.Count + 1,
            }); Items.Add(new ItemModel()
            {
                Name = GenerateRandomString(),
                Addresse = GenerateRandomString(),
                Type = GenerateRandomString(),
                Index = Items.Count + 1,
            });
        });
        public ObservableCollection<ItemModel> Items { get; set; } = new ObservableCollection<ItemModel>()
        {

        };

        public string GenerateRandomString()
        {
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < 7; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }

        public class ItemModel
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Addresse { get; set; }
            public int Index { get; set; }
        }
    }
}