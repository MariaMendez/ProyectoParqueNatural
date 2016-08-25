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
    public partial class TablaProyectos : Form
    {
        public TablaProyectos()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaProyectos_Load(object sender, EventArgs e)
        {

        }

        private void buttonProyectosVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaProyectos_Click(object sender, EventArgs e)
        {
            proyComboBoxCodInvestigador.Text = "";
            proyFecFinal.Clear();
            proyFecInicio.Clear();
            proyPresupuesto.Clear();
            proyID.Clear();
        }

        private void ComboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_proyecto from PROYECTO";
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

                    ComboBoxProyectos.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_proyecto")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
