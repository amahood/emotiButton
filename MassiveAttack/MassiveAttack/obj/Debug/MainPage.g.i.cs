﻿#pragma checksum "G:\DevProjects\emotiButton\MassiveAttack\MassiveAttack\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B3DCD4FA959C7E534946EF2C39A1A394"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MassiveAttack;
using Microsoft.Phone.Controls;
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot Pivot;
        
        internal Microsoft.Phone.Controls.PivotItem Button;
        
        internal System.Windows.Controls.Button playButton;
        
        internal MassiveAttack.BigButton bigButton1;
        
        internal Microsoft.Phone.Controls.PivotItem Drawer;
        
        internal System.Windows.Controls.ListBox listBox1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MassiveAttack;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Pivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("Pivot")));
            this.Button = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Button")));
            this.playButton = ((System.Windows.Controls.Button)(this.FindName("playButton")));
            this.bigButton1 = ((MassiveAttack.BigButton)(this.FindName("bigButton1")));
            this.Drawer = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Drawer")));
            this.listBox1 = ((System.Windows.Controls.ListBox)(this.FindName("listBox1")));
        }
    }
}

