using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class TablaArea : Form
    {

        Controlador controlador = new Controlador();

        public TablaArea()
        {
            InitializeComponent();
            FillCombo2();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void TablaArea_Load(object sender, EventArgs e)
        {

        }

        private void buttonAreaVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaArea_Click(object sender, EventArgs e)
        {
            areaExtension.Clear();
            areaNombre.Clear();
            areaID.Clear();
        }

        private void buttonGuardaArea_Click(object sender, EventArgs e)
        {
            string idArea = areaID.Text;
            string nombreArea = areaNombre.Text;
            string extensionArea = areaExtension.Text;
            controlador.insertaArea(idArea,nombreArea,extensionArea);
            areaExtension.Clear();
            areaNombre.Clear();
            areaID.Clear();
            MessageBox.Show("Registro guardado", "");

        }

        private void buttonActualizarArea_Click(object sender, EventArgs e)
        {
           
        }

        private void ComboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo2()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_area from AREA";
            OracleCommand cmd = new OracleCommand(query, databaseConnection);
            OracleDataReader myReader;

            try
            {
                databaseConnection.Open();
                myReader = cmd.ExecuteReader();  //exception due to this line

                while (myReader.Read())
                {

                    //string sIdParque = myReader.GetString(4);
                    //aloComboBoxParque.Items.Add(sIdParque);

                    ComboBoxArea.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_area")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

}

