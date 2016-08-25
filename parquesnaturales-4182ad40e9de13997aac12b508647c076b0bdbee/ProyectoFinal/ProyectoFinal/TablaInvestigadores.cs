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
    public partial class TablaInvestigadores : Form
    {
        public TablaInvestigadores()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaInvestigadores_Load(object sender, EventArgs e)
        {

        }


        private void buttonInvestigadorVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void buttonLimpiaInvestigador_Click(object sender, EventArgs e)
        {
            invID.Clear();
            invNombre.Clear();
            invTelefono.Clear();
            invTitulo.Clear();
            invApellido.Clear();
        }

        private void ComboBoxInvestigador_SelectedIndexChanged(object sender, EventArgs e)
        {

   
        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_inv from INVESTIGADOR";
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

                    ComboBoxInvestigador.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_inv")));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
