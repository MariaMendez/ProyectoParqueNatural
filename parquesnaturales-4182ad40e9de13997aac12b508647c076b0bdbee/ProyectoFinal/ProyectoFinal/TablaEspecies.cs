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
    public partial class TablaEspecies : Form
    {
        public TablaEspecies()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaEspecies_Load(object sender, EventArgs e)
        {

        }

        private void buttonEspeciesVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaEspecies_Click(object sender, EventArgs e)
        {
            espFloracion.Clear();
            espID.Clear();
            espNombreCientifico.Clear();
            espNombreVulgar.Clear();
            espNumeroIndividuos.Clear();
            espPeriodoCelo.Clear();
            espPeriodoFloracion.Clear();
            EspTipoAlimentacion.Clear();
            espTipoEspecie.Clear();
            espTipoMineral.Clear();

                
        }

        private void ComboBoxEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_especie from ESPECIES";
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

                   ComboBoxEspecies.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_especie")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
