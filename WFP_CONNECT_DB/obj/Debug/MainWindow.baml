   M S B A M L   `   `   `  ����I  EWFP_CONNECT_DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WFP_CONNECT_DBWFP_CONNECT_DB  5   	       WFP_CONNECT_DB.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WFP_CONNECT_DB     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1080��6)    � 	Resources 5
       �� 
TargetType �� Property �� Value   
GnralStyle �� Triggers �� Binding �� ElementName �� Path	 �� Value
 �� CornerRadius � ToolTip  myStyle P� Property P� Value��%�  '��       &	  t     &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 5,0,5,0q�6'   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6#    5      �� 5       6   �� $ Nombre��$ (Validation.HasError)�	 True6b   .a�5      ��  � {� .  62   5      .�5      ��  � ��$ Center=�62   �� 5       � ��$ 0,2,40,2q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� 
���  ��$��right=�66   $��5,0,0,0q�6M   $��20��6^   $��20��6i   $
 10��6u    5      �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5    #   5!      �� 5"      $��customAdorner��68   $��Center=�6M   .v�5#   "   �� 
���  ��$��1q�6;   5$      5%      5&      5(      5)      �� 5*   
   " ��6    .�5+      ��  � ��
 ���� 6+   �� 5,       � ��$ Times New Roman)�6+   �� 5-       � ��$ 16(�6)    5.      P� 5/       �@J�IsMouseOver . . �50      ��  � ��
 ��  �63   �� 51       � ��
 �  ��63   52      54      55      .��57      ]� -   5        $��DockTop��57      $��Stretch=�6   $��Stretch=�6;   ��. $
��Auto��6n   $
��Auto��6|   .+�59   
   � -   5        $��GridPPal��59       � RowDefinitions 5:      �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    �� 5>      $
��Auto �6    �� 5?      $
��Auto �6     � ColumnDefinitions 5A      �� 5B      $
��1060 �6#   .+�5E      c� -   5         c�Name$ Tool1��5E      .@�5G      �� -   5         ��Name$ 
Button_add��5G      $ Agregar registro��6-   $	��New��6a   .��5H      �� -   5         ��Name$	 Add��5H      $��Resources/data_add.png��6)   $ Agregar registro��6I   5I      �� 5J      -   5        $ Button_edit��5J      $��0,0,0,0q�6.   .��5K      �� $��Resources/data_edit.png��6   $ Modificar registro��6=   5L      �� 5M      -   5        $ 
Button_del��5M      .��5N      �� $��Resources/data_delete.png��6   $ Borrar registro��6?   5O      �� 5Q      -   5        $ Button_cancel��5Q      $��	785,0,0,0q�60   .��5R      �� $��Resources/delete.png��6   $ Cancelar��6:   5S      �� 5T      -	   5        $ Button_exit��5T      $��5,0,0,0q�6H   .��5U      �� $��Resources/pgm_exit.png��6   $ Cerrar��6<   5V      5W      �� 5Y      -
   5        $��STLeft��5Y      $
��Auto��6'   $
��Auto��65   $
��Left=�6B   $��0,10,0,0q�6]   $��1��5Z      .+�5\      � -   5        $��
GridFields��5\      $
��Auto��6)   $
��Auto��66   $��0��6D    J� CommandBindings 5^      )  #System.Windows.Input.CommandBinding  5_      -   5           Command$	 New��5_   )   6V    5b      �� 5c      $
��Auto �6(   �� 5d      $
��Auto �6(   �� 5e      $
��Auto �6(   �� 5f      $
��Auto �6(   �� 5g      $
��Auto �6(   �� 5h      $
��Auto �6(   �� 5i      $
��Auto �6(   �� 5j      $
��Auto �6(    5l      �� 5m      $
��Auto �6+   $��50��68   �� 5n      $
��Auto �6+   �� 5o      $	��200 �6+   �� 5p      $
��Auto �6+   .+�5r      �� $��0��6   $��0��6)   $��ID Empleado:��69   $y�Hidden=�6P   �� 5s      $��1��6   $��0��6)   $��Nombre:��69   �� 5t      $��2��6   $��0��6)   $��	Apellido:��69   �� 5u      $��3��6   $��0��6)   $��Fecha de Nacimiento:��69   �� 5v      $��4��6   $��0��6)   $��Género:��69   �� 5w      $��5��6   $��0��6)   $��
Documento:��69   �� 5x      $��6��6   $��0��6)   $��E-Mail:��69   �� 5y      $��7��6   $��0��6)   $��
Domicilio:��69   $��26��6N   $	��Top=�6Z   �� 5{      -   5        $��FEmpId��5{      $��2��6,   $��0��6<   $��3q�6I   $y�Hidden=�6T   �� 5|      -   5        $��
FEmpNombre��5|      $��2��60   $��1��6@   $��3q�6M   #��[  5      ��5}      ��  �� UpdateSourceTrigger$ PropertyChanged=�$ Nombre� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5      �� 5�      -   5        $��FEmpApellido��5�      $��2��62   $��2��6B   $��3q�6O   #��[  5�      ��5�      �� $ PropertyChanged=�$ Apellido� .  . 5�      (  "System.Windows.Controls.DatePicker  5�      -   5        $��FEmpFechanac��5�   I   $��2��6!   $��3��61   $��3q�6>   $��Center=�5�   M   #��[  5�   )      SelectedDate 5�   )   �� $ FechaNacimiento� �� Mode$ TwoWay=�$ PropertyChanged=� .  . 5�   )   �� 5�      -   5        $��
FEmpGenero��5�   -   $��10(�6   $��2��6?   $��4��6O   $��3q�6\   .@�5�      �� $��	Masculino��6'    �� 
IsSelected . 6;   �� 5�      $��Femenino��6'   5�      �� 5�      -   5        $��FEmpDoc��5�      $��2��6-   $��5��6=   $��3q�6J   #��[  5�      ��5�      �� $ PropertyChanged=�$	 Doc� .  . 5�      �� 5�      -   5        $��	FEmpEmail��5�      $��2��6/   $��6��6?   $��3q�6L   #��[  5�      ��5�      �� $ PropertyChanged=�$ Email� .  . 5�      �� 5�      -   5        $��FEmpDomicilio��5�      $��2��63   $��7��6C   $��3q�6P   #��[  5�      ��5�      �� $ PropertyChanged=�$ 	Domicilio� .  . 5�      5�      5�      c� 5�      -   5        $ Tool2��5�      $��2��6%   .@�5�      � -   5        $��GridSeaarch��5�      $
��Auto��6*   $
��Auto��67    5�      �� 5�      $
��Auto �6(    5�      �� 5�      $
��Auto �6+   $��50��68   �� 5�      $
��Auto �6+   �� 5�      $	��200 �6+   �� 5�      $
��Auto �6+   �� 5�      $	��650 �6+   .+�5�      �� $��0��6   $��0��6)   $��Buscar:��69   �� 5�      -   5        $��FEmpSelField��5�   -   $��10(�6   $��1��6A   $��0��6Q   $��3q�6^   $
��Auto��6i   .@�5�      �� $��Campo filtro��6'    . 6>   �� 5�      $��ID��6'   �� 5�      $��Nombre��6'   �� 5�      $��Apellido��6'   �� 5�      $��	Fecha_nac��6'   �� 5�      $��Genero��6'   �� 5�      $��	Documento��6'   �� 5�      $��Email��6'   �� 5�      $��	Domicilio��6'   5�      �� 5�      -   5        $��
FEmpSearch��5�      $��2��63   $��0��6C   $��3q�6P   �� 5�      -   5        $ Button_search��5�      $��3��64   $��0��6D   $��3q�6Q   .��5�      �� $��Resources/data_find.png��6    $ Buscar��6A   5�      �� 5�      $��5��6$   $��Center=�64   .��5�      �� -   5         ��Name$
 Time��5�   $   ��62   �� *StTime+$ OneWay=�5�      �� 5�      $��5��6$   $��Right=�64   .��5�      � -   5         �Name$
 pbar��5�   &    � Value$ 0Q�64   $��80��6>   $��18��6I   5�      5�      5�      �� 5�      -   5        $��TopRight��5�      $
��Auto��6)   $
��1061��67   $
��Left=�6D   $��0,0,0,15q�6_   $��3��5�      .+�5�      �� -   5        $��lbl_grid��5�      $7��1No se encontraron reg                        ros.��5�      $��Center=�5�   .   $��16(�6K   $
��Bold"�6Y   ���	#FFE100006k   � 5�      $��10q�6   $��Center=�6(   .+�5�      &   System.Windows.Controls.DataGrid  -   5        $��GNRLData��5�   :      AutoGenerateColumns .    SelectionMode$ Single=�6J   $��15(�5�      $��0q�6)   
�������$��Visible=�6H   $	��150��6{   5�      5�      �� 5�      -   5        $��Footer��5�      $
��Auto��6'   $
��1061��65   $
��Left=�6B   $��Stretch=�6]   $��4��5�      .+�5�      c� -    5        $ Tool3��5�      $	��Top=�6)   $��30��6A   .@�5�      � -!   5          �Name$  
FooterGrid��5�       5�      �� 5�      $	��700 �6/   �� 5�      $	��330 �6/   .+�5�      �� -"   5        $��StText��5�   $   $��0��62   $��Verdana)�6B   $��10,0,0,0q�6W   $��Center=�6i   #��[ 5�   $   ��5�   $   �� *
StStatus+$ OneWay=��� 5�      -#   5        $	 ist��5�       $��1��6-   $ Status��5�   !   $��Right=�62   ��5�   =   �� *StatusImage+5�   2   5�      5�      5�      5�      5�      5�      