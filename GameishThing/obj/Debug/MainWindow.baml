   M S B A M L   `   `   `  ����G  CGameishThing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GameishThingGameishThing  5   	       GameishThing.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GameishThing     5   	   -   5          � Title$  
MainWindow��5   	   $	��800��5	   	   $
��1000��6   $	��720��5
   	   $	��930��6   .��5      �  � RowDefinitions 5   
   �� 5      $��64 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��20,5q�6.   .+�5      �� -   5        $��score_tb��5      $��36(�6(   $
��Bold"�66   $��Center=�6H   06f   5      � 5   
   $��1��5      ��5      ��  �� Path$ ActualWidth� �� ElementName$ Canvas����5      �� $ ActualHeight�$ Canvas�� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      
BlurRadius$ 20Q�61      Color$ 	#FF7E0000��6A   	   ShadowDepth$	 0Q�6S   
   Opacity$
 2Q�6c      RenderingBias$ Quality=�6o   .+�5      �� -   5        $��Canvas��5      $	��900��5      $	��600��6!   
�������5      5       5"      5#      