﻿#pragma checksum "G:\DevProjects\emotiButton\MassiveAttack\MassiveAttack\BigButton.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "135A7D1A18E757C4C7B48D5BB4D628C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MassiveAttack {
    
    
    public partial class BigButton : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid ButtonGrid;
        
        internal System.Windows.Controls.Image buttonImage;
        
        internal System.Windows.Shapes.Ellipse buttonFace;
        
        internal System.Windows.Controls.TextBlock buttonText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MassiveAttack;component/BigButton.xaml", System.UriKind.Relative));
            this.ButtonGrid = ((System.Windows.Controls.Grid)(this.FindName("ButtonGrid")));
            this.buttonImage = ((System.Windows.Controls.Image)(this.FindName("buttonImage")));
            this.buttonFace = ((System.Windows.Shapes.Ellipse)(this.FindName("buttonFace")));
            this.buttonText = ((System.Windows.Controls.TextBlock)(this.FindName("buttonText")));
        }
    }
}

