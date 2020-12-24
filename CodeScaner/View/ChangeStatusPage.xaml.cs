﻿using CodeScaner.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeStatusPage : ContentPage
    {
        public ChangeStatusPage(string barcode = "")
        {
            this.Title = "Обновление статуса посылки";
            InitializeComponent();
            this.BindingContext = new ChangeStatusVM(this.Navigation, barcode);
        }

        private void StatusChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                string status = (string)((RadioButton)sender).Value;
                ((ChangeStatusVM)this.BindingContext).Status = status;
                otherTxt.IsVisible = (status == "other");
            }
            catch (Exception)
            {

            }
        }
    }
}