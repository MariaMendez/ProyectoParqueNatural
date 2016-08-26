using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Forms;
using System.Data;

namespace ProyectoFinal
{
    public class Controlador
    {

        /* Para ver el Data Source es con este comando, dentor del sql developer
            select SYS_CONTEXT('USERENV', 'HOST', 15) host_name from dual;
        */

        OracleConnection databaseConnection = new OracleConnection("Data Source=MARIA-HP;User Id=parquenatural;Password=pepe;");
        //Area
        //
        public void insertaArea(string identificacion, string nombre, string extension)
        { 
            
            databaseConnection.Open();
            OracleCommand command = new OracleCommand("insert into area values('" + identificacion + "','" + nombre + "','" + extension + "')", databaseConnection);
            command.ExecuteNonQuery();
            databaseConnection.Close();
        }
        //Especie
        public void insertaEspecie(int identificacion, char tipo, string cientifico_especie, string vulgar_especie, int num_individuos, string flora, string periodoflorac, string tipoalimentacion, string periodocelo, string tipomineral)
        {
            try
            {

                databaseConnection.Open();
                OracleCommand command = new OracleCommand("insert into especie values('" + identificacion + "','" + tipo + "','" + cientifico_especie + "','" + vulgar_especie + "','" + num_individuos + "','" + flora + "','" + periodoflorac + "','" + tipoalimentacion + "','" + periodocelo + "','" + tipomineral + "')", databaseConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado", "");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.ToString());
            }
        }
        //Investigador
        public void insertaInvestigador(int identificacion, string nombre, string apellido, int telefono, string titulo)
        {
            try
            {

                databaseConnection.Open();
                OracleCommand command = new OracleCommand("insert into investigador values('" + identificacion + "','" + nombre + "','" + apellido + "','" + telefono + "','" + titulo+ "')", databaseConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado", "");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.ToString());
            }
        }
        //Organismo
        public void insertaOrganismo(int identificacion, string nombre, string direccion)
        {
            try
            {

                databaseConnection.Open();
                OracleCommand command = new OracleCommand("insert into organismo values('" + identificacion + "','" + nombre + "','" + direccion+ "')", databaseConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado", "");
                databaseConnection.Close();
           }
           catch (Exception ex)
           {
                MessageBox.Show("Error!", ex.ToString());
                Console.WriteLine("Error!", ex.ToString());
           }
        }
        //Parque Natural
        public void insertaParque(int identificacion, string nombre, string fecha)
        {
            try
            {

                databaseConnection.Open();
                OracleCommand command = new OracleCommand("insert into parque_natural values('" + identificacion + "','" + nombre + "','" + fecha + "')", databaseConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado", "");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.ToString());
                Console.WriteLine("Error!", ex.ToString());
            }
        }
        //Alojamiento
        public void insertaAlojamiento(Int64 idAlojamiento, string v_categoria, Int64 capacidad, Int64 cod_parque)
        {
    
                try
                {

                databaseConnection.Open();
                OracleCommand cmd = new OracleCommand("DMLALOJAMIENTO.INSERTAALOJA",databaseConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.BindByName = true;
                cmd.Parameters.Add("alojamiento", OracleDbType.Int64).Value = idAlojamiento;
                cmd.Parameters.Add("a_categoria", OracleDbType.Varchar2).Value = v_categoria;
                cmd.Parameters.Add("a_capacidad", OracleDbType.Int64).Value = capacidad;
                cmd.Parameters.Add("idParque", OracleDbType.Int64).Value = cod_parque;
                OracleTransaction transaction = databaseConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:{0}", ex.ToString());
                }
                databaseConnection.Close();
            
        }
        public void actualizaCategoria(Int64 idAlojamiento, string v_categoria)
        {
            try
            {
                databaseConnection.Open();
                OracleCommand cmd = new OracleCommand("DMLALOJAMIENTO.UPDCATEG", databaseConnection);
                //cmd.CommandText = "dmlAlojamiento.updCateg";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.BindByName = true;
                //cmd.Parameters.Add("Return_Value", OracleDbType.Int16, ParameterDirection.ReturnValue);
                cmd.Parameters.Add("alojamiento", OracleDbType.Int64).Value = idAlojamiento;
                cmd.Parameters.Add("a_categoria", OracleDbType.Varchar2).Value = v_categoria;
                OracleTransaction transaction = databaseConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                databaseConnection.Close();
            
            }catch (Exception ex)
                {
                MessageBox.Show("Exception:{0}", ex.ToString());
                }
                databaseConnection.Close();
            }
        //  public void eliminarAlojamiento(Int64 idAlojamiento)
        //{
        //  try
        // {
        //   databaseConnection.Open();
        // OracleCommand cmd = new OracleCommand("DMLALOJAMIENTO.DELALOJA", databaseConnection);
        //cmd.CommandText = "DMLALOJAMIENTO.DELALOJA";
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.BindByName = true;
        //cmd.Parameters.Add("Return_Value", OracleDbType.Int16, ParameterDirection.ReturnValue);
        //cmd.Parameters.Add("alojamiento1", OracleDbType.Int64).Value = idAlojamiento;
        //OracleTransaction transaction = databaseConnection.BeginTransaction(IsolationLevel.ReadCommitted);
        //cmd.Transaction = transaction;
        //cmd.ExecuteNonQuery();
        //transaction.Commit();
        //databaseConnection.Close();
        //}
        // catch (Exception ex)
        //{
        //  Console.WriteLine("Exception:{0}", ex.ToString());
        //}
        //databaseConnection.Close();
        //}

        //Comunidad Autónoma
        public void insertaComunidad(int identificacion, string nombre, int parque, int superficie, int codigoOrg)
        {
            try
            {

                databaseConnection.Open();
                OracleCommand command = new OracleCommand("insert into comunidad_autonoma values('" + identificacion + "','" + nombre + "','" + parque + "','" + superficie + "','" + codigoOrg + "')", databaseConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado", "");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.ToString());
                Console.WriteLine("Error!", ex.ToString());
            }
        }




        
    }
}



    

