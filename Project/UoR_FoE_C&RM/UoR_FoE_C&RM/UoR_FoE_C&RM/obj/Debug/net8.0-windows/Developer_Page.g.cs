﻿#pragma checksum "..\..\..\Developer_Page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CA8C996A8579C0B9ABBAA1422AC8C52B57E0B669"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TrackUrRequest.pages {
    
    
    /// <summary>
    /// Developer_PageWindow
    /// </summary>
    public partial class Developer_PageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserID;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddUser;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveUser;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDisplayUsers;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Developer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstUsers;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UoR_FoE_C&RM;component/developer_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Developer_Page.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtUserID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.btnAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Developer_Page.xaml"
            this.btnAddUser.Click += new System.Windows.RoutedEventHandler(this.btnAddUser_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnRemoveUser = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Developer_Page.xaml"
            this.btnRemoveUser.Click += new System.Windows.RoutedEventHandler(this.btnRemoveUser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDisplayUsers = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Developer_Page.xaml"
            this.btnDisplayUsers.Click += new System.Windows.RoutedEventHandler(this.btnDisplayUsers_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Developer_Page.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lstUsers = ((System.Windows.Controls.ListBox)(target));
            
            #line 63 "..\..\..\Developer_Page.xaml"
            this.lstUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

