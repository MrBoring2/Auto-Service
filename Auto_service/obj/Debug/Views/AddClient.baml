   M S B A M L   `   `   `  ����G  CAuto_service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Auto_service.ViewsAuto_service.Views  5   	   =#clr-namespace:Auto_service.ServicesAuto_service.Services  5   	   "    Auto_service.Views.AddClient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Auto_service.Views     5   	   2xc#clr-namespace:Auto_service.Services     5   	     � Title$A  ;ООО «Поломка» | Добавить клиента��5	   	   $��365.688��62   $��611.813��6C    � Icon$8 2/Auto_service;component/Resources/service_logo.ico��6S    � WindowStartupLocation$ CenterScreen=�6�   (   "Auto_service.Services.DialogCloser   DialogResult 5
   	   �� *DialogResult+.��5      �  � ColumnDefinitions 5   
   �� 5      $	��34* �6   �� 5      $
��117* �6   .+�5   
   �� -   5        $��23��5   ,   $��	53,40,0,0q�68    �� TextWrapping$
 Wrap=�6K   $
��Left=�6_   $	��150��6z   $	��Top=�6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   ��6   �� *
LastName+6�   �� 5   
   $
��Left=�6   $��	54,15,0,0q�6/   $
��Wrap=�6B   $��Фамилия��6V   $	��Top=�6e   $��	Tw Cen MT)�6}   $��16(�6�   $��1��6�   �� 5   
   $
��Left=�6   $��
220,76,0,0q�6/   $
��Wrap=�6C   $��Email��6W   $	��Top=�6d   $��	Tw Cen MT)�6|   $��16(�6�   $��1��6�   �� 5   
   $��23��6-   $��	52,97,0,0q�69   $
 Wrap=�6L   $	��Top=�6`   $
��Left=�6x   $	��150��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   ��6   �� *	FirstName+6�   �� 5   
   $
��Left=�6.   $��23��6I   $��
51,160,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��150��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   ��6   �� *
Patronomic+6�   �� 5   
   -   5        $
��Left=�5   )   $��23��6D   $��
215,96,0,0q�6P   $
 Wrap=�6d   $	��219��6x   $	��Top=�6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   ��6   �� *Email+6�   �� 5   
   $
��Left=�6)   $��23��6D   $��215,156,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��219��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   ��6   �� *Phone+6�   �� 5   
   $
��Left=�6   $��219,134,0,0q�6/   $
��Wrap=�6D   $��Телефон��6X   $	��Top=�6g   $��	Tw Cen MT)�6   $��16(�6�   $��1��6�   �� 5   
   $
��Left=�6   $��125,199,0,0q�6/   $
��Wrap=�6D   $��Дата рождения��6X   $	��Top=�6m   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�67   $��125,222,0,0q�6R   $	��Top=�6g   $	��172��6   ���	#FFFFFFE1$��	Tw Cen MT)�6�   $��16(�6�   $��1��6�      SelectedDate 6   �� *
BirthDay+6�   �� 5   
   $��	15,33,0,0q�6   $
��Fill=�6G   $
��Left=�6V   $	��150��6q   $	��150��6}   $	��Top=�6�   $��2��6�   ��6#   ��  �� Path$ PhotoSource�6�   �� 5   
   $
��Left=�6   $��	32,13,0,0q�6/   $
��Wrap=�6B   $��Фото��6V   $	��Top=�6b    J� RenderTransformOrigin$ -18.643,0.688&�6z   $��	Tw Cen MT)�6�   $��16(�6�   �� 5   
   $
��Left=�6   $��	52,76,0,0q�6/   $
��Wrap=�6B   $��Имя��6V   $	��Top=�6a   $��	Tw Cen MT)�6y   $��16(�6�   $��1��6�   �� 5   
   $
��Left=�6   $��
53,138,0,0q�6/   $
��Wrap=�6C   $��Отчетсво��6W   $	��Top=�6g   $��	Tw Cen MT)�6   $��16(�6�   $��1��6�   �� 5   
   $)��#Загрузить картинку��6.   $
��Left=�6K   $��
17,196,0,0q�6f   $	��Top=�6z   $	��150��6�   $��25��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��2��6�   ��6   �� *
OpenFile+6�   �� 5   
   $��Добавить��6/   $
��Left=�6B   $��
18,295,0,0q�6]   $	��Top=�6q   $	��150��6�   $��25��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��2��6�   ��6   �� *	AddClient+6�   �� 5    
   	 �� SelectedIndex$	 0��6\      ComboBoxTest2#��[  6n   $
��Left=�6�   $��
214,36,0,0q�6�   $	��Top=�6�   $	��219��6�   $��	Tw Cen MT)�6�   $��16(�6�   $��1��6  ��6   �� *	Genders+
 �� SelectedValue
 63   �� *SelectedGender+6  �� 5!   
   $
��Left=�6   $��
220,14,0,0q�6/   $
��Wrap=�6C   $��Пол��6W   $	��Top=�6b   $��	Tw Cen MT)�6z   $��16(�6�   $��1��6�   5#      5$      