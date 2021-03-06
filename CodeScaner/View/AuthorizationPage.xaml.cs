﻿using CodeScaner.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            this.Title = "Авторизация";
            InitializeComponent();
            this.BindingContext = new AuthorizationVM(this.Navigation);
        }
    }
}