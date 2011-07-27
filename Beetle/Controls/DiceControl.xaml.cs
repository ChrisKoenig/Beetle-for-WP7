using System;
using System.Windows;
using System.Windows.Controls;
using Beetle.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace Beetle.Controls
{
    public partial class DiceControl : UserControl
    {
        public DiceControl()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        /// <summary>
        /// The <see cref="CurrentValue" /> dependency property's name.
        /// </summary>
        public const string CurrentValuePropertyName = "CurrentValue";

        /// <summary>
        /// Gets or sets the value of the <see cref="CurrentValue" />
        /// property. This is a dependency property.
        /// </summary>
        public int? CurrentValue
        {
            get
            {
                return (int?)GetValue(CurrentValueProperty);
            }
            set
            {
                SetValue(CurrentValueProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="CurrentValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register(
            CurrentValuePropertyName,
            typeof(int?),
            typeof(DiceControl),
            new PropertyMetadata(0));
    }
}