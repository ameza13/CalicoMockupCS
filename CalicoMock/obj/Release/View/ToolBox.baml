   M S B A M L   `   `   `  ����   
CalicoMock    CalicoMock.View.ToolBox   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     -     � Title$  ToolBox��$	��190��$	��206�� � WindowStyle$
 none=� � WindowStartupLocation$ CenterOwner=� � Topmost .  � AllowsTransparency .  � 
ResizeMode$ NoResize=�
������ .���� -   
������� �� CornerRadius$ 5,5,5,5�� �� Padding$ 1q�
�������$��1q�|�.  ._�� -   $��MainGrid�� +� IsFocusScope . 	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�� .+��� $��Toolbox��$��20��
�������$��Stretch=��� $��1��$��Drawing Mode��$��5, 0,5,0q�.��� -   $��editmode��$��Center=�.+�	� -   $��cmdDraw��#��[Bd�
 � ToolTip$

 Draw�� 	� 	GroupName$ EditMode��$��32�� d� 	IsChecked$
 TrueY�.���� $��..\Images\WSPencil.png��	� -   $��cmdErase��#��[Bd�$
 Erase��$ EditMode��$��32��.���� $��..\Images\WSErase.png��	� -   $��cmdEraseStroke��#��[Bd�$
 Erase��$ EditMode��$��32��.���� $!��..\Images\WSEraseStroke.png��	� -   $��	cmdSelect��#��[Bd�$
 	Highlight��$ EditMode��$��32��.���� $��..\Images\WSSelect.png���� $��2��$��Brush��$��5,0,5,0q�.��� -	   $��lineThickness��.+��� $��30��$��Center=�$��Center=�
���   �$��	10,0,10,0q�����  �� ElementName$ BrushSizeSlider�� �� Path$ Value��� -
   $��18(�.��-�� -   $��BrushSizeSlider��$��50�� � Minimum$ 1Q� � Maximum$ 8Q� �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q� � Value$ 2Q�$��Center=��� -   $��18(�.��+�� $��3��$��Canvas��$��5,0,5,0q�.��� .+��� -   $��cmdUndo��$��32��$��32��$��0��$��0q�#��[" �$

 Undo��.���� $��..\Images\Undo.png���� -   $��cmdRedo��$��32��$��32��$��1��$��0q�#��[" �$

 Redo��.���� $��..\Images\Redo.png���� -   $��cmdClear��$��32��$��50��$��2��$��Right=�$��0q�#��[" �$
 Clear Canvas��.���� $��..\Images\ClearCanvas.png��