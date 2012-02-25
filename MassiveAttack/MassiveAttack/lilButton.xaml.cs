using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace MassiveAttack
{
    public partial class lilButton : UserControl
    {
        public bool isSelected = false;

        public lilButton()
        {
            InitializeComponent();
            this.buttonImage.Source = new BitmapImage(new Uri("/Images/buttonoutline.jpg", UriKind.Relative));
            this.buttonBorder.Visibility = Visibility.Collapsed;
            this.buttonLabel.Text = setLabel(this.buttonText.Text); 
            this.buttonLabel.Visibility = Visibility.Collapsed;
        }

        //Set label method (verify if length is over a certain amount, then chop and do...
        public string setLabel(string newText)
        {
            if (newText.Length > 9)
                return (newText.Substring(0, 9) + "...");
            else
                return newText;
        }

    }
}
