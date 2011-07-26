using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Beetle.Controls
{
    public partial class Die : UserControl
    {
        public int Size { get; set; }

        public int Value { get; set; }

        public Die()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                //this.DataContext = new { Size = this.Size, Value = this.Value };
                DrawPips();
            };
        }

        private void DrawPips()
        {
            PipR1C1.Visibility = Value >= 4 ? Visibility.Visible : Visibility.Collapsed;
            PipR1C2.Visibility = Visibility.Collapsed;
            PipR1C3.Visibility = Value >= 3 ? Visibility.Visible : Visibility.Collapsed;

            PipR2C1.Visibility = Value == 2 || Value == 6 ? Visibility.Visible : Visibility.Collapsed;
            PipR2C2.Visibility = Value == 1 || Value == 3 || Value == 5 ? Visibility.Visible : Visibility.Collapsed;
            PipR2C3.Visibility = Value == 2 || Value == 6 ? Visibility.Visible : Visibility.Collapsed;

            PipR3C1.Visibility = Value >= 3 ? Visibility.Visible : Visibility.Collapsed;
            PipR3C2.Visibility = Visibility.Collapsed;
            PipR3C3.Visibility = Value >= 4 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}