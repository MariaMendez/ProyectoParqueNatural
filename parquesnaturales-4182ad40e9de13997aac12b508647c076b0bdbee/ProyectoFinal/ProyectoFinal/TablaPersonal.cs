﻿using Oracle.DataAccess.Client;
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
    public partial class TablaPersonal : Form
    {
        public TablaPersonal()
        {
            InitializeComponent();
            FillCombo1();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TablaPersonal_Load(object sender, EventArgs e)
        {

        }

        private void buttonPersonalVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministracion = new MenuAdministrador();
            MenuAdministracion.ShowDialog();
        }

        private void buttonLimpiaPersonal_Click(object sender, EventArgs e)
        {
            perscomboBox1TipoPersonal.Text = "";
            persComboBoxCodigoParque.Text = "";
            perscomboBoxProyecto.Text = "";
            persFecha.Clear();
            persID.Clear();
            persNombre.Clear();
            persSalario.Clear();
            persTelCasa.Clear();
            persTelMovil.Clear();
        }

        private void ComboBoxPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_personal from PERSONAL";
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

                    ComboBoxPersonal.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_personal")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
