   M S B A M L   `   `   `  ����D  @Gradebook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Gradebook.ViewsGradebook.Views  5   	   )    #Gradebook.Views.RegistrationTeacher   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Gradebook.Views     5   	     � Title$  RegistrationTeacher��5   	   $	��450��6%   $	��450��65   $	��400��6E   $	��400��6T    � WindowStartupLocation$ CenterScreen=�6c   .��5	      � ���#333333 � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $
��1.8* �6   6.   .+�5   
   �� $��0��6   $��0��6   $��Фамилия и имя��6-   $��18(�6E   ���#ffff$��Center=�6f   $��Right=�6�   6�   �� 5   
   -   5         ��Name$ SurnameText��5   W   
�������$	��200��6l   $��0��6x   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   ��61   �� *	Surname+ �� Mode$ TwoWay=�6�   �� 5   
   $��1��6   $��0��6   $��Предмет��6-   $��18(�6?   ���#ffff$��Center=�6`   $��Right=�6{   6�   �� 5   
   -   5         ��Name$ TeacherSubjects��5   �   ���#333333    MaterialDesignFilledComboBox#��[  6(   
�������$	��200��6�   $��1��6�   $��1��6�   $��Center=�6	  $��Center=�6$  $��18(�6A   �� SelectedItem 6}   �� *SelectedSubject+��6�   �� *
Subjects+��5      �� 5      .R�5      �� ���#33333368   5      5      �� 5    
   $��2��6   $��0��6   $��
Логин��6.   $��18(�6>   ���#ffff$��Center=�6_   $��Right=�6z   6�   �� 5!   
   -   5        $ 	LoginText��5!   U   
�������$	��200��6h   $��2��6t   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   ��61   �� *Login+$ TwoWay=�6�   �� 5"   
   $��3��6   $��0��6   $��Пароль��6-   $��18(�6>   ���#ffff$��Center=�6_   $��Right=�6z   6�   G� 5#   
   -   5         G�Name$ PasswordText��5#   5   
�������$	��200��6K   	 G� PasswordChar$	 *��6W   
 G� 	MaxLength$
 8��6h   $��3��6v   $��1��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   6�   �� 5$   
   -   5         ��Name$ ErrorMessage��5$   7   $��4��6M   $��2��6Z   $��Center=�6n   $��Center=�6�   $��12(�6�   
���������6   ��  �� Path$ ErrorMessage�6�   �� 5%   
   $��2��67   $��5��6K   $��Center=�6X   $��Center=�6s   $*��$Зарегистрироваться��6�   $��18(�6�   ��6   �� *AddTeacherCommand+6�   5&      5'      