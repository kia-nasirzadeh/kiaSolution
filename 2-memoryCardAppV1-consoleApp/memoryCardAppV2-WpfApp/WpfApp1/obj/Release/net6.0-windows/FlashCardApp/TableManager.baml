   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.FlashCardAppWpfApp1.FlashCardApp  '    !WpfApp1.FlashCardApp.TableManager   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:WpfApp1.FlashCardApp     -   $��xbody��  � Title$  TableManager��$	��450��$	��800��.���  � ColumnDefinitions �� �� ��  � RowDefinitions �� $
��0.4* ��� $��5* ��� $
��0.5* ��� $	��10* �.+��� $��0��$��0��$��Center=�$��Bottom=�$��	Question:���� $��0��$��1��$��Center=�$��Bottom=�$��Answer:���� -    ��Name$ questionBox��$��1��$��0��$��10q� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� AcceptsReturn$
 True��$��10q��� -   $ 	answerBox��$��1��$��1��$��10q�$��10q�$
 Wrap=�$
 Auto=�$
 True��A� $��1��$��2�� A� Rows$ 3��$��10q�.+��� -    ��Name$
 save��$	��Top=�   primary#��[  $
��save���� -   $ update��$	��Top=�  warning#��[ $��update���� -   $ delete��$	��Top=� 
 danger#��[ $��delete��� $��2��$��3��.+�]� .+��� $��search:��	 �� Padding$	 5q��� -   $ search��$��Center=�� $��3��$��3��.+��� .���� -   
 ��Name$
 questionsListView������  �� 
TargetType" ��.���  �� Property � �� �� Value
 �   ���  � ��$ 2 0 0 0q���  � �� 	 faded# [ ��  � ��$ 0 0 0 5q� �� View �� .P��� $��Question�� �� Width$	 120�� �� DisplayMemberBinding �� *
Question+�� $��Answer��$ 50�� �� *Answer+�� $��last modify��$ 50�� �� *Answer+�� $��
Operations��$ 50�� �� CellTemplate �� .R��� -	   $
��edit��$��5q