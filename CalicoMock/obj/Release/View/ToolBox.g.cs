﻿#pragma checksum "..\..\..\View\ToolBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B15F686410C6F497EF5DFFF8A97F46E6"
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


namespace CalicoMock.View {
    
    
    /// <summary>
    /// ToolBox
    /// </summary>
    public partial class ToolBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel editmode;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton cmdDraw;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton cmdErase;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton cmdEraseStroke;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton cmdSelect;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel lineThickness;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider BrushSizeSlider;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdUndo;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdRedo;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\ToolBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdClear;
        
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
            System.Uri resourceLocater = new System.Uri("/CalicoMock;component/view/toolbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ToolBox.xaml"
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
            
            #line 12 "..\..\..\View\ToolBox.xaml"
            ((CalicoMock.View.ToolBox)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\View\ToolBox.xaml"
            ((CalicoMock.View.ToolBox)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\View\ToolBox.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.editmode = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 5:
            this.cmdDraw = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\..\View\ToolBox.xaml"
            this.cmdDraw.Click += new System.Windows.RoutedEventHandler(this.cmdDraw_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdErase = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\..\View\ToolBox.xaml"
            this.cmdErase.Click += new System.Windows.RoutedEventHandler(this.cmdErase_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmdEraseStroke = ((System.Windows.Controls.RadioButton)(target));
            
            #line 36 "..\..\..\View\ToolBox.xaml"
            this.cmdEraseStroke.Click += new System.Windows.RoutedEventHandler(this.cmdEraseStroke_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmdSelect = ((System.Windows.Controls.RadioButton)(target));
            
            #line 44 "..\..\..\View\ToolBox.xaml"
            this.cmdSelect.Click += new System.Windows.RoutedEventHandler(this.cmdSelect_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lineThickness = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 10:
            
            #line 53 "..\..\..\View\ToolBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BrushSizeDown_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BrushSizeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 54 "..\..\..\View\ToolBox.xaml"
            this.BrushSizeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.BrushSizeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 55 "..\..\..\View\ToolBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BrushSizeUp_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.cmdUndo = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\View\ToolBox.xaml"
            this.cmdUndo.Click += new System.Windows.RoutedEventHandler(this.cmdUndo_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.cmdRedo = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\View\ToolBox.xaml"
            this.cmdRedo.Click += new System.Windows.RoutedEventHandler(this.cmdRedo_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.cmdClear = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\View\ToolBox.xaml"
            this.cmdClear.Click += new System.Windows.RoutedEventHandler(this.cmdClear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

