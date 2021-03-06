﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{

    public partial class TablaAlojamiento : Form
    {
        //OracleConnection databaseConnection = new OracleConnection("Data Source=DESKTOP-55UT6S1;User Id=parquenaturalv02;Password=clave;");
        Controlador controlador = new Controlador();
        public TablaAlojamiento()
        {
            InitializeComponent();
            FillCombo1();
            FillCombo2();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonLimpiaAlojamiento_Click(object sender, EventArgs e)
        {
            aloCategoria.Clear();
            aloID.Clear();
            aloCapacidad.Clear();
            aloComboBoxParque.Text = "";

        }

        private void buttonGuardaAlojamiento_Click(object sender, EventArgs e)
        {
          
            Int64 capacidad= Int64.Parse(aloCapacidad.Text);
            Int64 codigoParque= Int64.Parse(aloComboBoxParque.Text);
            Int64 id = Int64.Parse(aloID.Text);
            controlador.insertaAlojamiento(id,aloCategoria.Text,capacidad,codigoParque);
            
        }

        private void aloCapacidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void aloCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonActualizarAlojamiento_Click(object sender, EventArgs e)
        {

            Int64 id = Int64.Parse(aloID.Text);
            controlador.actualizaCategoria(id, aloCategoria.Text);
            MessageBox.Show("Registro Actualizado", "");
        }

        private void buttonEliminaAlojamiento_Click(object sender, EventArgs e)
        {
            //Int64 id = Int64.Parse(aloID.Text);
            //controlador.eliminarAlojamiento(id);
        }

        private void ComboBoxAlojamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            //"Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;
            //"Data Source=DESKTOP-55UT6S1;User Id=parquenaturalv02;Password=clave;"
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe");
            string query = "select * from ALOJAMIENTO where id_alojamiento='" + ComboBoxAlojamiento.Text + "'";
            OracleCommand cmd = new OracleCommand(query, databaseConnection);
            OracleDataReader myReader;
            
            try
            {
                databaseConnection.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    //  aloComboBoxParque.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_parque")));

                    string intIdentificacion = myReader.GetInt64(myReader.GetOrdinal("id_alojamiento")).ToString();
                    String stringCategoria = myReader.GetString(myReader.GetOrdinal("categoria"));
                    String stringCapacidad = myReader.GetInt64(myReader.GetOrdinal("capacidad")).ToString(); ;
                    aloID.Text = intIdentificacion;
                    aloCategoria.Text = stringCategoria;
                    aloCapacidad.Text = stringCapacidad;


                    // Int64 intIdentificacion = myReader.GetInt64(myReader.GetOrdinal("id_alojamiento"));



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void aloID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAlojamientoVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador MenuAdministrador = new MenuAdministrador();
            MenuAdministrador.ShowDialog();
        }

        private void aloComboBoxParque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TablaAlojamiento_Load(object sender, EventArgs e)
        {
            
        }



        void FillCombo1()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            //"Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;
            //"Data Source=DESKTOP-55UT6S1;User Id=parquenaturalv02;Password=clave;"
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_parque from ALOJAMIENTO";
            OracleCommand cmd = new OracleCommand(query, databaseConnection);
            OracleDataReader myReader;
     
            try
            {
                databaseConnection.Open();
                myReader = cmd.ExecuteReader();  //exception due to this line

                while (myReader.Read())
                {

                   // string sIdParque = myReader.GetString(4);
                   // aloComboBoxParque.Items.Add(sIdParque);

                    aloComboBoxParque.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_parque")));
                    //aloComboBoxParque.Ite

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void FillCombo2()
        {

            //**RECUERDEN CAMBIAR EL DATA SOURCE, Jeje
            OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
            string query = "select id_alojamiento from ALOJAMIENTO";
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

                    ComboBoxAlojamiento.Items.Add(myReader.GetInt64(myReader.GetOrdinal("id_alojamiento")));
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }


  }











