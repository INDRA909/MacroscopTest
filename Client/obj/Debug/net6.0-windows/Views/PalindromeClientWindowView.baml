   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	   -    'Client.Views.PalindromeClientWindowView   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   
�������  � Title$  PalindromeClientWindow��5   	   $	��450��6(   $	��800��65   .��5	      � $��0,0,0,0q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Files��5      $��1��5      $��	5,10,5,21q�6       AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$
 Name�  5      $
 Text��6%    63   �� $
 Text�  5      $ Check��6%    64   �� $ 	CheckText�	 �� UpdateSourceTrigger$	 PropertyChanged=�5      �� 5   
   -   5        
 ��Name$
 SelectFolder��5      $��Select folder��5      $
��Left=�5      $��	10,10,0,0q�5      $	��Top=�5      $	��119��5      $��38��6   �� 5   
   -   5        $
 GetCheckText��5      $��Check files��5      $
��Left=�5       $��
155,10,0,0q�5!      $	��Top=�5"      $��38��5#      $	��144��6   5$      5%      