using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnimatedLvItemTabBar.Services;
using AnimatedLvItemTabBar.Views;

namespace AnimatedLvItemTabBar
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
