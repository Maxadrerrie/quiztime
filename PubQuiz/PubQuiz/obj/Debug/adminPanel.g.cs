﻿#pragma checksum "..\..\adminPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4898CEC2BF39BBC7ACC1D37D922D7785C4765253FCE81A9E48BABDD95128EC16"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PubQuiz;
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


namespace PubQuiz {
    
    
    /// <summary>
    /// adminPanel
    /// </summary>
    public partial class adminPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gControlPanel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQuestionCount;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPause;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowAwnser;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartQuiz;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEndQuiz;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbAutoNext;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\adminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrevious;
        
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
            System.Uri resourceLocater = new System.Uri("/PubQuiz;component/adminpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\adminPanel.xaml"
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
            this.gControlPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lblQuestionCount = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\adminPanel.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.volgendeBtn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPause = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\adminPanel.xaml"
            this.btnPause.Click += new System.Windows.RoutedEventHandler(this.btnPause_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnShowAwnser = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\adminPanel.xaml"
            this.btnShowAwnser.Click += new System.Windows.RoutedEventHandler(this.btnShowAwnser_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnStartQuiz = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\adminPanel.xaml"
            this.btnStartQuiz.Click += new System.Windows.RoutedEventHandler(this.btnStartQuiz_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEndQuiz = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\adminPanel.xaml"
            this.btnEndQuiz.Click += new System.Windows.RoutedEventHandler(this.eindeQuiz);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cbAutoNext = ((System.Windows.Controls.CheckBox)(target));
            
            #line 77 "..\..\adminPanel.xaml"
            this.cbAutoNext.Click += new System.Windows.RoutedEventHandler(this.cbAutoNext_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnPrevious = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\adminPanel.xaml"
            this.btnPrevious.Click += new System.Windows.RoutedEventHandler(this.btnPrevious_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

