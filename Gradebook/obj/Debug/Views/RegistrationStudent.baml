   M S B A M L   `   `   `  ����D  @Gradebook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Gradebook.ViewsGradebook.Views  5   	   )    #Gradebook.Views.RegistrationStudent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Gradebook.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  RegistrationStudent��5	   	   $	��450��6%   $	��450��65   $	��400��6E   $	��400��6T    � WindowStartupLocation$ CenterScreen=�6c    � 	Resources 5
      ��%    5      .��5      � ���#333333 � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $
��1.8* �6   6.   .+�5   
   �� $��0��6   $��0��6   $��Фамилия и имя��6-   $��18(�6E   ���#ffff$��Center=�6f   $��Right=�6�   6�   �� 5   
   -   5         ��Name$ SurnameStudent��5   W   
�������$	��200��6o   $��0��6{   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   ��61   �� *	Surname+ �� Mode$ TwoWay=�6�   �� 5   
   $��1��6   $��0��6   $��Группа��6-   $��18(�6>   ���#ffff$��Center=�6_   $��Right=�6z   6�   �� 5   
   -   5         ��Name$ GroupStudent��5   �       MaterialDesignFilledComboBox#��[  6   ���#333333
�������$	��200��6�   $��1��6�   $��1��6�   $��Center=�6�   $��Center=�6  $��18(�67   �� SelectedItem 6}   �� *Group+��6�   �� *GroupsNames+��5      �� 5       .R�5!      �� ���#33333368   5"      5$      �� 5%   
   $��2��6   $��0��6   $��
Логин��6-   $��18(�6=   ���#ffff$��Center=�6^   $��Right=�6y   6�   �� 5&   
   -   5        $ LoginStudent��5&   U   
�������$	��200��6k   $��2��6w   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   ��61   �� *Login+$ TwoWay=�6�   �� 5'   
   $��3��6   $��0��6   $��Пароль��6-   $��18(�6>   ���#ffff$��Center=�6_   $��Right=�6z   6�   G� 5(   
   -   5        	 G�Name$	 PasswordStudent��5(   5   
�������$	��200��6N   
 G� PasswordChar$
 *��6Z    G� 	MaxLength$ 8��6k   $��3��6y   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   6�   �� 5)   
   -   5         ��Name$ ErrorMessage��5)   7   $��4��6M   $��2��6Z   $��Center=�6n   $��Center=�6�   $��12(�6�   
���������6   ��  �� Path$ ErrorMessage�6�   �� 5*   
   $��2��67   $��5��6K   $��Center=�6X   $��Center=�6s   $*��$Зарегистрироваться��6�   $��18(�6�   ��6   �� *AddStudentCommand+6�   5+      5-      