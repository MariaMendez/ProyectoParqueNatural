using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.OleDb;




namespace ProyectoFinal
{
    public partial class InicioSesion : Form
    {


       

        public InicioSesion()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void textoUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }



        public void buttonIngresar_Click(object sender, EventArgs e)
        {
            
           
               try
               {
                string usuario = textoUsuario.Text.ToString();
                string pass = textoContraseña.Text.ToString();
                string conexion = ("Data Source=MARIA-HP;User Id=" + usuario + ";" + "Password=" + pass + ";");
                OracleConnection databaseConnection = new OracleConnection(conexion);
                databaseConnection.Open();
                }
                catch (Exception ex)
                {
                MessageBox.Show("Usuario o contraseña incorrectos.Acceso denegado",ex.ToString());
                
                }
           
                if (textoUsuario.Text == ("parqueAdm") && (textoContraseña.Text == ("PNaEkMrK20")))
                {
                    this.Hide();
                    MenuAdministrador MenuAdministrador = new MenuAdministrador();
                    MenuAdministrador.ShowDialog();


                }
                else if (textoUsuario.Text == ("RLedezma") && (textoContraseña.Text == ("Ycsyva2016")))
                {
                    this.Hide();
                    MenuGestor MenuGestor = new MenuGestor();
                    MenuGestor.ShowDialog();


                }

                else if (textoUsuario.Text == ("MMendez") && (textoContraseña.Text == (" SysDBa0229")))
                {
                    this.Hide();
                    MenuInvestigador MenuInvestigador = new MenuInvestigador();
                    MenuInvestigador.ShowDialog();

                }

            }
            
        

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }





        private void label4_Click(object sender, EventArgs e)
        {
            BotonInvisible BotonInvisible = new BotonInvisible();
            BotonInvisible.ShowDialog();
            BotonInvisible.Visible = false;
        }

        private void textoContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void textoContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string usuario = textoUsuario.Text.ToString();
                string pass = textoContraseña.Text.ToString();
                string conexion = ("Data Source=MARIA-HP;User Id=" + usuario + ";" + "Password=" + pass + ";");
                OracleConnection databaseConnection = new OracleConnection(conexion);
                databaseConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.Acceso denegado", ex.ToString());

            }

            if (textoUsuario.Text == ("parqueAdm") && (textoContraseña.Text == ("PNaEkMrK20")))
            {
                this.Hide();
                MenuAdministrador MenuAdministrador = new MenuAdministrador();
                MenuAdministrador.ShowDialog();


            }
            else if (textoUsuario.Text == ("RLedezma") && (textoContraseña.Text == ("Ycsyva2016")))
            {
                this.Hide();
                MenuGestor MenuGestor = new MenuGestor();
                MenuGestor.ShowDialog();


            }

            else if (textoUsuario.Text == ("MMendez") && (textoContraseña.Text == (" SysDBa0229")))
            {
                this.Hide();
                MenuInvestigador MenuInvestigador = new MenuInvestigador();
                MenuInvestigador.ShowDialog();

            }
        }


        private void textoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textoContraseña.Focus();
            }
        }


    }
}






            
           
            
           

