   M S B A M L   `   `   `  ????F  BKiaSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.FlashCardAppWpfApp1.FlashCardApp  5   	   '    !WpfApp1.FlashCardApp.TableManager   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApp1.FlashCardApp     5   	   -   5        $??xbody??5   5     ? Title$  TableManager??5   	   $	??450??6   $	??800??6+   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $
??0.4* ?6   ?? 5      $??5* ?6   ?? 5      $
??0.5* ?6   ?? 5      $??1* ?6   ?? 5      $	??10* ?6   .+?5   
   ?? $??0??6   $??0??6   $??Center=?5      $??Bottom=?5      $??	Question:??5      ?? 5   
   $??0??6   $??1??6   $??Center=?5      $??Bottom=?5      $??Answer:??5      ?? 5   
   -   5         ??Name$ questionBox??5   /   $??1??6   $??0??6   $??10q?5       ?? TextWrapping$
 Wrap=?5       " ?? VerticalScrollBarVisibility$
 Auto=?5!       ?? AcceptsReturn$
 True??5"      $??10q?5#      ?? 5$   
   -   5        $ 	answerBox??5$   /   $??1??6   $??1??6   $??10q?5%      $??10q?5&      $
 Wrap=?5'      $
 Auto=?5(      $
 True??5)      A? 5*   
   $??1??6   $??2??6#    A? Rows$ 3??63   $??10q?6<   .+?5+      ?? -   5         ??Name$
 save??5+   *   $	??Top=?6      primary#??[  5,      $
??save??5-      ?? 5.      -   5        $ update??5.   *   $	??Top=?6     warning#??[ 5/      $??update??50      ?? 51      -   5        $ delete??51   *   $	??Top=?6    
 danger#??[ 52      $??delete??53      54      ? 55   
   $??2??6   $??3??6   .+?56      ]? .+?57      ?? $??search:??6   	 ?? Padding$	 5q?58      ?? 59      -   5        $ search??59      $??Center=?5:      5;      5<      ? 5=   
   $??3??6   $??3??6   $??10q?60   .+?5>      ]? $??False??6   .+?5?      ?? -   5        $ 	ASCButton??5?   /   $
??Left=?6   $??sort by date ASC??5@      $??0 0 10 0q?5A      $??5q?5B      ?? 5C      -	   5        $ 
DESCButton??5C   /   $
??Left=?6   $??sort by date DESC??5D      $??0 0 10 0q?5E      $??5q?5F      ?? 5G      -
   5        $ abDirBtn??5G   0   $??Right=?6   $??answerBox Direction??5H      $??0 0 10 0q?5I      $??5q?5J      ?? 5K      -   5        $ qbDirBtn??5K   0   $??Right=?6   $??questionBox Direction??5L      $??0 0 10 0q?5M      $??5q?5N      5O      5P      ? 5Q   
   $??4??6   $??3??6   .+?5R      ?? -   5        
 ??Name$
 questionsListView??5R      ??5T      ?? 5U       ?? 
TargetType" ??6    .?5V      ??  ?? Property ? ?? ?? Value
 ?   ?6<   ?? 5W       ? ??$ 2 0 0 0q?6@   ?? 5X       ? ?? 	 faded# [ 6;   ?? 5Y       ? ??$ 0 0 0 5q?67   ?? 5Z       ? ??$ Stretch=?6K   ?? 5[       ? ??$ 45??6:   ?? 5\       ? ??$	 Top=?6I   5]       ?? View 5_      ?? 5`      .P?5a      ?? -   5        questionCol??$??Question??5a   B    ?? DisplayMemberBinding 6T   ?? *
Question+?? 5b      -   5        	answerCol??$??Answer??5b   @    6P   ?? *Answer+?? 5c      -   5        dateCol??$??last modify??5c   >    6S   ?? *DateModifiedToShow+?? 5d      -   5        operationCol??$??
Operations??5d   C    ?? CellTemplate 5e   "   ?? 5f   &   .R?5g   *   ?? -   5        $
??edit??5g   1   $??5q?5h   1   5i   '   5k      5l      5n      5o      5p      5q      