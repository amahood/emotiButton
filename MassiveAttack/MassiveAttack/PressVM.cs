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

namespace MassiveAttack
{
    public class PressVM
    {
        public ButtonEntity activeButton = new ButtonEntity("Standard");
        public delegate void NewActiveHandler(object sender, EventArgs e);
        public event NewActiveHandler Active;

        public PressVM()
        {
        }

        protected virtual void OnChanged(EventArgs e)
        {
            Active(this, e);
        }

        public void setActiveButton(ButtonEntity incomingButton)
        {
            activeButton = incomingButton;
            OnChanged(EventArgs.Empty);
        }

    }
}
