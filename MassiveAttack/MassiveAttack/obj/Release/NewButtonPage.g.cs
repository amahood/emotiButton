﻿#pragma checksum "G:\DevProjects\emotiButton\MassiveAttack\MassiveAttack\NewButtonPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CA49642B1DF542B90D762664FC1B975A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Phone.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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
    
    
    public partial class NewButtonPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.StackPanel AddPanel;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.TextBox newText;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        internal Coding4Fun.Phone.Controls.ColorHexagonPicker chooseColor;
        
        internal System.Windows.Controls.TextBlock recordText;
        
        internal System.Windows.Controls.Button recordButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton buttonToAccessFromCodeBehind;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MassiveAttack;component/NewButtonPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.AddPanel = ((System.Windows.Controls.StackPanel)(this.FindName("AddPanel")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.newText = ((System.Windows.Controls.TextBox)(this.FindName("newText")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
            this.chooseColor = ((Coding4Fun.Phone.Controls.ColorHexagonPicker)(this.FindName("chooseColor")));
            this.recordText = ((System.Windows.Controls.TextBlock)(this.FindName("recordText")));
            this.recordButton = ((System.Windows.Controls.Button)(this.FindName("recordButton")));
            this.buttonToAccessFromCodeBehind = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("buttonToAccessFromCodeBehind")));
        }
    }
}

