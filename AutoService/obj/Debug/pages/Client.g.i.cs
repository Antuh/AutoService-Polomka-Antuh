﻿#pragma checksum "..\..\..\pages\Client.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE771B814B5AE26AC6F2F42CF47051EF34704E3E285DDED6E9FDCAD3D95DC6CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoService.pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace AutoService.pages {
    
    
    /// <summary>
    /// Client
    /// </summary>
    public partial class Client : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtFullname;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSorting;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFilter;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtResultAmount;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAllAmount;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewClient;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditClient;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\pages\Client.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNewClient;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AutoService;component/pages/client.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\Client.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtFullname = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\pages\Client.xaml"
            this.txtSearch.SelectionChanged += new System.Windows.RoutedEventHandler(this.txtSearch_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbSorting = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\pages\Client.xaml"
            this.cmbSorting.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSorting_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\pages\Client.xaml"
            this.cmbFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbFilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtResultAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtAllAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.LViewClient = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.btnEditClient = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\pages\Client.xaml"
            this.btnEditClient.Click += new System.Windows.RoutedEventHandler(this.btnEditClient_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnAddNewClient = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\pages\Client.xaml"
            this.btnAddNewClient.Click += new System.Windows.RoutedEventHandler(this.btnAddNewClient_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

