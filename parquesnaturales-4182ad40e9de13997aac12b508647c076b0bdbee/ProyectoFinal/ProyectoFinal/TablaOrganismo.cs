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
    public partial class TablaOrganismo : Form
    {
        Controlador controladora=new Controlador();
        public TablaOrganismo()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Organismo_Load(object sender, EventArgs e)
        {

        }




        private void buttonLimpiaOrganismo1_Click(object sender, EventArgs e)
        {
            orgDireccion.Clear();
            orgID.Clear();
            orgNombre.Clear();
        }

        private void buttonOrganismoVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void ComboBoxOrganismo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_organismo from ORGANISMO";
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

                    ComboBoxOrganismo.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_organismo")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonGuardaOrganismo_Click(object sender, EventArgs e)
        {
            controladora.insertaOrganismo(int.Parse(orgID.Text),orgNombre.Text,orgDireccion.Text);
        }
    }
}
