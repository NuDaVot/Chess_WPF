   M S B A M L   `   `   `  ����A  =Chess2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chess2.ViewsChess2.Views  5      5clr-namespace:Chess2.ViewModelsChess2.ViewModels  5      I EShowMeTheXAML, Version=2.0.0.62, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAMLShowMeTheXAML 5	          Chess2.Views.GamePage   5      Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chess2.Views     5      .vmclr-namespace:Chess2.ViewModels     5      _	 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      =smtx2clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML 	 5	        N� Title$  GamePage��5       � DataContext 5      )  #Chess2.ViewModels.GamePageViewModel  5   
   .��5      � ���#FFFFF0 � ColumnDefinitions 5   
   �� 5      $
��560* �6   �� 5      $
��800* �6   �� 5      $
��560* �6    � RowDefinitions 5   
   �� 5      $	��53* �6   �� 5      $
��400* �6   �� 5      $	��53* �6   .+�5   
   (� $��0��6   $��1��5       (� Stretch$ Uniform=�5      .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $
��Left=�5       .+�5!      �� $��40��5"      $��40��5#      ��5!      �� *ProfileIcon+5#      �� 5$      $��40��6   $	��320��5%         TextBlockStyle#��[  5&      $��28(�5'      $��Opponent(1999)��5(       �� TextAlignment$
 Left=�5)      $��30,0,0,0q�5*      ���	#FF6968685+      �� 5,      
���   �$��1q�5-       �� CornerRadius$ 10��5.       �� Padding$ 4q�5/      
���   �$��40��51      $	��240��52      ._�53      �� $��10:00��6    #��[  54       
���   �
�������$��23(�57       $��	70,0,70,0q�58       $��SemiBold"�59       5:      5;      5<      (� 5=   
   $��2��6   $��1��5>      $ Uniform=�5?      .��5@      �� $ 
Horizontal=�6   $��Center=�5A      $
��Left=�5B      .+�5C      �� $��40��5D      $��40��5E      ��5C      �� *ProfileIcon+5E      �� 5F      $��40��6   $	��320��5G      #��[  5H      $��28(�5I      $��Ya(1999)��5J      $
 Left=�5K      $��30,0,0,0q�5L      ���	#FF6968685M      �� 5N      
���   �$��2q�5O      $ 10��5P      $ 4q�5Q      
�������$��40��5S      $	��240��5T      ._�5U      �� $��10:00��6    #��[  5V       
����������	#FF696868$��23(�5Y       $��	70,0,70,0q�5Z       $��SemiBold"�5[       5\      5]      5^      (� 5_   
   $��0��6   $��0��5`      $
��Left=�5a      .��5b      �� $ Vertical=�6   $
��Left=�5c      $��Center=�5d      .+�5e      ��   ButtonStyle#��[ 6   $��	Surrender��5f      $��30(�5g      $	��182��5h      $��45��5i      $��	0,25,30,0q�6%   �� 5j      #��[ 6   $��Offer��5k      $��30(�5l      $	��182��5m      $��45��5n      $��	0,25,30,0q�6%   5o      5p      (� 5q   
   $��0��6   $��2��5r      $��Right=�5s      .��5t      �� $ 
Horizontal=�6   $��Center=�5u      $��Right=�5v      .+�5w      ��   ButtonStyleBlackOpponent#��[ 6   $��40��5x      $��40��5y      $��	0,20,20,0q�5z      ��5{      �� 5|      	 �� ImageSource	 6%   �� *Search+5~      5      5�        ShowMeTheXAML.XamlDisplay  5�   
   $��2��6   $��4��5�      .��5�      ) 	 #MaterialDesignThemes.Wpf.DrawerHost  -   5        $��
DrawerHost��5�   (   
���   �5�      5�       � 5�   
   $��1��6   $��1��6   
  � Source$
 
Board.xaml?�6-   6C   5�      5�      