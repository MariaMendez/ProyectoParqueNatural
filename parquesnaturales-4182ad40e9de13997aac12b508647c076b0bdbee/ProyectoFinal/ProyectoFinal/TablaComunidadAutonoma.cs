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
    public partial class TablaComunidadAutonoma : Form
    {
        public TablaComunidadAutonoma()
        {
            InitializeComponent();
            FillCombo1();
            FillCombo2();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaComunidadAutonoma_Load(object sender, EventArgs e)
        {

        }

        private void buttonComunidadVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaComunidadAutonoma_Click(object sender, EventArgs e)
        {
            comID.Clear();
            comNombre.Clear();
            comNumero.Clear();
            comSuperficieDeclarada.Clear();
            comComboBoxOrganismo.Text = "";
        }

        private void ComboBoxComunidadAutonoma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_ca from COMUNIDAD_AUTONOMA";
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

                    ComboBoxComunidadAutonoma.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_ca")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comComboBoxOrganismo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void FillCombo2()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select cod_organismo from COMUNIDAD_AUTONOMA";
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

                    comComboBoxOrganismo.Items.Add(myReader.GetInt64(myReader.GetOrdinal("cod_organismo")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

