   M S B A M L   `   `   `  ����G  CAuto_service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Auto_service.ViewsAuto_service.Views  5   	   '    !Auto_service.Views.ClientServices   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Auto_service.Views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$= 7ООО «Поломка» | Услуги клиента��5	   	   $	��437��60   $
��auto��6=   $	��500��6J    � Icon$8 2/Auto_service;component/Resources/service_logo.ico��6Y   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid     CanUserAddRows .     RowHeaderWidth$ 0Q�6*   $��16(�6>   $��	Tw Cen MT)�6L      SelectionMode$ Single=�6�      CanUserSortColumns .   %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�6�   	   AutoGenerateColumns	 .  $
��Left=�6<  $��0,65,0,0q�6W  $	��Top=�6i  
�������$	��400��6�  $	��300��6�  $
��auto��6�  $	��800��6�  $
��auto��6�  ��6c   �� *ClientServices+
   Columns
 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Услуга��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 200* 69      CellTemplate 5      �� 5      .R�5      �� $��16(�6G   $��	Tw Cen MT)�6U   $
��Wrap=�6l   ��6(   �� *Service.Title+6l   5      5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 16Q�6b      
FontFamily$ 	Tw Cen MT)�6p   $! Дата посещения��6�   $
 100* 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	StartTime+ �� StringFormat$ {0:dd.MM.yyyy}��6�     5      $ 16Q�6`   $ 	Tw Cen MT)�6n   $# Время посещения��6�   $
 100* 6�    6%   �� *	StartTime+$ {0:HH:mm:ss}��6�     5      $ Цена (руб.)��6F   $	 70* 6[    6%   �� *Service.Cost+6[   5      �� 5   
   $��30��6*   $��
Назад��66   $
��Left=�6F   $��16(�6a   $��	Tw Cen MT)�6o   $��	10,10,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *Back+6�   �� 5   
   $��25��6   $��18(�6    $��	Tw Cen MT)�6.   $��	0,6,265,0q�6E   $
��Wrap=�6X   $��Клиент:��6l   $	��Top=�6{    J� RenderTransformOrigin$ 0.612,0.188&�6�   $��Right=�6�   $��68��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��25��6.   $��	0,31,10,0q�6:   $	��Top=�6M   $��Right=�6e   $	��327��6�   .+�5      �� $��5,0,0,0q�6@   $��16(�6R   $��	Tw Cen MT)�6`   ��6   �� *CurrentClient.LastName+6`   �� 5      $��5,0,0,0q�6A   $��16(�6S   $��	Tw Cen MT)�6a   ��6   �� *CurrentClient.FirstName+6a   �� 5      $��5,0,0,0q�6B   $��16(�6T   $��	Tw Cen MT)�6b   ��6   �� *CurrentClient.Patronymic+6b   5       5#      5$      