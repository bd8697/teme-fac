﻿#pragma checksum "..\..\..\Views\ViewPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95D9B76EA8252A420A4B683606AE04FE44FD5FCA04165A0E4D659145E6603C70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Restaurant_MVP;
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


namespace Restaurant_MVP {
    
    
    /// <summary>
    /// ViewPage
    /// </summary>
    public partial class ViewPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\Views\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridTable;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridTable_meniuri;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Views\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshMenu;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Views\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshMenu_menu;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\ViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Restaurant_MVP;component/views/viewpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ViewPage.xaml"
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
            this.gridTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\Views\ViewPage.xaml"
            this.gridTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridTable_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridTable_meniuri = ((System.Windows.Controls.DataGrid)(target));
            
            #line 74 "..\..\..\Views\ViewPage.xaml"
            this.gridTable_meniuri.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridTable_meniuri_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.refreshMenu = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Views\ViewPage.xaml"
            this.refreshMenu.Click += new System.Windows.RoutedEventHandler(this.refreshBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.refreshMenu_menu = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\Views\ViewPage.xaml"
            this.refreshMenu_menu.Click += new System.Windows.RoutedEventHandler(this.refreshMenuBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\Views\ViewPage.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
