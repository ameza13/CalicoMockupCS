   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5   	   E ACalicoMock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CalicoMock
CalicoMock 5   	   =#clr-namespace:CalicoMock.PropertiesCalicoMock.Properties 5   	       CalicoMock.View.EditorView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   9search,clr-namespace:UIControls;assembly=UIControls  5   	   'controlsclr-namespace:CalicoMock  5   	   4
properties#clr-namespace:CalicoMock.Properties  5   	   -   5          � Title$  Calico Redux��5   	   $
��1024��6   $
��1280��6,    � WindowState$ 	Maximized=�5	   	   .��5      � -   5        $��MainGrid��5       � DataContext$ 
_viewModel��6   
�������.+�5   
   �� $
��Auto=�6   $
��Auto=�5      $��Stretch=�5      $��Stretch=�5      .��5      � $��50q�5   B    J� SnapsToDevicePixels . ��5      �� $ CalicoMock.Properties.Settings   Default �� Source# Z  �� Path$ workingAreaHeight� �� Mode$ OneWay=���5      �� # Z $ workingAreaWidth�$ OneWay=�.+�5      �� $��1��6   $��2��6&   $��Center=�5      $��Center=�5      
�������$��3q�5      ��5      �� # Z $ workingAreaHeight�$ OneWay=���5      �� # Z $ workingAreaWidth�$ OneWay=� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       	   Color$	 DarkGray��6+   5"      �� 5#      -   5        $��icCanvas��5#      $��Center=�5,      $��Center=�5-      ��5$      �� # Z $ workingAreaHeight�$ OneWay=���5&      �� # Z $ workingAreaWidth�$ OneWay=�5.      5/      50      � 51   
   $��Stretch=�6   $��Stretch=�6-   .+�52      � $��Stretch=�56      $��Stretch=�61    . $��40q�6h   ��52      �� # Z $ workingAreaHeight�$ OneWay=���54      �� # Z $ workingAreaWidth�$ OneWay=�
 � RowDefinitions
 57      �� 58      $��* �6$   .+�5:      d� -   5        $��
