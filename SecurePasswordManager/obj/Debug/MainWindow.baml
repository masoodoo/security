   M S B A M L   `   `   `  ����  SecurePasswordManager&     SecurePasswordManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Password Vault��5   	   $	��600��6    $	��800��6-   ���#121212
�������.��5      � .+�5   
    � -   5          �Name$ 	MainFrame��5        � NavigationUIVisibility$ Hidden=�6#   ]� 5	   
   ���#FF8C00$��50��6)   $��
0,29,0,490q�65   .+�5
      �� $��🔐 Password Vault��6   $��20(�61   $��Center=�5      $
��10,0q�6+   
���   �$
��Bold"�5   #   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��تغییر رمز��5      $	��5,0q�5      
������ 6   �� 5      -   5         ��Name$ btnAddPassword��5      $!��➕ افزودن پسورد��62   $	��5,0q�5      
������ 6   5      5      �� 5   
   -   5         ��Name$ lstPasswords��5      $��
10,89,21,5q�6)    �� View 5      �� 5      .P�5      �� $��Service��6%    �� Width$	 200��66    �� DisplayMemberBinding 6B   �� *Name+�� 5      $��Username��6%   $	 150��67    6C   �� *
Username+�� 5      $��Password��6%   $	 150��67   	 �� CellTemplate	 5      �� 5      .R�5   "   G� $��0q�6L   
 G� Password
 6.   �� *
Password+6L   5      5       �� 5!      $��Actions��6%   $	 100��66   	 5"      �� 5#      .R�5$   "   �� $ 
Horizontal=�6-   .+�5%   &   �� -   5        $
��Edit��5%   -   $��2q�6P   �� 5&   &   -   5        $��Delete��5&   -   $��2q�6T   5'   #   5(      5*      5+      5-      5.      5/      