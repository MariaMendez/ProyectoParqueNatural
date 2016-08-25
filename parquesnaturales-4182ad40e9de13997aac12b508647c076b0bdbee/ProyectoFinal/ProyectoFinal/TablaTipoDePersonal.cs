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
    public partial class TablaTipoDePersonal : Form
    {
        public TablaTipoDePersonal()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TipoDePersonal_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonTipoPersonalVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            //validar si es administrador se pone menuadministrador
            //si es recursos humanos se pone mernu recursos
            MenuRecursosHumanos MenuRecursosHumanos = new MenuRecursosHumanos();
            MenuRecursosHumanos.ShowDialog();
          
        }

        private void buttonLimpiaTipoPersonal_Click(object sender, EventArgs e)
        {
            tipoperDescripción.Clear();
            tipoperID.Clear();
            tipoperNombre.Clear();
        }

        private void ComboBoxTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_tipoper from TIPO_PERSONAL";
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

                    ComboBoxTipoPersonal.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_tipoper")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