cmdToolbox��5:      $��Right=�61   $	��Top=�6M   $��25q�6e   .��5;      �� $��..\Images\Toolbox.png��6    J� Opacity$	 0.9Q�6;   $
��None=�6I    �� BitmapScalingMode$ HighQuality=�6X   6�   5<      d� 5=      -   5        $��cmdInfo��5=      $��Right=�6.   $��Center=�6J   $��25q�6e   .��5>      �� $��..\Images\StarEmpty.png��6   $	 0.9Q�6=   $
��None=�6K   $ HighQuality=�6Z    J� RenderTransformOrigin$ 
1.25,1.281&�6�   6�   5?      � 5@      $��Right=�6   $��Bottom=�68   $��25q�6S   .+�5A      �� -   5        $��
cmdDetails��5A       � ToolTip$ Details��6H   $��40��6Z   |�.  .��5B      �� $��..\Images\Details.png��6    $	 0.9Q�6?   $
��None=�6M   $ HighQuality=�6\   6�   5C      �� 5D      -   5        $��cmdNew��5D      $	 New��6@   |�.  .��5E      �� $��..\Images\NewCanvas.png��6    $	 0.9Q�6A   $
��None=�6O   $ HighQuality=�6^   6�   5F      �� 5G      -   5        $��cmdClone��5G      $ Clone��6D   |�.  .��5H      �� $��..\Images\CloneCanvas.png��6    $	 0.9Q�6C   $
��None=�6Q   $ HighQuality=�6`   6�   5I      �� 5J      -	   5        $��cmdQuit��5J      $ Done Editing��6B   |�.  .��5K      �� $��..\Images\Done.png��6    $	 0.9Q�6<   $
��None=�6J   $ HighQuality=�6Y   6�   5L      �� 5M      -
   5        $��cmdRefreshKnowledge��5M      $ Refresh knowledge list��6Z   |�.  .��5N      �� $��..\Images\StarEmpty.png��6    $	 0.9Q�6A   $
��None=�6O   $ HighQuality=�6^   6�   5O      5P      5Q      5R      9� 5S   
   -   5        $��navFloatExpander��5S       9� ExpandDirection$
 Left=�5T      $��RightToLeft=�5U       9� 
IsExpanded .  . $
��Left=�5W      $��0,0,0,50q�5X      $	��200��6%   ��5Y      �� 5Z       �� 
TargetType" 9�6    �� Triggers 5[      P� 5\       P� Property �@9�
IsExpanded P� Value . . �5]      ��  �� Property � �� �� Value 5^   "   �� 5_   &    �� Color$ 	AliceBlue��66    �� Opacity$	 0.5Q�6H   5a      �� 5b       � ��$	 200��66   �� 5c       � ��
 �����6<   5d      P� 5e       �@9�
IsExpanded .  . �5f      ��  � ��
 ���� 6;   �� 5g       � ��$ 25��66   �� 5h       � ��
 ���� 6<   5i      5k      .��5m      � $��LeftToRight=�6   
�������
 5n      �� 5o      $
��Auto �6$   �� 5p      $
��Auto �6$   �� 5q      $
��Auto �6$   �� 5r      $
��Auto �6$   �� 5s      $��* �6$   �� 5t      $
��Auto �6$   .+�5v      �� -   5        $��lvKnowledge��5v      $��LeftToRight=�6.   
�������$��1q�6b    �� SelectionMode$ Single=�6v   $��0��6�   ��5w      �� 5x      " ��6    .�5y      -   5        5z      5|      �� 5}      -   5        $��	VSplitter��5}      $��0��60   $��1��6@   $
��Auto��6M   $��3��6Z    �� ResizeDirection$
 Rows=�6e   $��Stretch=�6}   $��Stretch=�6�   �� 5~      -   5        $��cboWSNameSelector��5~   (   $��2��6   $	��110��6A   $
��Left=�6M    �� SelectedItem 6h   �� $ SelectedWSName���5�      �� 5�      " ��6     �� BasedOn# [B��6C    5�      �� 5�   "    �� Binding 6.   ��  �� Value  6B   .a�5�   &   ��  � �� 5�   *   �� 5�   .    �� 
TargetType" ��6>   .R�5�   2   �� $��Stretch=�6<   {�.  6Z   5�   /   5�   '   5�   #   5�      5�      o� 5�      $��2��6   
������ $��Right=�6>   $��0,2,0,0q�6Z   .@�5�      m� $��0q�6   $ Sort Canvas List��6+   $��30��6F     m� Icon  5�      �� 5�      $��..\Images\Sort.png��6$   $
��None=�6@   $ HighQuality=�6O   6   .@�5�      m� -   5        $��sortAscending��5�   #   $��Sort Ascending��68   ! m� IsCheckable! .   5�      �� 5�   "   $��..\Images\Sort.png��6(   $
��None=�6D   $ HighQuality=�6S   6�   5�      m� 5�      -   5        $��sortDescending��5�   #   $��Sort Descending��69   ! .   5�      �� 5�   "   $��..\Images\SortDesc.png��6(   $
��None=�6H   6Y   5�      �� 5�      m� 5�      -   5        $��
sortByMenu��5�   #   $��Sort By��65   .@�5�      m� -   5        $
��Name��5�   '   ! . 
" � Tag$
" name��6H   6l   m� 5�      -   5        $��Created��5�   '   ! . $" created��6K   6r   m� 5�      -   5        $��Modified��5�   '   ! . $" modified��6L   6t   m� 5�      -   5        $��Creator��5�   '   ! . $
" user��6K   6o   5�      5�      m� 5�      -   5        $��
FilterMenu��5�      $��0q�61   $ Filter Canvas List��6=   $��30��6�   ��5�      �� 5�      .R�5�   "   �� 
�������6B   5�        5�      �� 5�      $��..\Images\Filter.png��6$   $
��None=�6B   6S   .@�5�      �� $��	Filter By��6$   |�.  65   �� 5�      m� 5�      -   5        $��	FavFilter��5�   #   $��	Favorites��64   ! .   5�      �� 5�   "   $��..\Images\StarEmpty.png��6(   $
��None=�6I   5�      �� 5�      m� 5�      $
��Tags��6#     5�      �� 5�   "   $��..\Images\Tags.png��6(   $
��None=�6D   6U   .@�5�      �� $	��200��6+   $
��Auto=�6;   .��5�   "   �� -   5        $��lbTagFilter��5�   *   $	��100��6d   $��0,5,0,0q�6p   ��6=   �� *allTagsChecked+��5�   &   �� 5�   *   .R�5�   .   �� -   5        ��5�   7   �� $	 Key�# d� 	IsChecked# 6�   �� $ Value�$ OneWay=�5�   +   5�   #   5�      5�      m� 5�      $
��User��6#     5�      �� 5�   "   $��..\Images\User.png��6(   $
��None=�6D   6U   .@�5�      �� $	��200��6+   $
��Auto=�6;   .��5�   "   �� -   5        $��lbUserFilter��5�   *   $	��100��6f   $��0,5,0,0q�6r   ��6>   �� *allUsersChecked+��5�   &   �� 5�   *   .R�5�   .   �� -   5        ��5�   7   �� $	 Key�# 6�   �� $ Value�$ OneWay=�5�   +   5�   #   5�      5�      5�      5�         UIControls.SearchTextBox  5�      -   5        $��	searchBox��5�   '   $��3��69   $��LeftToRight=�6F   $��25��6b   $   SearchEventTimeDelay$$ 0D�6�   �� 5�      -   5        $��lvCanvasList��5�   (   $��4��6   $��LeftToRight=�6<   
�������$��1q�6p   $ Single=�6�   ��6�   �� ��5�      �� 5�      .R�5�      A� % K� IsItemsHost% . $	��Top=�6=   $
��Left=�6U   & A� Columns$& 1��6p   5�      ��5�      �� 5�      ' �� DataType$' CCanvas��6'   .R�5�      �� ( �� Orientation$( Vertical=�6)   .+�5�   "   �� $��1q�6)   
���   �) �� CornerRadius$) 3,3,3,3��5�   )      ThumbnailNavBorder#��[  5�   )   ._�5�   &   � .+�5�   *   �� $��Center=�5�   0   $ HighQuality=�5�   0   ��5�   0   �� $ 	thumbnail���5�   0   �� * �� ElementName$* ItemHeightSlider��$ Value�  AspectRatioConverter+ �� 	Converter#+ [ ��5�   0   �� $* ItemHeightSlider��$ Value�5�   +   �� 5�   *   -   5        $��Right=�5�   1   $	��Top=�6M   $��Arial Unicode MS)�6�   .��5�   .   �� $��x��68   $��	2,-4,2,-1q�6A   ��5�   2   �� 5�   6   $ CornflowerBlue��6F   $
 0.75Q�6]   5�   /   ��5�   .   �� 5�   2   " ��68   # [" �6L    5�   6   �� 5�   :    6F   �� $* cboWSNameSelector��$ SelectedItem� All Canvases6�   .a�5�   >   ��  � y�$ Hidden=�6[   5�   ;   5�   3   5�   +   d� 5�   *   $
��Left=�67   $��Bottom=�6R   |�.  # 6   �� *
IsFavorite+��5�   .   �� 5�   2   " d�68   # ["�6R    5�   6   P� 5�   :    �@d�	IsChecked$
 trueY�6W   . �5   >   ��  � �� 5  B   �� 5  F   $��..\Images\StarFull.png��6L   5  ?   �� 5  >    � ��
 ���� 6[   �� 5  >    � ��
 ���� 6\   5  ;   P� 5  :    �@d�	IsChecked$ falseY�6W   . �5	  >   ��  � �� 5
  B   �� 5  F   $��..\Images\StarEmpty.png��6L   5  ?   5  ;   5  3   5  +   5  '   5  #   �� 5  "   $��Center=�6G     CanvasNavCaptionText#��[ 6d   $
��Wrap=�5  ,   , �� Padding$, 0,0,0,5q�6@   ��5  ,   �� $
 name���5  ,   �� $* ItemHeightSlider��$ Value�#+ [ 5  @   5     5     ��5     �� 5     " ��6    .�5     -    5        - �� 	Resources- 5     ��%�   (��       5  2   * SystemColors.HighlightBrushKey+)(�� %     5   2   *1/SystemColors.InactiveSelectionHighlightBrushKey+)�� 5  "   $ Transparent��6d   �� 5   "   $ Transparent��6u   5!     5"     5$     �� 5%     -!   5        $��ItemHeightSlider��5%     $��5��61   
�������$��1q�6V   . � Minimum$. 25Q�6j   / � Maximum$	/ 200Q�6w   $��Stretch=�6�   $	��100��6�   0 �� IsSnapToTickEnabled0 . 1 �� TickFrequency$1 5Q�6�   2 � Value$	2 100Q�6�   5&     5'     5(     5*     