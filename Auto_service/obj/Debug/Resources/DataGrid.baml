   M S B A M L   `   `   `  ����G  CAuto_service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Auto_service.ResourcesAuto_service.Resources  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 "  Brush_DataGridHeaderBackground  �� Color + 'Brush_DataGridHeaderMouseOverBackground  Brush_DataGridHeaderBorder �� 
StartPoint �� EndPoint � Color � Offset $  Brush_DataGridHeaderSortedBorder ( $Brush_DataGridHeaderSortedBackground  Brush_DataGridSelected  Brush_DataGridMouseOver $  Brush_DataGridSelectedForeground " Brush_DataGridAltRowBackground 	 Style_HeaderGripper �� 
TargetType �� Property �� Value �� 
TargetType	 �� Padding=   7System.Windows.Controls.Primitives.DataGridColumnHeader
 � ColumnDefinitions ��Name F�Name �� Stretch J� RenderTransformOrigin n�Name �� Triggers P� Value P� Property �� 
TargetName �� Angle*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow J� SnapsToDevicePixels?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid  Name � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter  Name   
ItemsPanel:  4System.Windows.Controls.Primitives.DataGridRowHeader  Name$   SelectiveScrollingOrientation �� RelativeSource �� AncestorType&   System.Windows.Controls.DataGrid �� Path!   HeadersVisibilityConverter  �� 	Converter7  1System.Windows.Controls.DataGridHeadersVisibility
!   Row" �� ConverterParameterA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter#  Name$   SelectAllCommand% � OverridesDefaultStyleG	  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter&   Column' �� CanContentScroll( �� Orientation) �� ScrollableHeight* � Maximum+ �� ViewportHeight, �� ViewportSize*- �� #ComputedVerticalScrollBarVisibility. � Value/ �� Mode0 �� ScrollableWidth1 �� ViewportWidth,2 �� %ComputedHorizontalScrollBarVisibility3 �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .local$clr-namespace:Auto_service.Resources  5      %�  &	        &	 ,     &	 X     &	 �     &	 �    &	 �    &	 �    &	     &	 )    &		 �    '   �    7  7  7 	 7 	 7  7  '  �    '  �    7  '  �    7  7   7  7   7  �� 5      $  	#FFFFFFE1��6=   5      �� 5      $  	#FFFFFF9C��6F   5      �� 5
      $	 0,0&�6=   $	 0,1&�6N   .��5   
   � $ 	#FF1B577E��6   $ 0Q�6)   � 5   
   $ 	#FF083258��6   $ 1Q�6)   5      �� 5      $	 0,0&�6C   $	 0,1&�6T   .��5   
   � $ #B58801��6   $ 0Q�6'   � 5   
   $ #681900��6   $ 1Q�6'   5      �� 5      $  	#FFF9F974��6C   5      �� 5      $  	#FFDA8311��65   5      �� 5      $  	#FFFF9C1A��66   5      �� 5       $  #FFFFFF��6?   �� 5"      $ 0.5,1&�6A   $ 0.5,0&�6R   .��5#   
   � $ 	#FFE1FFEE��6   $ 0Q�6)   � 5$   
   $ 	#FFC3F9DA��6   $ 0.992Q�6)   5%      �� 5'      " n�6(   .�5(   
   ��  � ��$ 8��6"   �� 5)   
    � ��
 ���� 6'   �� 5*   
    �@�Cursor$ SizeWE��6#   �� 5+   
    � �� 5,      �� 5-      " n�6"   .R�5.      �� #	 z��6   #��z��6A   5/      51      52      �� 54      "   6   .�55   
   ��  �@J�SnapsToDevicePixels . 60   �� 56   
    � ��$ 0��6%   �� 57   
    � ��$ 28��6&   �� 58   
    � ��
 �   �6'   �� 59   
    �@�Cursor$
 Hand��6#   �� 5:   
    � �� 5;      �� 5<      "   6"   .R�5=      � 
 5>      �� 5?      $��* �6/   �� 5@      $
��Auto �6/   .+�5B      �� $ BackgroundBorder��6!   $��0,1,0,1q�6;   8��  8�� $��2��6�   �� 5C      $��6,3,6,3q�6+   $��Center=�6<   F� 5D      $ 	SortArrow��6   $y�	Collapsed=�62   "����        �@B     � � @B 	$
 Fill=�6b   $��1��6q   $��8��6�   $��6��6�   
�������$��0,0,8,0q�6�   $��Center=�6�   $ 0.5,0.4&�6�   �� 5E      $��1��6$   ���#AAC377$��Right=�6=   $��2��6Y   �� 5F      $��1��6$   $��0,0,1,0q�6.   ���#425B10$��Right=�6N   $��2��6j   n� 5G      $ PART_LeftHeaderGripper��6    $
��Left=�6@   8�� 6[   n� 5H      $ PART_RightHeaderGripper��6    $��Right=�6A   8�� 6]   5I       5J      P� 5K       6;   Z�  �@  SortDirection. �5L      �� $ BackgroundBorder��6%    � ��
 ���� 6Y   �� 5M      $ BackgroundBorder��6%    � ��
 ���� 6[   5N      P� 5O       �@J�IsMouseOver . . �5P      �� $ BackgroundBorder��6%   8   � ��6Y   �� 5Q      $ BackgroundBorder��6%   8   � ��6Z   5R      P� 5S       �@  SortDirection$ 	AscendingX�6;   . �5T      �� $ 	SortArrow��6%    � y�$ Visible=�6R   �� 5U      $ 	SortArrow��6%    � z� 5V   "   �� 5W   &   $	 180Q�66   5Y      5Z      P� 5[       �@  SortDirection$ 
DescendingX�6;   . �5\      �� $ 	SortArrow��6%    � y�$ Visible=�6R   5]      P� 5^       �@  DisplayIndex$ 0��6:   . �5_      �� $ PART_LeftHeaderGripper��6M    � y�$ 	Collapsed=�6;   6s   5`      5b      5d      5e      �� 5i      "  6   .�5j   
   ��  �@�OverridesDefaultStyle . 62   �� 5k   
    � �� 5l      �� 5m      "  6"   .R�5n      �� $ BackgroundBorder��6   
