using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class TablaExcursion : Form
    {
        public TablaExcursion()
        {
            InitializeComponent();
            FillCombo1();
            FillCombo2();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaExcursion_Load(object sender, EventArgs e)
        {

        }

        private void buttonExcursionVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaExcursion_Click(object sender, EventArgs e)
        {
            excComboBoxCodAlojamiento.Text = "";
            excFecha.Clear();
            excHora.Clear();
            excID.Clear();
            excTipoExcursion.Clear();
        }

        private void ComboBoxExcursion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_excursion from EXCURSION";
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

                    ComboBoxExcursion.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_excursion")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void excComboBoxCodAlojamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo2()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select cod_alojamiento from EXCURSION";
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

                    excComboBoxCodAlojamiento.Items.Add(myReader.GetInt64(myReader.GetOrdinal("cod_alojamiento")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}





