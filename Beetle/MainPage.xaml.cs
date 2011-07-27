using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Beetle.ViewModels;
using Microsoft.Phone.Controls;

namespace Beetle
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            var vm = this.DataContext as MainViewModel;
            if (vm.GameOver)
            {
                e.Cancel = true;
                vm.ResetGameCommand.Execute(null);
            }
            else
            {
                base.OnBackKeyPress(e);
            }
        }
    }
}