������ ._�5o      �� $��Center=�6+   $��5,5,5,5q�6F   5p      5q      5s      �� 5t   
    � �� 6(   Z� 5u      �� 5y      "  6)   .�5z   
   ��  � ��# � ��6'   �� 5{   
    �@J�SnapsToDevicePixels . 60   �� 5|   
    � �� 5}      �� 5~      "  6"   .R�5      �� $ 
DGR_Border��5�      #��z��5�      #��z��5�      #��z��5�       . ._�5�        $ selectiveScrollingGrid��61   
 5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   .+�5�        $ dataGridCellsPresenter��65   $��1��5�   5   #��z 6E   # z 5�   5     5�      $ dataGridRowHeader��60   $ Vertical=�5�   0   $��2��5�   0   y�5�   0   ��  �� "  $ HeadersVisibility�#  Z #" Z! � 5�      $��Details��6@   $��1��6#   $��1��63   $y�	Collapsed=�6O   
�������.+�5�   "     $# dataGridDetailsPresenter��6;   5�      5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ 
DGR_Border��6;   # �  6S    � ���� 5�      $ dataGridCellsPresenter��6;    � ��
 �����6_   �� 5�      $ dataGridRowHeader��69    � ��$ 13.333(�6X   5�      P� 5�       �@ 
IsSelected . . �5�      �� $ 
DGR_Border��6%   8    � ��6_   �� 5�      $ dataGridDetailsPresenter��6;    � y�$ Hidden=�6a   �� 5�      $ dataGridCellsPresenter��69    � ��$ 14.667(�6]   �� 5�      $ 
DGR_Border��6;   # �  6S    � ��5�      5�      5�      5�      �� 5�      "  6&   .�5�   
   ��  � �� . 6:   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
     �@ AlternatingRowBackground8   65   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��6   ._�5�      �� $��DG_ScrollViewer��69   |�.  ��5�      �� 5�   "   " ��62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   
 5�   *   �� 5�   .   $
��Auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?   .+�5�   *   �� $��3��61   8�� 8�� $	��0,1q�6�   �� 5�   *   #��Z$ 5�      |�.  % . ��5�      ��  �� "  $ RowHeaderActualWidth���5�   .   �� 5�   2   " ��6B   .R�5�   6   � .+�5�   :   �� 8�� 8�� $	��0,1q�6�   ._�5�   >   F� $ Arrow��6C   $��Bottom=�6R   $��10q�6m   ���#3000$��11��6�   $��11��6�   $
 Fill=�6�   "����@B     �@B @B �    @B 	6�   5�   ;   �� 5�   :   $��1��6D   ���#AAC377$��Right=�6]   �� 5�   :   $��1��6D   $��0,0,1,0q�6N   ���#425B10$��Right=�6n   5�   7   5�   3   5�   +   	  5�   *   $��1��5�      y�5�      ��  �� "  $ HeadersVisibility�#  Z #" Z& �� 5�   *   $��1��6A   $��2��6N   #' z��6b   �� 5�   *   $��PART_VerticalScrollBar��5�      $��1��5�      $��2��5�      $( Vertical=�5�      #* z) 5�      #, z+ 5�      #y�z- 5�      . 5�      �� $ VerticalOffset� �� *TemplatedParent+$/ OneWay=�5�      � 5�   *   $��2��6/   $��1��6<   
 5�   .   �� 5�   2   ��6C   ��  �� "  $. (NonFrozenColumnsViewportHorizontalOffset��� 5�   2   $��* �6C   .+�5�   .   �� $��PART_HorizontalScrollBar��5�      $��1��5�      $( 
Horizontal=�5�      #* z0 5�      #, z1 5�      #y�z2 5�      . 5�      �� $ HorizontalOffset� �� *TemplatedParent+$/ OneWay=�5�      5�   +   5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�      3 5   
   P� 5      �@��
IsGrouping . . �5     ��  � �� .  6B   5     5     5     