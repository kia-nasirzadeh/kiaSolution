   M S B A M L   `   `   `  ����F  BKiaSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.FlashCardAppWpfApp1.FlashCardApp  5   	   U/clr-namespace:WpfApp1.FlashCardApp.UserControls!WpfApp1.FlashCardApp.UserControls  5   	   (    "WpfApp1.FlashCardApp.FlashCardEdit   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApp1.FlashCardApp     5   	   HUserControls/clr-namespace:WpfApp1.FlashCardApp.UserControls     5   	     � Title$  FlashCardEdit��5	   	   $	��450��6   $	��800��6,    � 	Resources 5
       
  labels �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6   .�5      ��  � ��$ Center=�69   �� 5       � ��$ Center=�6;   �� 5       � ��
 �����6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��0��6   $��0��6   #��[  5      $��dates��5      �� 5    
   $��1��6   $��0��6   #��[  5!      $��question��5"      �� 5#   
   $��2��6   $��0��6   #��[  5$      $��answer��5%      �� 5&   
   $��3��6   $��0��6   #��[  5'      $��timeLine��5(      �� 5)   
   -   5         ��Name$ 
datesLabel��5)   -   $��0��6   $��1��6   6-   �� 5*   
   -   5         ��Name$ questionLabel��5*   D   $��1��6   $��1��6   	 �� AcceptsReturn$
	 True��6/   6D   �� 5+   
   -   5        $ answerLabel��5+   D   $��2��6   $��1��6   $
	 True��6/   6[   � 5,   
   -   5        
 �Name$
 timeLineLabel��5,   ,   $��3��6   $��1��6   .+�5-      0   *WpfApp1.FlashCardApp.UserControls.TimeLine  -   5          Name$ userControlsTimeLine��5-   $   5.      A� 5/   
   $��4��6   $��2��6#    A� Rows$ 1��50      .+�51      �� -   5        $��saveBtn��51   $   $
��save��6     success#��[ 52      �� 53      -   5        $��	cancelBtn��53   &   $��cancel��6    
 danger#��[ 54      55      56      57      