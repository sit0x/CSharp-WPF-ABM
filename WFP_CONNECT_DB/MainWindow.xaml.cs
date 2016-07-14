//Autor/Alumno/Desarrollador: Cristian Ariel Cebey
//Tipo de programa: AMB hecho en WPF.
//Materia: Ingeniería de Sistemas
//Profesor: Gabriel Esquivel
//Institución: IFTS N° 18
//Fecha de entrega Parcial: 30/06/2016
//FINAL
//Fecha de entrega Final: 14/07/2016
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Data.OleDb;
using System.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;

namespace WFP_CONNECT_DB
{
    public partial class MainWindow : Window
    {

        int _noOfErrorsOnScreen = 0;
        private Customer _customer = new Customer();
        OleDbConnection conector;
        DataTable dt;
        bool gv_save;
        DispatcherTimer dispatcher = new DispatcherTimer();
        long gv_time = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            //Clase que valida parámetros de entrada
            GridFields.DataContext = _customer;
            //Inicializo el status
            updateStatus("Aguardando acción", "Resources/clock.png");
            //Conecto la DB
            conector = new OleDbConnection();
            conector.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\wpf_db.mdb";
            //Deshabilito campo ID
            FEmpId.IsEnabled = false;
            //Muestro Grid
            BindGrid();
            //Inicializo Timmer
            InitializeTimer();
            ClearAll();
            
        }

        //Seteo message status
        private void updateStatus(string value, string ImageSource)
        {
            this.StText.Text = value;
            this.ist.Source = new BitmapImage(new Uri(ImageSource, UriKind.RelativeOrAbsolute)); ;
        }

        //Muestro DB en el Grid
        private void BindGrid()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (conector.State != ConnectionState.Open)
                conector.Open();
            cmd.Connection = conector;

            if (FEmpSearch.Text != "")
            {
                cmd.CommandText = "select * from tbl_emple where " + FEmpSelField.Text + " like '%" + FEmpSearch.Text + "%' order by Id";
            }
            else
                cmd.CommandText = "select * from tbl_emple order by Id";

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            GNRLData.ItemsSource = dt.AsDataView();


