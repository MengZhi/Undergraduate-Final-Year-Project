﻿#pragma checksum "C:\Users\ZHI MENG\Documents\Visual Studio 2013\Projects\SmartAttendanceSystem\SmartAttendanceSystem\ChangePassword\Default.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2D065965D7ED47C22D5725D49DCB8A98"
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


namespace SmartAttendanceSystem.ChangePassword {
    
    
    public partial class Default : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.PasswordBox OldPassword;
        
        internal System.Windows.Controls.PasswordBox NewPassword;
        
        internal System.Windows.Controls.PasswordBox ReNewPassword;
        
        internal System.Windows.Controls.TextBlock ErrorMessage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SmartAttendanceSystem;component/ChangePassword/Default.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.OldPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("OldPassword")));
            this.NewPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("NewPassword")));
            this.ReNewPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("ReNewPassword")));
            this.ErrorMessage = ((System.Windows.Controls.TextBlock)(this.FindName("ErrorMessage")));
        }
    }
}

