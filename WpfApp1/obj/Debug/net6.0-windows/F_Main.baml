   M S B A M L   `   `   `  ����@  <Do_an, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Do_anDo_an  5   	       Do_an.F_Main   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Do_an     5   	   -   5          � Title$  F_Main��5   	   $	��800��6   $
��1240��6%    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName  FocusVisual1  Button.Static.Background1  Button.Static.Border1   Button.MouseOver.Background1  Button.MouseOver.Border1  Button.Pressed.Background1  Button.Pressed.Border1  Button.Disabled.Background1  Button.Disabled.Border1  Button.Disabled.Foreground1  ButtonStyle2  FocusVisual2  Button.Static.Background2  Button.Static.Border2   Button.MouseOver.Background2  Button.MouseOver.Border2  Button.Pressed.Background2  Button.Pressed.Border2  Button.Disabled.Background2  Button.Disabled.Border2  Button.Disabled.Foreground2   ButtonStyle3 ! FocusVisual3 " Button.Static.Background3 # Button.Static.Border3  $ Button.MouseOver.Background3 % Button.MouseOver.Border3 & Button.Pressed.Background3 ' Button.Pressed.Border3 ( Button.Disabled.Background3 ) Button.Disabled.Border3 * Button.Disabled.Foreground3 + ButtonStyle4 , FocusVisual4 - Button.Static.Background4 . Button.Static.Border4  / Button.MouseOver.Background4 0 Button.MouseOver.Border4 1 Button.Pressed.Background4 2 Button.Pressed.Border4 3 Button.Disabled.Background4 4 Button.Disabled.Border4 5 Button.Disabled.Foreground4 6 ButtonStyle5 7 FocusVisual5 8 Button.Static.Background5 9 Button.Static.Border5  : Button.MouseOver.Background5 ; Button.MouseOver.Border5 < Button.Pressed.Background5 = Button.Pressed.Border5 > Button.Disabled.Background5 ? Button.Disabled.Border5 @ Button.Disabled.Foreground5 A ButtonStyle6 B FocusVisual6 C Button.Static.Background6 D Button.Static.Border6  E Button.MouseOver.Background6 F Button.MouseOver.Border6 G Button.Pressed.Background6 H Button.Pressed.Border6 I Button.Disabled.Background6 J Button.Disabled.Border6 K Button.Disabled.Foreground6 L ButtonStyle7 M FocusVisual7 N Button.Static.Background7 O Button.Static.Border7  P Button.MouseOver.Background7 Q Button.MouseOver.Border7 R Button.Pressed.Background7 S Button.Pressed.Border7 T Button.Disabled.Background7 U Button.Disabled.Border7 V Button.Disabled.Foreground7 W ToggleButtonStyle1 X FocusVisual8 Y Button.Static.Background8 Z Button.Static.Border8  [ Button.MouseOver.Background8 \ Button.MouseOver.Border8 ] Button.Pressed.Background8 ^ Button.Pressed.Border8 _ Button.Disabled.Background8 ` Button.Disabled.Border8 a Button.Disabled.Foreground8 b ButtonStyle8 c FocusVisual9 d Button.Static.Background9 e Button.Static.Border9  f Button.MouseOver.Background9 g Button.MouseOver.Border9 h Button.Pressed.Background9 i Button.Pressed.Border9 j Button.Disabled.Background9 k Button.Disabled.Border9 l Button.Disabled.Foreground9 m ButtonStyle9��%[L  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 &	 �    &	 �    &	 �    &	 �    &	     &	 =    &	 `    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  &	 $    &	 �    &	 �    &	     &	 @    &	 c    &	 �    &	 �    &	 �    &	 �    &	      7  7  7  7  7  7  &	! N    &	"     &	# $    &	$ G    &	% j    &	& �    &	' �    &	( �    &	) �    &	*     &	+ <    7 ! 7 " 7 # 7 ( 7 ) 7 * &	, |    &	- /    &	. R    &	/ u    &	0 �    &	1 �    &	2 �    &	3     &	4 $    &	5 G    &	6 j    7 , 7 - 7 . 7 3 7 4 7 5 &	7 �#    &	8 T$    &	9 w$    &	: �$    &	; �$    &	< �$    &	= %    &	> &%    &	? I%    &	@ l%    &	A �%    7 7 7 8 7 9 7 : 7 ; 7 < 7 = 7 > 7 ? 7 @ &	B �*    &	C R+    &	D u+    &	E �+    &	F �+    &	G �+    &	H ,    &	I $,    &	J G,    &	K j,    &	L �,    7 B 7 C 7 D 7 I 7 J 7 K &	M �1    &	N w2    &	O �2    &	P �2    &	Q �2    &	R 3    &	S &3    &	T I3    &	U l3    &	V �3    &	W �3    7 M 7 N 7 O 7 Q 7 S 7 U 7 V &	X �8    &	Y �9    &	Z �9    &	[ �9    &	\ �9    &	] :    &	^ A:    &	_ d:    &	` �:    &	a �:    &	b �:    7 X 7 Y 7 Z 7 [ 7 \ 7 ] 7 ^ 7 _ 7 ` 7 a &	c �?    &	d �@    &	e �@    &	f �@    &	g �@    &	h A    &	i ?A    &	j bA    &	k �A    &	l �A    &	m �A    7 c 7 d 7 e 7 f 7 g 7 h 7 i 7 j 7 k 7 l �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   "	 ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      "
 ��6&   .R�5(      �� $ border��6!   $ 50��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      �� 5A   
   .�5B      ��  � �� 5C      �� 5D      .R�5E      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5F      5H      5I      �� 5J   
   $ 	#FFDDDDDD��6<   �� 5K   
   $ 	#FF707070��68   �� 5L   
   $ 	#FFBEE6FD��6?   �� 5M   
   $ 	#FF3C7FB1��6;   �� 5N   
   $ 	#FFC4E5F6��6=   �� 5O   
   $ 	#FF2C628B��69   �� 5P   
   $ 	#FFF4F4F4��6>   �� 5Q   
   $ 	#FFADB2B5��6:   �� 5R   
   $ 	#FF838383��6>   �� 5S   
   "	 ��6%   .�5T      ��  �@�FocusVisualStyle8   61   �� 5U       � ��8  6+   �� 5V       � ��8  6,   �� 5W       � ��# � ��6+   �� 5X       � ��$ 1q�60   �� 5Y       � ��$ Center=�6;   �� 5Z       � ��$ Center=�69   �� 5[       � ��$ 1q�6(   �� 5\       � �� 5]      �� 5^      "
 ��6&   .R�5_      �� $ border��6!   $ 40��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5`      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5a       5b      P� 5c       �@��IsDefaulted$
 true��6=   . �5d   "   �� $ border��6@   # � ��6T    � ��5e      P� 5f       �@J�IsMouseOver$
 true��6=   . �5g   "   �� $ border��6?    � �� �#ff33006S   �� 5h   "   $ border��6@    � �� �#ff33006T   5i      P� 5j       � ��$
 true��6;   . �5k   "   �� $ border��6?    � �� �#cc29006S   �� 5l   "   $ border��6@    � �� �#cc29006T   5m      P� 5n       � {�$ false��6;   . �5o   "   �� $ border��6?   8   � ��6S   �� 5p   "   $ border��6@   8   � ��6T   �� 5q   "   $ contentPresenter��6K   8   � ��6i   5r      5t      5v      5w      �� 5x   
   .�5y      ��  � �� 5z      �� 5{      .R�5|      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5}      5      5�      �� 5�   
   $ 	#FFDDDDDD��6<   �� 5�   
   $ 	#FF707070��68   �� 5�   
   $ 	#FFBEE6FD��6?   �� 5�   
   $ 	#FF3C7FB1��6;   �� 5�   
   $ 	#FFC4E5F6��6=   �� 5�   
   $ 	#FF2C628B��69   �� 5�   
   $ 	#FFF4F4F4��6>   �� 5�   
   $ 	#FFADB2B5��6:   �� 5�   
   $ 	#FF838383��6>   �� 5�   
   "	 ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      "
 ��6&   .R�5�      �� $ border��6!   $ 10��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5�      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5�       5�      P� 5�       �@��IsDefaulted$
 true��6=   . �5�   "   �� $ border��6@   # � ��6T    � ��5�      P� 5�       �@J�IsMouseOver$
 true��6=   . �5�   "   �� $ border��6?    � �� �#8800cc6S   �� 5�   "   $ border��6@    � �� �#8800cc6T   5�      P� 5�       � ��$
 true��6;   . �5�   "   �� $ border��6?    � �� �	#FF974CC16S   �� 5�   "   $ border��6@    � �� �	#FF974CC16T   5�      P� 5�       � {�$ false��6;   . �5�   "   �� $ border��6?   8   � ��6S   �� 5�   "   $ border��6@   8   � ��6T   �� 5�   "   $ contentPresenter��6K   8   � ��6i   5�      5�      5�      5�      �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5�      5�      5�      �� 5�   
   $ 	#FFDDDDDD��6<   �� 5�   
   $ 	#FF707070��68   �� 5�   
   $ 	#FFBEE6FD��6?   �� 5�   
   $ 	#FF3C7FB1��6;   �� 5�   
   $ 	#FFC4E5F6��6=   �� 5�   
   $ 	#FF2C628B��69   �� 5�   
   $ 	#FFF4F4F4��6>   �� 5�   
   $ 	#FFADB2B5��6:   �� 5�   
   $ 	#FF838383��6>   �� 5�   
   "	 ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      "
 ��6&   .R�5�      �� $ border��6!   $ 10��61   #��z��6D   #��z��6n   #��z��6�   $
 true��6�   ._�5�      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5�       5�      P� 5�       �@��IsDefaulted$
 true��6=   . �5�   "   �� $ border��6@   # � ��6T    � ��5�      P� 5�       �@J�IsMouseOver$
 true��6=   . �5�   "   �� $ border��6?    � �� �	#FFE0CDED6S   �� 5�   "   $ border��6@    � �� �	#FFE0CDED6T   5�      P� 5�       � ��$
 true��6;   . �5�   "   �� $ border��6?    � �� �	#FFE0CDED6S   �� 5�   "   $ border��6@    � �� �	#FFE0CDED6T   5�      P� 5�       � {�$ false��6;   . �5�   "   �� $ border��6?   8   � ��6S   �� 5�   "   $ border��6@   8   � ��6T   �� 5�   "   $ contentPresenter��6K   8   � ��6i   5�      5�      5�      5�      �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5�      5�      5�      �� 5�   
   $ 	#FFDDDDDD��6<   �� 5�   
   $ 	#FF707070��68   �� 5�   
   $ 	#FFBEE6FD��6?   �� 5�   
   $ 	#FF3C7FB1��6;   �� 5�   
   $ 	#FFC4E5F6��6=   �� 5�   
   $ 	#FF2C628B��69   �� 5�   
   $ 	#FFF4F4F4��6>   �� 5�   
   $ 	#FFADB2B5��6:   �� 5�   
   $ 	#FF838383��6>   �� 5�   
   "	 ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5      � �� 5     �� 5     "
 ��6&   .R�5     �� $ border��6!   $ 5��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5      5     P� 5      �@��IsDefaulted$
 true��6=   . �5	  "   �� $ border��6@   # � ��6T    � ��5
     P� 5      �@J�IsMouseOver$
 true��6=   . �5  "   �� $ border��6?    � �� �#7A1AC46S   �� 5  "   $ border��6@    � �� �#7A1AC46T   5     P� 5      � ��$
 true��6;   . �5  "   �� $ border��6?    � �� �#790EA16S   �� 5  "   $ border��6@    � �� �#790EA16T   5     P� 5      � {�$ false��6;   . �5  "   �� $ border��6?   8   � ��6S   �� 5  "   $ border��6@   8   � ��6T   �� 5  "   $ contentPresenter��6K   8   � ��6i   5     5     5     5     �� 5  
   .�5     ��  � �� 5     �� 5      .R�5!     �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5"     5$     5%     �� 5&  
   $ 	#FFDDDDDD��6<   �� 5'  
   $ 	#FF707070��68   �� 5(  
   $ 	#FFBEE6FD��6?   �� 5)  
   $ 	#FF3C7FB1��6;   �� 5*  
   $ 	#FFC4E5F6��6=   �� 5+  
   $ 	#FF2C628B��69   �� 5,  
   $ 	#FFF4F4F4��6>   �� 5-  
   $ 	#FFADB2B5��6:   �� 5.  
   $ 	#FF838383��6>   �� 5/  
   "	 ��6%   .�50     ��  �@�FocusVisualStyle8   61   �� 51      � ��8  6+   �� 52      � ��8  6,   �� 53      � ��# � ��6+   �� 54      � ��$ 1q�60   �� 55      � ��$ Center=�6;   �� 56      � ��$ Center=�69   �� 57      � ��$ 1q�6(   �� 58      � �� 59     �� 5:     "
 ��6&   .R�5;     �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5<     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5=      5>     P� 5?      �@��IsDefaulted$
 true��6=   . �5@  "   �� $ border��6@   # � ��6T    � ��5A     P� 5B      �@J�IsMouseOver$
 true��6=   . �5C  "   �� $ border��6?   8   � ��6S   �� 5D  "   $ border��6@   8   � ��6T   5E     P� 5F      � ��$
 true��6;   . �5G  "   �� $ border��6?   8   � ��6S   �� 5H  "   $ border��6@   8   � ��6T   5I     P� 5J      � {�$ false��6;   . �5K  "   �� $ border��6?   8   � ��6S   �� 5L  "   $ border��6@   8   � ��6T   �� 5M  "   $ contentPresenter��6K   8 	  � ��6i   5N     5P     5R     5S     �� 5T  
   .�5U     ��  � �� 5V     �� 5W     .R�5X     �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5Y     5[     5\     �� 5]  
   $ 	#FFDDDDDD��6<   �� 5^  
   $ 	#FF707070��68   �� 5_  
   $ 	#FFBEE6FD��6?   �� 5`  
   $ 	#FF3C7FB1��6;   �� 5a  
   $ 	#FFC4E5F6��6=   �� 5b  
   $ 	#FF2C628B��69   �� 5c  
   $ 	#FFF4F4F4��6>   �� 5d  
   $ 	#FFADB2B5��6:   �� 5e  
   $ 	#FF838383��6>   �� 5f  
   "	 ��6%   .�5g     ��  �@�FocusVisualStyle8   61   �� 5h      � ��8  6+   �� 5i      � ��8  6,   �� 5j      � ��# � ��6+   �� 5k      � ��$ 1q�60   �� 5l      � ��$ Center=�6;   �� 5m      � ��$ Center=�69   �� 5n      � ��$ 1q�6(   �� 5o      � �� 5p     �� 5q     "
 ��6&   .R�5r     �� $ border��6!   $ 5��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5s     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5t      5u     P� 5v      �@��IsDefaulted$
 true��6=   . �5w  "   �� $ border��6@   # � ��6T    � ��5x     P� 5y      �@J�IsMouseOver$
 true��6=   . �5z  "   �� $ border��6?    � �� �#D149BE6S   �� 5{  "   $ border��6@    � �� �#D149BE6T   5|     P� 5}      � ��$
 true��6;   . �5~  "   �� $ border��6?    � �� �#B846A86S   �� 5  "   $ border��6@    � �� �#B846A86T   5�     P� 5�      � {�$ false��6;   . �5�  "   �� $ border��6?   8   � ��6S   �� 5�  "   $ border��6@   8   � ��6T   �� 5�  "   $ contentPresenter��6K   8   � ��6i   5�     5�     5�     5�     �� 5�  
   .�5�     ��  � �� 5�     �� 5�     .R�5�     �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5�     5�     5�     �� 5�  
   $ 	#FFDDDDDD��6<   �� 5�  
   $ 	#FF707070��68   �� 5�  
   $ 	#FFBEE6FD��6?   �� 5�  
   $ 	#FF3C7FB1��6;   �� 5�  
   $ 	#FFC4E5F6��6=   �� 5�  
   $ 	#FF2C628B��69   �� 5�  
   $ 	#FFF4F4F4��6>   �� 5�  
   $ 	#FFADB2B5��6:   �� 5�  
   $ 	#FF838383��6>   �� 5�  
   "	 d�6+   .�5�     ��  �@�FocusVisualStyle8   61   �� 5�      � ��8  6+   �� 5�      � ��8  6,   �� 5�      � ��# � ��6+   �� 5�      � ��$ 1q�60   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��$ 1q�6(   �� 5�      � �� 5�     �� 5�     "
 d�6&   .R�5�     �� $ border��6!   $ 5��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5�     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5�      5�     P� 5�      �@��IsDefaulted$
 true��6D   . �5�  "   �� $ border��6@   # � ��6T    � ��5�     P� 5�      �@J�IsMouseOver$
 true��6=   . �5�  "   �� $ border��6?    � �� �#C211496S   �� 5�  "   $ border��6@   8   � ��6T   5�     P� 5�      � ��$
 true��6;   . �5�  "   �� $ border��6?    � �� �#C211496S   �� 5�  "   $ border��6@   8   � ��6T   5�     P� 5�      � {�$ false��6;   . �5�  "   �� $ border��6?    � �� �#C211496S   �� 5�  "   $ border��6@   8   � ��6T   �� 5�  "   $ contentPresenter��6K   8   � ��6i   5�     5�     5�     5�     �� 5�  
   .�5�     ��  � �� 5�     �� 5�     .R�5�     �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5�     5�     5�     �� 5�  
   $ 	#FFDDDDDD��6<   �� 5�  
   $ 	#FF707070��68   �� 5�  
   $ 	#FFBEE6FD��6?   �� 5�  
   $ 	#FF3C7FB1��6;   �� 5�  
   $ 	#FFC4E5F6��6=   �� 5�  
   $ 	#FF2C628B��69   �� 5�  
   $ 	#FFF4F4F4��6>   �� 5�  
   $ 	#FFADB2B5��6:   �� 5�  
   $ 	#FF838383��6>   �� 5�  
   "	 ��6%   .�5�     ��  �@�FocusVisualStyle8   61   �� 5�      � ��8  6+   �� 5�      � ��8  6,   �� 5�      � ��# � ��6+   �� 5�      � ��$ 1q�60   �� 5�      � ��$ Center=�6;   �� 5�      � ��$ Center=�69   �� 5�      � ��$ 1q�6(   �� 5�      � �� 5�     �� 5�     "
 ��6&   .R�5�     �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5�     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5�      5�     P� 5�      �@��IsDefaulted$
 true��6=   . �5�  "   �� $ border��6@   # � ��6T    � ��5�     P� 5�      �@J�IsMouseOver$
 true��6=   . �5�  "   �� $ border��6?   8   � ��6S   �� 5�  "   $ border��6@   8   � ��6T   5�     P� 5�      � ��$
 true��6;   . �5�  "   �� $ border��6?   8   � ��6S   �� 5�  "   $ border��6@   8   � ��6T   5�     P� 5�      � {�$ false��6;   . �5�  "   �� $ border��6?   8   � ��6S   �� 5�  "   $ border��6@   8   � ��6T   �� 5�  "   $ contentPresenter��6K   8 	  � ��6i   5�     5�     5�     5�     �� 5�  
   .�5�     ��  � �� 5�     �� 5�     .R�5�     �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5�     5      5     �� 5  
   $ 	#FFDDDDDD��6<   �� 5  
   $ 	#FF707070��68   �� 5  
   $ 	#FFBEE6FD��6?   �� 5  
   $ 	#FF3C7FB1��6;   �� 5  
   $ 	#FFC4E5F6��6=   �� 5  
   $ 	#FF2C628B��69   �� 5  
   $ 	#FFF4F4F4��6>   �� 5	  
   $ 	#FFADB2B5��6:   �� 5
  
   $ 	#FF838383��6>   �� 5  
   "	 ��6%   .�5     ��  �@�FocusVisualStyle8   61   �� 5      � ��8  6+   �� 5      � ��8  6,   �� 5      � ��# � ��6+   �� 5      � ��$ 1q�60   �� 5      � ��$ Center=�6;   �� 5      � ��$ Center=�69   �� 5      � ��$ 1q�6(   �� 5      � �� 5     �� 5     "
 ��6&   .R�5     �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5     �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5      5     P� 5      �@��IsDefaulted$
 true��6=   . �5  "   �� $ border��6@   # � ��6T    � ��5     P� 5      �@J�IsMouseOver$
 true��6=   . �5  "   �� $ border��6?   8   � ��6S   �� 5   "   $ border��6@   8   � ��6T   5!     P� 5"      � ��$
 true��6;   . �5#  "   �� $ border��6?   8   � ��6S   �� 5$  "   $ border��6@   8   � ��6T   5%     P� 5&      � {�$ false��6;   . �5'  "   �� $ border��6?   8   � ��6S   �� 5(  "   $ border��6@   8   � ��6T   �� 5)  "   $ contentPresenter��6K   8 	  � ��6i   5*     5,     5.     5/     50     .��51     �� ���	#FFE0CDED._�52  
   � .+�54     �� -   5        $
 menu��54     $	��160��6#   $
��Left=�6/   $��	0,100,0,0q�55     $ 0,50,0,0��6$   ���	#FF974CC1._�57     � .+�58     �� $��	0,0,0,100q�6!   .+�59     �� -   5         ��Name$ tentk��59  $   $��0 50 0 0q�63    �� TextAlignment$ Center=�6E   $��Segoe Print)�6\   ���	#FFE5A7E4$��14(�6�   6�   �� 5:     $��2��6!   ���	#FFE0CDED$	��Top=�6C   $��
20,40,20,0q�6[   6q   �� 5<     -   5         ��Name$ btnTrangChu��5<  H   #���   6!   $��0,20,0,0q�6]   $��40��6o   $	��130��6{   
������ $��0,0,0,0q�6�   ���	#FFF8F6F6.��5=     � $	��150��6#   .+�5>  "   �� $��/image/Home.png��6(   $��10 0 0 0q�6A   $
��Left=�6S   $��22��6n   6{   �� 5?  "   $��Trang Chủ��6,    �� Padding$ 0,0,40,0q�6>   $��Center=�6Q   $��Right=�6l   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5@     5A     �� 5B     -   5        $ btnDaMua��5B  H   #���   6!   $��0,10,0,0q�6Z   $��40��6l   $	��130��6x   
������ ���	#FFFCFBFB$��0,0,0,0q�6�   .��5C     � $	��150��6#   .+�5D  "   �� $��/image/order.png��6(   $��10,0,0,0q�6B   $
��Left=�6T   $��22��6o   6|   �� 5E  "   $��Đơn Hàng��6,   $ 0,0,40,0q�6<   $��Center=�6O   $��Right=�6j   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5F     5G     �� 5H     -   5        $ 
btnGioHang��5H  H   #���   6!   $��40��6]   $	��130��6i   $��0,10,0,0q�6u   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5I     � $	��150��6#   .+�5J  "   �� $��/image/cart.png��6(   $��10,0,0,0q�6A   $
��Left=�6S   $��22��6n   6{   �� 5K  "   $��Giỏ Hàng��6,   $ 0,0,45,0q�6<   $��Center=�6O   $��Right=�6j   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5L     5M     �� 5N     -   5        $ 
btnBanHang��5N  !   #���   66   $��40��6^   $	��130��6j   $��0,10,0,0q�6v   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5O     � $	��150��6#   .+�5P  "   �� $��/image/market2.png��6(   $��10,0,0,0q�6D   $
��Left=�6V   $��22��6q   6~   �� 5Q  "   $��
Bán Hàng��6,   $ 0,0,45,0q�6<   $��Center=�6O   $��Right=�6j   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5R     5S     �� 5T     -   5        $ btnyeuthich��5T  !   #���   67   $��40��6_   $	��130��6k   $��0,10,0,0q�6w   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5U     � $	��150��6#   .+�5V  "   �� $��/image/yeuthich2.png��6(   $��10,0,0,0q�6F   $
��Left=�6X   $��22��6s   6�   �� 5W  "   $��Yêu Thích��6,   $ 0,0,47,0q�6=   $��Center=�6P   $��Right=�6k   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5X     5Y     �� 5Z     -	   5        $ 	btnCaiDat��5Z  !   #���   65   $��40��6]   $	��130��6i   $��0,10,0,0q�6u   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5[     � $	��150��6#   .+�5\  "   �� -
   5         ��Name$ imagethongke��5\  (   $��/image/voucher1.png��6>   $��10,0,0,0q�6[   $
��Left=�6m   $��22��6�   6�   �� 5]  "   -   5        $ 
txtthongke��5]  ,   $��Mã giảm giá��6@   $ 0,0,30,0q�6S   $��Center=�6f   $��Right=�6�   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5^     5_     �� 5`     -   5        $ btnNguoiBan��5`  !   #���   67   $��40��6_   $	��130��6k   $��0,10,0,0q�6w   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5a     � $	��150��6#   .+�5b  "   �� $��/image/nguoiban1.png��6(   $��10,0,0,0q�6F   $
��Left=�6X   $��22��6s   6�   �� 5c  "   $��Người Bán��6,   $ 0,0,40,0q�6=   $��Center=�6P   $��Right=�6k   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5d     5e     �� 5f     -   5        $ btnNguoiMua��5f  !   #���   67   $��40��6_   $	��130��6k   $��0,10,0,0q�6w   
������ $��0,0,0,0q�6�   ���	#FFFCF8F8.��5g     � $	��150��6#   .+�5h  "   �� $��/image/nguoimua1.png��6(   $��10,0,0,0q�6F   $
��Left=�6X   $��22��6s   6�   �� 5i  "   $��Người Mua��6,   $ 0,0,35,0q�6=   $��Center=�6P   $��Right=�6k   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5j     5k     5m     �� 5o     -   5        $ btnDangXuat��5o  D   #���   6   $��40��6Y   $	��130��6e   
������ $��Bottom=�6�   $��0,0,0,30q�6�   $��0,0,0,0q�6�   .��5p     � $	��150��6   .+�5q     �� $��/image/logout.png��6$   $��10,0,0,0q�6?   $
��Left=�6Q   $��22��6l   6y   �� 5r     $��Đăng Xuất��6(   $ 0,0,35,0q�69   $��Center=�6L   $��Right=�6g   $��14(�6�   $
��Bold"�6�   ���	#FFDDDDDD6�   5s     5t     5u     5v     �� 5z     -   5        $
 logo��5z     $��80��6#   $��80��6.   $��2q�6:   
������ $
��Left=�5{     $	��Top=�60   $��	40,65,0,0q�5|     $ 50��6(   ._�5}     �� -   5        $ avatar��5}     $��/image/logoUser.png��6(   6H   5~     � 5�     $��70��6   $	��Top=�6   .+�5�     �� $��	0,0,160,0q�6   $ 0,0,70,0��6,   ��5�     �� 5�      �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5�     �  � Color$ Black��6+   � 5�     $ 	#FF974CC1��6+    � Offset$ 1Q�6=   5�     ._�5�     � .+�5�     �� -   5        $ 	btnThemSP��5�  H   #��� L 6!   ���	#FFDA2EBF$	��150��6r   $��35��6~   $	��Top=�6�   $��Right=�6�   $��	0,20,70,0q�6�   $��1,0,0,1q�6�   .��5�     ��  �� Orientation$ 
Horizontal=�6)   .+�5�  "   �� $��/image/add2.png��6(   $��25��6A   $��0,0,7,0q�6L   6_   �� 5�  "   $��Thêm sản phẩm��6,   $��Center=�6A   $��14(�6\   $
��Bold"�6j   
�������6�   5�     5�     d� 5�     -   5         d�Name$ 	thanhmenu��5�  T   #��� W 6'   $��35��6h   $��35��6s   
������ $
��Left=�6�   $��20,0,0,0q�6�   $��0,0,0,0q�6�   .��5�     �� $��/image/menu2.png��6$   6@   5�     �� 5�     -   5        $ imageTittle��5�      $	��180��65   $��/image/trangchu.png��6A   $��	150,0,0,0q�6_   $
��Left=�6r   6�   �� 5�     $	��280��6!   $��40��5�     ���	#FFF0E8E8$ 22��5�     $��1,1,1,1q�5�     
���   �$��	100,0,0,0q�5�     $��Center=�5�     $��Center=�5�     ._�5�     � .+�5�  "   �� -   5        $ timkiem1��5�  ,   $�� Tìm kiếm... ��6>   $��14(�6S   $��10,0,0,0q�6a   $��Center=�6s    J� Opacity$
 0.13Q�6�   �� 5�  "   -   5         ��Name$ 
txttimkiem��5�  *   $	��250��6>   $��25��6J   $��Center=�5�  $   $
��Left=�5�  $   $��10,0,0,0q�5�  $   $��0,0,0,0q�66   
���   �$��16(�6d   ��6r   Z� �� 5�  "   -   5        $ timkiem��5�  Q   #��� A 6*   $��38��6b   $��38��6m   $��Right=�6y   $��0,0,0,0q�6�   
������ ��6�   Z� .��5�  &   �� $��/image/search.png��6,   $��25��6G   5�  #   5�     5�     5�     5�     �� 5�     -   5        #���  5�     $��	0,10,10,0q�6@   $��35��6S   $��35��6^   $��Right=�6j   $	��Top=�5�     ���	#FFEA2929.��5�     �� $��image/shutdown2.png��6   $��18��69   6F   5�     5�     � 5�     -   5         �Name$ content��5�     ���	#FFE0CDED$��175 100 0 15q�6;   .+�5�     �� $��THANKS FOR USING��6   $��Center=�64   $��30(�6O   $��100 -200 0 0 q�6]   $
��Bold"�6t   6�   �� 5�     $��
OUR SYSTEM��6   $��Center=�6.   $��30(�6I   $��200 -100 0 0q�6W   $
��Bold"�6m   ���	#FFCE6AEE6   �� 5�     $4��.Admins can manage products, sellers and buyers��6   $��Center=�6R   $��15(�6m   $��
200 60 0 0q�6{   $
��Bold"�6�   ���	#FF1C04246�   �� 5�     $	��100��6   $	�� 35��6%   $ 20��62   ���	#FFE45FF9$
��Left=�6[   $��200 200 0 0q�6v   ._�5�     �� $��Get Started��6    $��Center=�63   $��Center=�6N   $��14(�6k   
�������6�   5�     �� 5�     $��20��6   $��20��6$   $��Bottom=�60   $��-100 0 0 50q�6K   ���	#FFAD73CE$ 50��6w   6�   �� 5�     $��20��6   $��20��6$   $��Bottom=�60   $��
100 0 0 50q�6K   ���	#FFAD73CE$ 50��6v   6�   �� 5�     $��20��6   $��20��6$   $��Bottom=�60   $��0 0 0 50q�6K   ���	#FFED84FE$ 50��6t   6�   �� 5�     $��/image/nen22.png��6   $	��500��62   $��Right=�6>   6\   �� 5�     -   5          ��Name$
  user��5�  !   61   5�     5�     5�     5�     