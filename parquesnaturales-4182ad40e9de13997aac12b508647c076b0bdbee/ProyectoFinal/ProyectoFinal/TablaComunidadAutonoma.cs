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

        Controlador controladora = new Controlador();
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

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            //"Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;
            //"Data Source=DESKTOP-55UT6S1;User Id=parquenaturalv02;Password=clave;"
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select * from COMUNIDAD_AUTONOMA where id_ca='" + ComboBoxComunidadAutonoma.Text + "'";
            OracleCommand cmd = new OracleCommand(query, databaseConnection);
            OracleDataReader myReader;

            try
            {
                databaseConnection.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string intArea = myReader.GetInt64(myReader.GetOrdinal("id_ca")).ToString();
                    String stringNombre = myReader.GetString(myReader.GetOrdinal("nombre_ca"));
                    string intNumParque = myReader.GetInt64(myReader.GetOrdinal("num_parque")).ToString();
                    string intSuperDeclarada = myReader.GetInt64(myReader.GetOrdinal("sup_declarada")).ToString();
                    comID.Text = intArea;
                    comNombre.Text = stringNombre;
                    comNumero.Text = intNumParque;
                    comSuperficieDeclarada.Text = intSuperDeclarada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void buttonGuardaComunidadAutonoma_Click(object sender, EventArgs e)
        {
            controladora.insertaComunidad(int.Parse(comID.Text),comNombre.Text,int.Parse(comNumero.Text), int.Parse(comSuperficieDeclarada.Text), int.Parse(comComboBoxOrganismo.Text));
        }
    }
}
