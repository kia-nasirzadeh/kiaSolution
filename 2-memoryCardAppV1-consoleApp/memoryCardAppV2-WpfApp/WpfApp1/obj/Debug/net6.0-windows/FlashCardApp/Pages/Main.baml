   M S B A M L   `   `   `  ����F  BKiaSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.FlashCardAppWpfApp1.FlashCardApp  5   	   U/clr-namespace:WpfApp1.FlashCardApp.UserControls!WpfApp1.FlashCardApp.UserControls  5   	       WpfApp1.FlashCardApp.Main   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApp1.FlashCardApp     5   	   HUserControls/clr-namespace:WpfApp1.FlashCardApp.UserControls     5   	   -   5        $��xbody��5   -     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   ���#DDDFDF � 	Resources 5       
  answer �� Text  rightAnswer  wrongAnswer �� 
TargetType  timeLineLabel �� Property �� Value  timeLineLabelBottom�� 5   
   %�  &	        &	 &     &	 L     &	 r     &	 /    �� 5      $ Another Text��6-   �� 5      $ Another Text��62   �� 5      $ Another Text��62   �� 5      " ��6   .�5      ��  � ��$ Center=�6=   �� 5       � ��$ Center=�6?   �� 5       � ��
 �  ��60   �� 5       � ��$ 1q�64   5      �� 5      " ��6   .�5      ��  � ��$ Center=�6=   �� 5       � ��$ Center=�6?   �� 5       � ��
 �����6/   5      5       J� InputBindings 5      �� 5   
   
 �� Key$ J��6    �� 	Modifiers$
 Ctrlf�6   	 �� Command#	 [  6.   �� 5   
   $ K��6   $
 Ctrlf�6   #	 [ 6.   �� 5    
   $ L��6   $
 Ctrlf�6   #	 [ 6.   
 J� CommandBindings
 5"      )  #System.Windows.Input.CommandBinding  5#   
   -   5           Command# [  5#      6;     5$   
   -   5        # [ 5$      6@     5%   
   -   5        # [ 5%      6@   .��5'      �  � ColumnDefinitions 5(   
   �� 5)      $��1* �6   �� 5*      $
��1.4* �6   �� 5+      $
��1.4* �6    � RowDefinitions 5-   
   �� 5.      $��1* �6   �� 5/      $	��14* �6   �� 50      $��1* �6   �� 51      $��2* �6   .+�53   
   3   -WpfApp1.FlashCardApp.UserControls.MainTopMenu  $��0��6#   $��2��60   ]� 54   
   $��0��6   $��2��6!   $��False��55      ���#ABB0B0.+�57      �� -   5         ��Name$ undo_btn��57   +   $
��Left=�6   $��6q�58      $��10q�6!   $
��undo��59      �� 5:      -   5        $ 
latest_btn��5:   +   $
��Left=�6   $��6q�5;      $��
0 10 10 10q�6!   $��see latest(6)��5<      �� 5=      -   5        $��remainingQuestionLabel��5=   +   $��Right=�6   $��Right=�5>      $��Center=�5?      �� 5@      -   5        $��
timerLabel��5@   *   $
��Left=�6   $��Center=�5A      $��Center=�5B      $��	40 0 40 0q�5C      $
��bold"�5D      $��20(�5E      
��� � �5F      �� 5G      -	   5        $��lastAnswerLabel��5G   *   $
��Left=�6   
�������$��Center=�5I      $��Center=�5J      $��	10 0 10 0q�5K      $��10(�5L      
���   �5M      5N      �� 5O   
   -
   5         ��Name$ questionBox��5O   1   $��1��6   $��0��6!   
���   �
�������$��WrapWithOverflow=�5R      $
��17.5(�5S      5T      �� 5U   
   -   5         ��Name$ 	answerBox��5U   /   $��1��6   $��1��6   $��2q�5V      $��20(�5W      ���#ABB0B0$��5 0 0 0q�5Y       �� TextWrapping$
 Wrap=�5Z      " �� VerticalScrollBarVisibility$ Visible=�5[       �� AcceptsReturn$
 True��5\      
�������
���   �5^      �� 5_   
   -   5        $ dbAnswerBox��5_   1   $��1��6   $��2��6!    �� Padding$ 2q�5`      $��20(�5a      $
��Wrap=�5b      
�������
���   �5d      A� 5e   
   $��2��6   $��3��6#    A� Columns$ 4��5f      .+�5g      �� -   5        $ showBtn��5g   /   $��show answer (1)��6     info#��[ 5h      �� 5i      -   5        $ answeredBtn��5i   2   $��answered right (2)��6     success#��[ 5j      �� 5k      -   5        $ 	failedBtn��5k   3   $��wrong answer :) (3)��6    
 danger#��[ 5l      �� 5m      -   5        $ 	manageBtn��5m   :   $ ��manage this flash card (4)��6    	 faded#��[ 5n      5o      � 5p   
   $��3��6   $��3��6   .+�5q      0   *WpfApp1.FlashCardApp.UserControls.TimeLine  -   5          Name$ userControlsTimeLine��5q   $   5r      5s      5t      