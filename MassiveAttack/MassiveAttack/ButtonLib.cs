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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MassiveAttack
{
    public class ButtonLib
    {
        public DefaultLib defaultButtons = new DefaultLib();
        public ObservableCollection<ButtonEntity> masterArray = new ObservableCollection<ButtonEntity>();
  
        public ButtonLib()
        {
            masterArray.Add(defaultButtons.Default1);
            masterArray.Add(defaultButtons.Default2);
            masterArray.Add(defaultButtons.Default3);
            masterArray.Add(defaultButtons.Default4);
        }

        public void AddNewButton(ButtonEntity newButton)
        {
            masterArray.Add(newButton);
        }



    }
}
