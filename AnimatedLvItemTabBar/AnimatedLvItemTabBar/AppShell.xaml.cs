using System;
using System.Collections.Generic;
using AnimatedLvItemTabBar.ViewModels;
using AnimatedLvItemTabBar.Views;
using Xamarin.Forms;

namespace AnimatedLvItemTabBar
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
