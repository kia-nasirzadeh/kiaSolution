﻿#pragma checksum "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B49D54A4101B46C84C405AE57340779386F0C1EE"
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
using WpfApp1.FlashCardApp;
using WpfApp1.FlashCardApp.UserControls;


namespace WpfApp1.FlashCardApp {
    
    
    /// <summary>
    /// FlashCardEdit
    /// </summary>
    public partial class FlashCardEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label datesLabel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox questionLabel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox answerLabel;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid timeLineLabel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.FlashCardApp.UserControls.TimeLine userControlsTimeLine;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KiaSolution;component/flashcardapp/pages/flashcardedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.datesLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.questionLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.answerLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.timeLineLabel = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.userControlsTimeLine = ((WpfApp1.FlashCardApp.UserControls.TimeLine)(target));
            return;
            case 6:
            this.saveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
            this.saveBtn.Click += new System.Windows.RoutedEventHandler(this.saveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\..\FlashCardApp\Pages\FlashCardEdit.xaml"
            this.cancelBtn.Click += new System.Windows.RoutedEventHandler(this.cancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

