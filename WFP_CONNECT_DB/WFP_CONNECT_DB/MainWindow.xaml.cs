//Autor/Alumno/Desarrollador: Cristian Ariel Cebey
//Tipo de programa: AMB hecho en WPF.
//Materia: Ingeniería de Sistemas
//Profesor: Gabriel Esquivel
//Institución: IFTS N° 18
//Fecha de entrega: 30/06/2016
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Data.OleDb;
using System.Data;
using System.Threading;

namespace WFP_CONNECT_DB
{
    public partial class MainWindow : Window
    {
        OleDbConnection conector;
        DataTable dt;
        bool gv_save;

        public MainWindow()
        {
            InitializeComponent();
            //Conecto la DB
            conector = new OleDbConnection();
            conector.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\wpf_db.mdb";
            //Deshabilito campo ID para el ingreso de datos
            FEmpId.IsEnabled = false;
            //Muestro Grid
            BindGrid();
            // Seteo ID nuevo
            Get_rowid();
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


            //Controlo la barra de progreso
            if (dt.Rows.Count > 0 && FEmpSelField.Text != "" && FEmpSearch.Text != "")

            {
                for (int i = 0; i < 100; i++)
                {
                    pbar.Value++;
                    Thread.Sleep(5);
                }
            }

            else
                pbar.Value = 0;


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

            if (FEmpId.Text != "" && FEmpNombre.Text != "" && FEmpApellido.Text != "" && FEmpFechanac.Text != "" &&
                FEmpDoc.Text != "" && FEmpDomicilio.Text != "")
            {
                if (gv_save == false)
                {
                    if (FEmpGenero.Text != "Seleccione género")
                    {
                        cmd.CommandText = "INSERT INTO TBL_EMPLE(Id,Nombre,Apellido,Fecha_nac,Genero,Documento,Email,Domicilio) Values (" + FEmpId.Text + ",'" + FEmpNombre.Text + "','" + FEmpApellido.Text + "','" + FEmpFechanac.Text + "','" + FEmpGenero.Text + "','" + FEmpDoc.Text + "','" + FEmpEmail.Text + "','" + FEmpDomicilio.Text + "')";
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        MessageBox.Show("Registro ingresado exitosamente...");
                        ClearAll();

                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione una opción....");
                    }
                }
                else
                {
                    cmd.CommandText = "update TBL_EMPLE set Nombre='" + FEmpNombre.Text + "',Apellido='" + FEmpApellido.Text + "',Fecha_nac='" + FEmpFechanac.Text + "',Genero='" + FEmpGenero.Text + "',Documento='" + FEmpDoc.Text + "',Email='" + FEmpEmail.Text + "',Domicilio='" + FEmpDomicilio.Text + "' where Id=" + FEmpId.Text;
                    cmd.ExecuteNonQuery();
                    gv_save = false;
                    BindGrid();
                    MessageBox.Show("Registro actualizado exitosamente...");
                    Add.Source = new BitmapImage(new Uri("Resources/data_add.png", UriKind.RelativeOrAbsolute));
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese los datos del empleado.......");
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
            FEmpId.Text = "";
            FEmpNombre.Text = "";
            FEmpApellido.Text = "";
            FEmpFechanac.Text = "";
            FEmpGenero.SelectedIndex = 0;
            FEmpDoc.Text = "";
            FEmpEmail.Text = "";
            FEmpDomicilio.Text = "";
            FEmpId.IsEnabled = false;
            // Seteo ID nuevo
            Get_rowid();
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
                MessageBox.Show("Por favor seleccione un empleado de la lista...");
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
                MessageBox.Show("Registro borrado exitosamente...");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un empleado de la lista...");
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
    }
}
