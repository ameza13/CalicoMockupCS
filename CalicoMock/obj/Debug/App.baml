   M S B A M L   `   `   `  ����E  ACalicoMock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CalicoMock.UtilCalicoMock.Util  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5      =#clr-namespace:CalicoMock.PropertiesCalicoMock.Properties  5          CalicoMock.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .utilclr-namespace:CalicoMock.Util     5      ?search,clr-namespace:UIControls;assembly=UIControls     5      :
properties#clr-namespace:CalicoMock.Properties     5        �� 	Resources  5         ClearCanvasIcon �� 	UriSource �� 
TargetType �� BasedOn �� Property �� Value  CanvasCaptionText �� Triggers �� Binding �� Value3  -System.Windows.Media.Effects.DropShadowEffect	   Color
   ShadowDepth   Opacity   
BlurRadius  CanvasNavCaptionText �� RelativeSource �� Mode �� AncestorType �� Path  ThumbnailBaseBorder  ThumbnailWSBorder  ThumbnailNavBorder+   %CalicoMock.Util.ListToStringConverter  ListToStringConverter*  $CalicoMock.Util.AspectRatioConverter  AspectRatioConverter&   CalicoMock.Util.ProductConverter  ProductConverter&   CalicoMock.Util.PercentConverter 	 PercentConverter%  CalicoMock.Util.ColumnConverter 
 ColumnConverter,  &CalicoMock.Util.ScrollPaddingConverter  ScrollPaddingConverter  	SlateBlue  PrimarySkinColor �� ResourceKey��%�  &	        '�� 0     7 �'d� |     7�'�� �     7�&	 �     7��&	 X    7��&	 �    &	 �    &	 	    &	 W    &	 j    &	 }    &		 �    &	
 �    &	 �    &	 �    0�� 5�   
   $ 	SlateBlue��62   1�� 5	   
   $ Images/ClearCanvas.png?�6.   �� 5   
   " ��6   8   .�5      ��  � ��$ 0q�60   5      �� 5   
   " d�6   8   .�5      ��  � ��$ 0q�60   5      �� 5   
   " ��6   8   6&   �� 5   
   8   " ��6>    5      �� 5       6   �� *
IsSelected+ true6=   .a�5      ��  �@J�Effect 5        5      #	 � ��5   !   $
 0Q�5   !   $ 1Q�61   $ 5Q�5   !   5      5      �� 5       6   �� *MatchesFilter+	 false6@   .a�5       ��  �@J�Opacity$	 0.5Q�60   5!      5#      �� 5%   
   8   " ��6>    5&      �� 5'       6   ��  �� $ FindAncestor=�" ��$ 
IsSelected� true5*   3   .a�53      ��  � ��$
 Bold"�63   �� 54       � ��
 �   �63   55      �� 56       6   �� *matchesFilter+	 false6@   .a�57      ��  �@J�Opacity$	 0.5Q�60   58      5:      �� 5<   
   " ��6    5=      �� 5>       6   �� *
IsSelected+ true6=   .a�5?      ��  � ��
 �����63   �� 5@       �@J�Effect 5A        5B      #	 � ��5C   !   $
 0Q�5D   !   $ 1Q�61   $ 20Q�5E   !   5G      5H      �� 5I       6   �� *
IsSelected+	 false6=   .a�5J      ��  � ��
 �����63   �� 5K       �@J�Effect 5L        5M      $	 	LightGray��6/   $ 2Q�6A   $	 0.5Q�6P   5O      5P      5R      �� 5T   
   " ��6    5U      �� 5V       6   �� *
IsSelected+	 false6=   .a�5W      ��  � ��
 �����63   �� 5X       �@J�Effect 5Y        5Z      $	 	LightGray��6/   $ 2Q�6A   $	 0.5Q�6P   5\      5]      �� 5^       6   �� *MatchesFilter+	 false6@   .a�5_      ��  � ��
 �����63   �� 5`       � ��
 �����64   �� 5a       �@J�Effect 5b        5c      $	 
GhostWhite��6/   5e      5f      �� 5g       6   �� *
IsSelected+ true6=   .a�5h      ��  � ��
 �����63   �� 5i       �@J�Effect 5j        5k      #	 � ��5l   !   $
 0Q�5m   !   $ 1Q�61   $ 20Q�5n   !   5p      5q      �� 5r       6   �� *MatchesFilter+ true6@   .a�5s      ��  � ��
 �   �64   5t      5v      �� 5x   
   " ��6    5y      �� 5z       6   ��  �� $ FindAncestor=�" ��$ 
IsSelected� true5}   3   .a�5~      ��  � ��
 �����63   �� 5       �@J�Effect 5�        5�      $	 CornflowerBlue��5�   !   $
 0Q�5�   !   $ 1Q�61   $ 20Q�5�   !   5�      5�      �� 5�       6   ��  �� $ FindAncestor=�" ��$ 
IsSelected�	 false5�      .a�5�      ��  � ��
 �����63   �� 5�       �@J�Effect 5�        5�      $	 	LightGray��6/   $ 2Q�6A   $	 0.5Q�6P   5�      5�      5�        5�   
   6%     5�   
   6$     5�   
   6      5�   
   6      5�   
   6     5�   
   6&   ��5�   
   #7092BE��6+   2  5�      5�      