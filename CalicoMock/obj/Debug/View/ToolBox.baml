   M S B A M L   `   `   `  ����  
CalicoMock    CalicoMock.View.ToolBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  ToolBox��5   	   $	��190��6   $	��206��6&    � WindowStyle$
 none=�5   	    � WindowStartupLocation$ CenterOwner=�5   	    � Topmost .  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5
   	   
������ .��5      �� -   5        
������� �� CornerRadius$ 5,5,5,5��5   !    �� Padding$ 1q�68   
�������$��1q�6W   |�.  ._�5   
   � -   5        $��MainGrid��5       +� IsFocusScope . 	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      � .+�5      �� $��Toolbox��6   $��20��6+   
�������$��Stretch=�6N   6n   5      �� 5      $��1��6   $��Drawing Mode��6%   $��5, 0,5,0q�6;   .��5      � -   5        $��editmode��5      $��Center=�6,   .+�5      	� -   5        $��cmdDraw��5   F   #��[Bd�5   "   
 � ToolTip$

 Draw��5   "    	� 	GroupName$ EditMode��61   $��32��6k    d� 	IsChecked$
 TrueY�6v   .��5      �� $��..\Images\WSPencil.png��6    5      	� 5      -   5        $��cmdErase��5    G   #��[Bd�5   "   $
 Erase��5    "   $ EditMode��62   $��32��6n   .��5!      �� $��..\Images\WSErase.png��6    5"      	� 5#      -   5        $��cmdEraseStroke��5$   G   #��[Bd�5#   "   $
 Erase��5$   "   $ EditMode��62   $��32��6z   .��5%      �� $!��..\Images\WSEraseStroke.png��6    5&      	� 5+      -   5        $��	cmdSelect��5,   K   #��[Bd�5+   "   $
 	Highlight��5,   "   $ EditMode��66   $��32��6u   .��5-      �� $��..\Images\WSSelect.png��6    5.      5/      50      �� 51      $��2��6   $��Brush��6$   $��5,0,5,0q�63   .��52      � -	   5        $��lineThickness��52      .+�53      #  Xceed.Wpf.Toolkit.ColorPicker  -
   5        $��cboColor��53   '   $��50��67   $��3��6B      DisplayColorAndName .  6k   �� 54      $��30��6[   $��Center=�6f   $��Center=�6�   
���   �$��	10,0,10,0q�6�   ��6    ��  �� ElementName$ BrushSizeSlider�� �� Path$ Value�6�   �� 55      -   5        $��18(�55      .��6G   -6J   �� 56      -   5        $��BrushSizeSlider��56      $��50��64    � Minimum$ 1Q�6?    � Maximum$ 8Q�6K    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6r    � Value$ 2Q�6�   $��Center=�6�   6�   �� 57      -   5        $��18(�57      .��6E   +6H   58      59      �� 5:      $��3��6   $��Canvas��6$   $��5,0,5,0q�64   .��5;      � .+�5<      �� -   5        $��cmdUndo��5<   4   $��32��6   $��32��6)   $��0��6C   $��0q�6S   #��[" �6g   $

 Undo��6�   .��5=      �� $��..\Images\Undo.png��6    6>   5>      �� 5?      -   5        $��cmdRedo��5?   4   $��32��6   $��32��6)   $��1��6C   $��0q�6S   #��[" �6g   $

 Redo��6�   .��5@      �� $��..\Images\Redo.png��6    6?   5A      �� 5B      -   5        $��cmdClear��5B   4   $��32��6   $��50��6)   $��2��6D   $��Right=�6T   $��0q�6p   #��[" �6�   $
 Clear Canvas��6�   .��5C      �� $��..\Images\ClearCanvas.png��6    6E   5D      5E      5F      5G      5H      5I      