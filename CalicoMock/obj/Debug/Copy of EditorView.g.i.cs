﻿#pragma checksum "..\..\Copy of EditorView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CDFFEB2FFF0D3E212611CCFF10EEB0C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CalicoMock;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace CalicoMock {
    
    
    /// <summary>
    /// EditorView
    /// </summary>
    public partial class EditorView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.InkCanvas icCanvas;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton cmdToolbox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdDetails;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdNew;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdClone;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Copy of EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdQuit;
        
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
            System.Uri resourceLocater = new System.Uri("/CalicoMock;component/copy%20of%20editorview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Copy of EditorView.xaml"
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
            
            #line 7 "..\..\Copy of EditorView.xaml"
            ((CalicoMock.EditorView)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Copy of EditorView.xaml"
            ((CalicoMock.EditorView)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Copy of EditorView.xaml"
            ((CalicoMock.EditorView)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.icCanvas = ((System.Windows.Controls.InkCanvas)(target));
            
            #line 23 "..\..\Copy of EditorView.xaml"
            this.icCanvas.SelectionChanged += new System.EventHandler(this.inkCanvas_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 24 "..\..\Copy of EditorView.xaml"
            this.icCanvas.StrokeCollected += new System.Windows.Controls.InkCanvasStrokeCollectedEventHandler(this.inkCanvas_StrokeCollected);
            
            #line default
            #line hidden
            
            #line 25 "..\..\Copy of EditorView.xaml"
            this.icCanvas.StrokeErasing += new System.Windows.Controls.InkCanvasStrokeErasingEventHandler(this.inkCanvas_StrokeErasing);
            
            #line default
            #line hidden
            
            #line 26 "..\..\Copy of EditorView.xaml"
            this.icCanvas.SelectionMoved += new System.EventHandler(this.inkCanvas_SelectionMoved);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdToolbox = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 33 "..\..\Copy of EditorView.xaml"
            this.cmdToolbox.Checked += new System.Windows.RoutedEventHandler(this.cmdToolbox_Checked);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Copy of EditorView.xaml"
            this.cmdToolbox.Unchecked += new System.Windows.RoutedEventHandler(this.cmdToolbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmdDetails = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Copy of EditorView.xaml"
            this.cmdDetails.Click += new System.Windows.RoutedEventHandler(this.cmdDetails_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdNew = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Copy of EditorView.xaml"
            this.cmdNew.Click += new System.Windows.RoutedEventHandler(this.cmdNew_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmdClone = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Copy of EditorView.xaml"
            this.cmdClone.Click += new System.Windows.RoutedEventHandler(this.cmdClone_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmdQuit = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Copy of EditorView.xaml"
            this.cmdQuit.Click += new System.Windows.RoutedEventHandler(this.cmdQuit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

