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
        public delegate void NewActiveHandler(object sender, NewActiveHandlerArgs e);
        public event NewActiveHandler Active;

        public PressVM()
        {
        }

        protected virtual void OnChanged(NewActiveHandlerArgs e)
        {
            Active(this, e);
        }

        public void setActiveButton(ButtonEntity incomingButton, bool deletedButton)
        {
            activeButton = incomingButton;
            NewActiveHandlerArgs testArgs = new NewActiveHandlerArgs(deletedButton); //Take out here if not work          
            OnChanged(testArgs);
        }


        public class NewActiveHandlerArgs : EventArgs
        {
            public readonly bool wasDeleted;

            public NewActiveHandlerArgs(bool incomingDel)
            {
                wasDeleted = incomingDel;
            }
        }
    }
}
