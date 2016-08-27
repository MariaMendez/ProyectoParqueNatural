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
    public partial class TablaVisitantes : Form
    {
        public TablaVisitantes()
        {
            InitializeComponent();
            FillCombo1();
            FillCombo2();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaVisitantes_Load(object sender, EventArgs e)
        {

        }

        private void buttonVisitantesVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaVisitantes_Click(object sender, EventArgs e)
        {
            visComboBoxCodAlojamiento.Text = "";
            visDNI.Clear();
            visDomicilio.Clear();
            visID.Clear();
            visNombre.Clear();
            visProfesion.Clear();
        }

        private void ComboBoxVisitantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_visita from VISITANTE";
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

                    ComboBoxVisitantes.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_visita")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonGuardaVisitantes_Click(object sender, EventArgs e)
        {
            Controlador elControlador = new Controlador();
            elControlador.insertaVisitante(int.Parse(visID.Text), int.Parse(visDNI.Text), visNombre.Text, visDomicilio.Text, visProfesion.Text, int.Parse(visComboBoxCodAlojamiento.Text));
        }
        void FillCombo2()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select cod_alojamiento from VISITANTE";
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

                    visComboBoxCodAlojamiento.Items.Add(myReader.GetInt64(myReader.GetOrdinal("cod_alojamiento")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

}
