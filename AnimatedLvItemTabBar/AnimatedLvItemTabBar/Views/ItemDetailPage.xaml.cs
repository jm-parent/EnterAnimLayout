﻿using System.ComponentModel;
using Xamarin.Forms;
using AnimatedLvItemTabBar.ViewModels;

namespace AnimatedLvItemTabBar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}