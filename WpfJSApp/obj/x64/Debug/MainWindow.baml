   M S B A M L   `   `   `  ����C  ?WpfJSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfJSAppWpfJSApp  5   	   T PCefSharp.Wpf, Version=63.0.3.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 5   	       WpfJSApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfJSApp     5   	   ECefSharp0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $
��1000��6,   $
��1000��69    � WindowState$ 	Maximized=�6I    � Icon$ Images/Browser.png��6a   .��5
      �  � RowDefinitions 5   
   �� 5      $��34 �6   6+   �� 5      $��* �6   6*   �� 5      $��30 �6   6+   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   
�������$��2q�6M   .+�5      �� -   5        $��	txtAdress��5      $	��500��6g   $��5q�6v   ��6'   ��  �� ElementName$ browser�� �� Path$ Address� �� Mode$ TwoWay=�6�   �� 5      -   5        $��5q�5      .��65   Call from string6G   �� 5      -   5        $��5q�5      .��67   ,*1 click Load html 2 click - JS func invoke6d   �� 5      -   5        $��5q�5      .��67   rtrn val frm scrpt6K   �� 5      -   5        $��5q�5      .��67   
JS to .NET6C   5      �� 5   
   -   5        $��	container��5   &   $��1��6   5      �� 5   
   $��2��6   $��2q�6!   
�������.@�5      �� .��6   Status bar:6*   �� 5      -   5        $��stsBar1��5      6-   5      5      5      