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
    public partial class TablaParquesNaturales : Form
    {
        public TablaParquesNaturales()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Parques_Naturales_Load(object sender, EventArgs e)
        {

        }

        private void buttonParqueNaturalVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaParqueNatural_Click(object sender, EventArgs e)
        {
            parqueFecha.Clear();
            parqueID.Clear();
            parqueNombre.Clear();
        }

        private void ComboBoxParqueNatural_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_parque from PARQUE_NATURAL";
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

                    ComboBoxParqueNatural.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_parque")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
