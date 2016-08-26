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
        Controlador controladora = new Controlador();
        public TablaEspecies()
        {
            InitializeComponent();
            FillCombo1();
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


            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            //"Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;
            //"Data Source=DESKTOP-55UT6S1;User Id=parquenaturalv02;Password=clave;"
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select * from ESPECIE where id_ESPECIE='" + ComboBoxEspecies.Text + "'";
            OracleCommand cmd = new OracleCommand(query, databaseConnection);
            OracleDataReader myReader;

            try
            {
                databaseConnection.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string intID = myReader.GetInt64(myReader.GetOrdinal("id_ESPECIE")).ToString();
                   // String stringEspecie = myReader.GetChar(myReader.GetOrdinal("tipo_especie")).ToString();
                    String stringNombreCientifico = myReader.GetString(myReader.GetOrdinal("nom_cientifico_especie"));
                    String stringNombreVulgar = myReader.GetString(myReader.GetOrdinal("nom_vulgar_especie"));
                    string intNumIndividuos = myReader.GetInt64(myReader.GetOrdinal("num_individuos")).ToString();
                    //String stringFloracion = myReader.GetChar(myReader.GetOrdinal("floracion")).ToString();
                    String stringPeriodoFloracion = myReader.GetString(myReader.GetOrdinal("periodo_florac"));
                    String stringTipoAlimentacion = myReader.GetString(myReader.GetOrdinal("tipo_alimentacion"));
                    String stringPeriodoCelo = myReader.GetString(myReader.GetOrdinal("periodo_celo"));
                    String stringTipoMineral = myReader.GetString(myReader.GetOrdinal("tipo_mineral"));

                    espID.Text = intID;
                   // espTipoEspecie.Text = stringEspecie;
                    espNombreCientifico.Text = stringNombreCientifico;
                    espNombreVulgar.Text = stringNombreVulgar;
                    espNumeroIndividuos.Text = intNumIndividuos;
                   // espFloracion.Text = stringFloracion;
                    EspTipoAlimentacion.Text = stringTipoAlimentacion;
                    espPeriodoCelo.Text = stringPeriodoCelo;
                    espTipoMineral.Text = stringTipoMineral;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void espID_TextChanged(object sender, EventArgs e)
        {

        }

        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_especie from ESPECIE";
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

        private void buttonGuardaEspecies_Click(object sender, EventArgs e)
        {
            Char tipo = Char.Parse(espTipoEspecie.Text);
           
            int id = int.Parse(espID.Text);
            controladora.insertaEspecie(id,tipo,espNombreCientifico.Text,espNombreVulgar.Text,int.Parse(espNumeroIndividuos.Text), espFloracion.Text, espPeriodoFloracion.Text,EspTipoAlimentacion.Text,espPeriodoCelo.Text,espTipoMineral.Text);
        }

        
    }


}
