﻿#pragma checksum "C:\Users\ZHI MENG\Documents\Visual Studio 2013\Projects\SmartAttendanceSystem\SmartAttendanceSystem\ForgetPassword\Default.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A924C8FD330505B6BC5CAF1B3F645E14"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace SmartAttendanceSystem.ForgetPassword {
    
    
    public partial class Default : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox UserNumber;
        
        internal System.Windows.Controls.TextBox UserName;
        
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
        internal System.Windows.Controls.ListBox userListBox;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SmartAttendanceSystem;component/ForgetPassword/Default.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.UserNumber = ((System.Windows.Controls.TextBox)(this.FindName("UserNumber")));
            this.UserName = ((System.Windows.Controls.TextBox)(this.FindName("UserName")));
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(this.FindName("ErrorMessage")));
            this.userListBox = ((System.Windows.Controls.ListBox)(this.FindName("userListBox")));
        }
    }
}

