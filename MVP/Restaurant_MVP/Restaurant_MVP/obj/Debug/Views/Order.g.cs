﻿#pragma checksum "..\..\..\Views\Order.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A7EC7275B2B17B52982EC211F4CA911AF1C5927215F6372F6BE51769183C039"
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
    /// Order
    /// </summary>
    public partial class Order : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridTableMenu;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orderTable;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orderTableMenu;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshMenu;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridTable;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMenu;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMenu_menu;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button order;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\Views\Order.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Restaurant_MVP;component/views/order.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Order.xaml"
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
            this.gridTableMenu = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\..\Views\Order.xaml"
            this.gridTableMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridTableMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.orderTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 106 "..\..\..\Views\Order.xaml"
            this.orderTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.orderTable_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.orderTableMenu = ((System.Windows.Controls.DataGrid)(target));
            
            #line 123 "..\..\..\Views\Order.xaml"
            this.orderTableMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.orderTableMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.refreshMenu = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Views\Order.xaml"
            this.refreshMenu.Click += new System.Windows.RoutedEventHandler(this.refreshBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 153 "..\..\..\Views\Order.xaml"
            this.gridTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridTable_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addMenu = ((System.Windows.Controls.Button)(target));
            
            #line 164 "..\..\..\Views\Order.xaml"
            this.addMenu.Click += new System.Windows.RoutedEventHandler(this.addBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.addMenu_menu = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\Views\Order.xaml"
            this.addMenu_menu.Click += new System.Windows.RoutedEventHandler(this.addMenuBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.order = ((System.Windows.Controls.Button)(target));
            
            #line 188 "..\..\..\Views\Order.xaml"
            this.order.Click += new System.Windows.RoutedEventHandler(this.orderBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\Views\Order.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
