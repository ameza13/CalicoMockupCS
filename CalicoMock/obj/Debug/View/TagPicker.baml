   M S B A M L   `   `   `  ����  
CalicoMock    CalicoMock.View.TagPicker   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	TagPicker��5   	   $	��300��6   $	��300��6(   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   .+�5   
   �� .��6   Existing tags:6    �� 5   
   -   5        $��lbTags��5      $��1��6   $��
10,0,10,10q�6-    �� SelectionMode$ Multiple=�6A   ��5      �� 5      .R�5      �� ��6   ��  d� 	IsChecked 63   ��  �� Path$ 
IsSelected� �� RelativeSource ��  �� AncestorType" ��5      5      � 5   
   $��2��6   $��Stretch=�6   $��	10,0,10,0q�6:    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   .��6$   Custom Tags:62   �� 5      -   5        $��txtCustomTags��5   &   $��1��6   6&   �� 5      -   5        $��
cmdAddTags��5   %   $��2��6   $��Right=�67   .��6l   Add6q   5      �� 5   
   -   5        $��cmdOK��5   :   $��3��6   $��Right=�6   $��0,20,5,5q�6G   .��6m   Done6s   5      5       