﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20ABDF0D58800D412DFA05AAD0871582F629DC89"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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
using TaskManagement;
using WpfControlLibrary.WPFControls;


namespace TaskManagement {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 184 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newTaskBtn;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button onTaskBtn;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finishedBtn;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button canceledBtn;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minBtn;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeBtn;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroller;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel container;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskManagement;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.newTaskBtn = ((System.Windows.Controls.Button)(target));
            
            #line 184 "..\..\MainWindow.xaml"
            this.newTaskBtn.Click += new System.Windows.RoutedEventHandler(this.newTaskBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.onTaskBtn = ((System.Windows.Controls.Button)(target));
            
            #line 191 "..\..\MainWindow.xaml"
            this.onTaskBtn.Click += new System.Windows.RoutedEventHandler(this.onTaskBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.finishedBtn = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\MainWindow.xaml"
            this.finishedBtn.Click += new System.Windows.RoutedEventHandler(this.finishedBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.canceledBtn = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\MainWindow.xaml"
            this.canceledBtn.Click += new System.Windows.RoutedEventHandler(this.canceledBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.minBtn = ((System.Windows.Controls.Button)(target));
            
            #line 213 "..\..\MainWindow.xaml"
            this.minBtn.Click += new System.Windows.RoutedEventHandler(this.closeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.closeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 214 "..\..\MainWindow.xaml"
            this.closeBtn.Click += new System.Windows.RoutedEventHandler(this.minBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.scroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 8:
            this.container = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

