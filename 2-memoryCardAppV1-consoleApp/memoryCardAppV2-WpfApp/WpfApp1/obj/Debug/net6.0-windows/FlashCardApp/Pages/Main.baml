   M S B A M L   `   `   `  ????F  BKiaSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.FlashCardAppWpfApp1.FlashCardApp  5   	   U/clr-namespace:WpfApp1.FlashCardApp.UserControls!WpfApp1.FlashCardApp.UserControls  5   	       WpfApp1.FlashCardApp.Main   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApp1.FlashCardApp     5   	   HUserControls/clr-namespace:WpfApp1.FlashCardApp.UserControls     5   	   -   5        $??xbody??5   -     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)   ???#DDDFDF ? 	Resources 5       ?? 
TargetType   timeLineLabel ?? Property ?? Value  timeLineLabelBottom?? 5   
   %k  &	        &	 ?     ?? 5      " ??6   .?5      ??  ? ??$ Center=?6=   ?? 5       ? ??$ Center=?6?   ?? 5       ? ??
 ?  ??60   ?? 5       ? ??$ 1q?64   5      ?? 5      " ??6   .?5      ??  ? ??$ Center=?6=   ?? 5       ? ??$ Center=?6?   ?? 5       ? ??
 ?????6/   5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $
??1.4* ?6   ?? 5      $
??1.4* ?6    ? RowDefinitions 5    
   ?? 5!      $??1* ?6   ?? 5"      $	??14* ?6   ?? 5#      $??1* ?6   ?? 5$      $??2* ?6   .+?5&   
   3   -WpfApp1.FlashCardApp.UserControls.MainTopMenu  $??0??6#   $??2??60   ]? 5'   
   $??0??6   $??2??6!   $??False??5(      ???#ABB0B0.+?5*      ?? -   5        $
??Left=?5*      $??6q?5+      $??10q?6!   $
??undo??5,      ?? 5-      -   5        $??remainingQuestionLabel??5-   +   $??Right=?6   $??Right=?5.      $??Center=?5/      ?? 50      -   5        $??
timerLabel??50   *   $
??Left=?6   $??Center=?51      $??Center=?52      $??	40 0 40 0q?53      $
??bold"?54      $??20(?55      
??? ? ?56      57      ?? 58   
   -   5         ??Name$ questionBox??58   1   $??1??6   $??0??6!   ???#EAEBEB$??WrapWithOverflow=?5:      $
??17.5(?5;      5<      ?? 5=   
   -   5         ??Name$ 	answerBox??5=   /   $??1??6   $??1??6   $??2q?5>      $??25(?5?      ???#ABB0B0$??5 0 0 0q?5A      	 ?? TextWrapping$
	 Wrap=?5B      "
 ?? VerticalScrollBarVisibility$
 Visible=?5C       ?? AcceptsReturn$
 True??5D      ???#EAEBEB5E      ?? 5F   
   -   5        $ dbAnswerBox??5F   1   $??1??6   $??2??6!    ?? Padding$ 2q?5G      $??25(?5H      $
??Wrap=?5I      ???#EAEBEB5J      A? 5K   
   $??2??6   $??3??6#    A? Columns$ 4??5L      .+?5M      ?? -   5         ??Name$ showBtn??5M   /   $??show answer (1)??6     info#??[ 5N      ?? 5O      -	   5        $ answeredBtn??5O   2   $??answered right (2)??6     success#??[ 5P      ?? 5Q      -
   5        $ 	failedBtn??5Q   3   $??wrong answer :) (3)??6    
 danger#??[ 5R      ?? 5S      -   5        $ 	manageBtn??5S   :   $ ??manage this flash card (4)??6    	 faded#??[ 5T      5U      ? 5V   
   $??3??6   $??3??6   .+?5W      0   *WpfApp1.FlashCardApp.UserControls.TimeLine  -   5          Name$ userControlsTimeLine??5W   $   5X      5Y      5Z      