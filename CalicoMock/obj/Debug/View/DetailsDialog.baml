   M S B A M L   `   `   `  ����E  ACalicoMock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CalicoMock.UtilCalicoMock.Util  5   	   #    CalicoMock.View.DetailsDialog   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .utilclr-namespace:CalicoMock.Util     5   	     � Title$  Canvas Details��5   	   $	��189��6    $	��372��6-    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5      +   %CalicoMock.Util.ListToStringConverter   ListToStringConverter��%   &	          5   
   6%   5	      .��5
      � $��5,5,5,5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .��6   Name6#   �� 5   
   -   5        $��txtName��5      $��1��6!   ��61   �� *name+�� 5   
   $��1��6   .��6   Tags6#   �� 5   
   -   5        $��txtTags��5      $��1��6!   $��2��6.   ��6>   �� *tags+ �� 	Converter# [  6�   �� 5   
   $��2��6   .��6   Notes6$   �� 5   
   -   5        $��txtNotes��5      $��2��6"   $��1��6/    �� TextWrapping$
 Wrap=�6?    �� AcceptsReturn . ��6h   �� *
annotation+�� 5   
   -   5        $��cmdOK��5      $��3��6   $��1��6+   $��Right=�6O   $��	20,0,20,0q�6k   $��0,5,0,0q�6    �� 	IsDefault . $��1q�6�   
����d�.��6�   OK6�   5      5      