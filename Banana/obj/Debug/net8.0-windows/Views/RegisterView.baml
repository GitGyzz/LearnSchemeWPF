   M S B A M L   `   `   `  ����A  =Banana, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Banana.ViewsBanana.Views  5      1clr-namespace:Banana.ServicesBanana.Services  5          Banana.Views.RegisterView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Banana.Views     5      1serviceclr-namespace:Banana.Services     5        � DataContext  5
      �� *RegisterViewModel+   ServiceLocator �� Source# [   � 	Resources 5      -   'Banana.Services.InverseBooleanConverter  InverseBooleanConverter��%   &	         5   
   6L   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��1��6   $��1��6   $��Center=�6-   $��10q�6Q   .��6]   注册6a   � 5   
   $��2��6   $��1��6    5!      �� 5"      $
��Auto �6    60   �� 5#      $
��Auto �6    60    5%      �� 5&      $��* �6#   6/   �� 5'      $��* �6#   6/   .+�5*      �� $��0��6   $��0��6"   $��Center=�62   $��10q�6V   .��6b   	用户名6g   �� 5+      $��0��6   $��1��6%   $
��Left=�65   $��10q�6W   ��6c   �� *Name+" �� ValidatesOnNotifyDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5-      $��1��6   $��0��6"   $��Center=�62   $��10q�6V   .��6b   密码6f   �� 5.      $��1��6   $��1��6%   $
��Left=�65   $��10q�6W   ��6c   �� *
Password+$
 True��$ PropertyChanged=�6�   50      � 52   
   $��3��6   $��1��6    53      �� 54      $��* �6#   6/   �� 55      $��* �6#   6/   �� 56      $
��Auto �6#   62   �� 57      $
��Auto �6#   62   .+�5:      �� $��0��6   $��2��6"   $��10q�64   ��6@   �� *NaviToLoginButtonCommand+.��6p   返回6t   �� 5;      $��0��6   $��3��6"   $��10q�64   {�6@   �� *	HasErrors+ �� 	Converter# [ ��6�   �� *RegisterButtonCommand+.��6�   注册6�   5<      � 5>   
   $��4��6   $��1��6   .+�5?      �� 
���  ����6)   �� *MessageResult+6J   5@      5B      5D      