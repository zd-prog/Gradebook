   M S B A M L   `   `   `  ����D  @Gradebook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Gradebook.ViewsGradebook.Views  5          Gradebook.Views.Timetable   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Gradebook.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��4* �6   6*   �� 5      $��* �6   6)   �� 5      $��4* �6   6*   .+�5   
   �� $��0��6   $��0��6   $��Номер недели��6-   $��Center=�6D   $
��Left=�6_   ���#403f3f$��21(�6�   6�   �� 5   
   -   5        $��WeekNumberSelect��5   \   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6   $��0��6t   $��0��6�   $��Center=�6�   $��Right=�6�   $	��150��6�    �� SelectedItem 68   �� *
WeekNumber+��6�   �� *WeekNumbers+6�   �� 5   
   $��1��6   $��0��6   $��Понедельник��6-   $��Center=�6C   $��Center=�6^   ���#403f3f$��25(�6�   6�   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .  $��2��6/   $��0��6<   $	��Top=�6r   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *MondayClasses+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Class.Time+6F     5       6%   �� *Subject.Name+6H     5       6%   �� *
Auditorium+6F   5      �� 5    
   $��1��6   $��1��6   $��Вторник��6-   $��Center=�6?   $��Center=�6Z   ���#403f3f$��25(�6�   6�     5!   
    .  $��2��6/   $��1��6<   $	��Top=�6s   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *TuesdayClasses+ 5"        5#       6%   �� *
Class.Time+6F     5$       6%   �� *Subject.Name+6H     5%       6%   �� *
Auditorium+6F   5'      �� 5(   
   $��1��6   $��2��6   $��
Среда��6-   $��Center=�6=   $��Center=�6X   ���#403f3f$��25(�6�   6�     5)   
    .  $��2��6/   $��2��6<   $	��Top=�6u   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *WednesdayClasses+ 5*        5+       6%   �� *
Class.Time+6F     5,       6%   �� *Subject.Name+6H     5-       6%   �� *
Auditorium+6F   5/      �� 50   
   $��3��6   $��0��6   $��Четверг��6-   $��Center=�6?   $��Center=�6Z   ���#403f3f$��25(�6�   6�     51   
    .  $��4��6/   $��0��6<   $	��Top=�6t   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *ThursdayClasses+ 52        53       6%   �� *
Class.Time+6F     54       6%   �� *Subject.Name+6H     55       6%   �� *
Auditorium+6F   57      �� 58   
   $��3��6   $��1��6   $��Пятница��6-   $��Center=�6?   $��Center=�6Z   ���#403f3f$��25(�6�   6�     59   
    .  $��4��6/   $��1��6<   $	��Top=�6r   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *FridayClasses+ 5:        5;       6%   �� *
Class.Time+6F     5<       6%   �� *Subject.Name+6H     5=       6%   �� *
Auditorium+6F   5?      �� 5@   
   $��3��6   $��2��6   $��Суббота��6-   $��Center=�6?   $��Center=�6Z   ���#403f3f$��25(�6�   6�     5A   
    .  $��4��6/   $��2��6<   $	��Top=�6t   $��Center=�6�   $��0,10,0,0q�6�   ��6L   �� *SaturdayClasses+ 5B        5C       6%   �� *
Class.Time+6F     5D       6%   �� *Subject.Name+6H     5E       6%   �� *
Auditorium+6F   5G      5H      5I      