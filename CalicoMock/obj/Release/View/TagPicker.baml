   M S B A M L   `   `   `  ����   
CalicoMock    CalicoMock.View.TagPicker   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  	TagPicker��$	��300��$	��300��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� .��Existing tags:�� -   $��lbTags��$��1��$��
10,0,10,10q� �� SelectionMode$ Multiple=����� .R��� ����  d� 	IsChecked ��  �� Path$ 
IsSelected� �� RelativeSource ��  �� AncestorType" ��� $��2��$��Stretch=�$��	10,0,10,0q� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.��Custom Tags:�� -   $��txtCustomTags��$��1���� -   $��
cmdAddTags��$��2��$��Right=�.��Add�� -   $��cmdOK��$��3��$��Right=�$��0,20,5,5q�.��Done