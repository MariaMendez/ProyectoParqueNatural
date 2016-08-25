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
    public partial class TablaVisitante_Gestor : Form
    {
        public TablaVisitante_Gestor()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonVisitantesGVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuGestor MenuGestor = new MenuGestor();
            MenuGestor.ShowDialog();
        }

        private void buttonLimpiaVisitantesG_Click(object sender, EventArgs e)
        {
            visgComboBoxCodAlojamiento.Text = "";
            visgDNI.Clear();
            visgDomicilio.Clear();
            visgID.Clear();
            visgNombre.Clear();
            visgProfesion.Clear();
            
        }

        private void ComboBoxVisitantesG_SelectedIndexChanged(object sender, EventArgs e)
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

                    ComboBoxVisitantesG.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_visita")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

