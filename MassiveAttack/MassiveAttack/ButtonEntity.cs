using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace MassiveAttack
{
    public class ButtonEntity
    {

        public string incomingType {get; set;}
        public string buttonText { get; set; }
        public string buttonAudioUri { get; set; }
        public string colorString { get; set; }
        public bool isDefault { get; set; }
        public SolidColorBrush buttonColor = new SolidColorBrush();


        public ButtonEntity(string ButtonType)
        {
            incomingType = ButtonType;

            if (incomingType == "Standard")
            {
                buttonText = "easy";
                buttonAudioUri = "easy.wav";
                buttonColor.Color = Colors.Red;
                isDefault = true;
                colorString = buttonColor.Color.ToString();
            }
        }



    }
}