            if (dt.Rows.Count > 0)
            {
                lbl_grid.Visibility = Visibility.Hidden;
                GNRLData.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_grid.Visibility = Visibility.Visible;
                GNRLData.Visibility = Visibility.Hidden;
            }

        }

        //Agrego registro al Grid y a la DB
        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (conector.State != ConnectionState.Open)
                conector.Open();
            cmd.Connection = conector;

            if (FEmpNombre.Text != "" && FEmpApellido.Text != "" && FEmpFechanac.Text != "" &&
                FEmpDoc.Text != "" && FEmpDomicilio.Text != "")
            {
                if (gv_save == false)
                {
                    if (FEmpGenero.Text != " ")
                    {
                        cmd.CommandText = "INSERT INTO TBL_EMPLE(Nombre,Apellido,Fecha_nac,Genero,Documento,Email,Domicilio) Values ('" + FEmpNombre.Text + "','" + FEmpApellido.Text + "','" + FEmpFechanac.Text + "','" + FEmpGenero.Text + "','" + FEmpDoc.Text + "','" + FEmpEmail.Text + "','" + FEmpDomicilio.Text + "')";
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        updateStatus("Registro ingresado exitosamente", "Resources/disk_blue_ok.png");
                        pbar.Value = 100;
                        ClearAll();
                    }
                    else
                    {
                        updateStatus("Por favor seleccione una opción", "Resources/disk_blue_warning.png");
                    }
                }
                else
                {
                    DataRowView row = (DataRowView)GNRLData.SelectedItems[0];
                    cmd.CommandText = "update TBL_EMPLE set Nombre='" + FEmpNombre.Text + "',Apellido='" + FEmpApellido.Text + "',Fecha_nac='" + FEmpFechanac.Text + "',Genero='" + FEmpGenero.Text + "',Documento='" + FEmpDoc.Text + "',Email='" + FEmpEmail.Text + "',Domicilio='" + FEmpDomicilio.Text + "' where Id=" + FEmpId.Text;
                    cmd.ExecuteNonQuery();
                    gv_save = false;
                    BindGrid();
                    updateStatus("Registro actualizado exitosamente", "Resources/disk_blue_ok.png");
                    Add.Source = new BitmapImage(new Uri("Resources/data_add.png", UriKind.RelativeOrAbsolute));
                    pbar.Value = 100;
                    ClearAll();
                }
            }
            else
            {
                updateStatus("Por favor ingrese los datos obligatorios del empleado", "Resources/disk_blue_warning.png");
            }
        }
        //Calculo y seteo ID
        private void Get_rowid()
        {
            int lv_countid;
            lv_countid = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Id"]) + 1;
            FEmpId.Text = lv_countid.ToString();
        }

        //Limpio todos los campos
        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            Add.Source = new BitmapImage(new Uri("Resources/data_add.png", UriKind.RelativeOrAbsolute));
            ClearAll();
        }
        //Limpio campos de la pantalla
        private void ClearAll()
        {
            FEmpNombre.Text = "";
            FEmpApellido.Text = "";
            FEmpFechanac.Text = "";
            FEmpGenero.SelectedIndex = 0;
            FEmpDoc.Text = "";
            FEmpEmail.Text = "";
            FEmpDomicilio.Text = "";
            FEmpId.IsEnabled = false;

            //updateStatus("Aguardando acción", "Resources/clock.png");
        }

        //Actualizo registros del Grid
        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            if (GNRLData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)GNRLData.SelectedItems[0];
                FEmpId.Text = row["Id"].ToString();
                FEmpNombre.Text = row["Nombre"].ToString();
                FEmpApellido.Text = row["Apellido"].ToString();
                FEmpFechanac.Text = row["Fecha_nac"].ToString();
                FEmpGenero.Text = row["Genero"].ToString();
                FEmpDoc.Text = row["Documento"].ToString();
                FEmpEmail.Text = row["Email"].ToString();
                FEmpDomicilio.Text = row["Domicilio"].ToString();
                FEmpId.IsEnabled = false;
                Add.Source = new BitmapImage(new Uri("Resources/save_as.png", UriKind.RelativeOrAbsolute));
                gv_save = true;
            }
            else
            {
                updateStatus("Por favor seleccione un empleado de la lista", "Resources/disk_blue_warning.png");
            }
        }

        //Borro un registro del Grid y la DB
        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            if (GNRLData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)GNRLData.SelectedItems[0];

                OleDbCommand cmd = new OleDbCommand();
                if (conector.State != ConnectionState.Open)
                    conector.Open();
                cmd.Connection = conector;
                cmd.CommandText = "delete from TBL_EMPLE where Id=" + row["Id"].ToString();
                cmd.ExecuteNonQuery();
                BindGrid();
                updateStatus("Registro borrado exitosamente", "Resources/disk_blue_ok.png");
                pbar.Value = 100;
                ClearAll();
            }
            else
            {
                updateStatus("Por favor seleccione un empleado de la lista", "Resources/disk_blue_warning.png");
            }
        }
        //Busco el dato ingresado
        private void Button_search_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        //Cierro la APP
        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Incremento o decremento el contador de errores
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }
        //Habilito o deshabilito boton
        private void AddEmp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void AddEmp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Customer cust = GridFields.DataContext as Customer;
            _customer = new Customer();
            GridFields.DataContext = _customer;
            e.Handled = true;

        }

        private void esNuevo()
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
        }

        private void InitializeTimer()
        {
            // Llamo a este proceso cuando la aplicacion inicia.
            // Seteo el intervalo en 1 segundo
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Tick += new EventHandler(Dispatcher_Tick);

            // Enable timer.
            dispatcher.IsEnabled = true;
            dispatcher.Start();
            
        }
        private void Dispatcher_Tick(object Sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();

            if (StText.Text != "Aguardando acción")
            {
                if (gv_time == 0)
                    gv_time = DateTime.Now.Ticks;
                else
                {
                    if (TimeSpan.FromTicks(DateTime.Now.Ticks - gv_time).Seconds > 3)
                    {
                        pbar.Value = 0;
                        gv_time = 0;
                        updateStatus("Aguardando acción", "Resources/clock.png");
                    }
                }
            }
        }
        
    }
}
