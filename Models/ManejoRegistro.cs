using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LandingPage.Models
{
    public class ManejoRegistro
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["sisinfo"].ToString();
            conexion = new SqlConnection(constr);
        }

        public int Insertar(Registro registro)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into registro(nombre, correo, telefono, ciudad) values (@nombre, @correo, @telefono, @ciudad)", conexion);

            //comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);

            //comando.Parameters["@usu_id"].Value = usuario.Usu_id;
            comando.Parameters["@nombre"].Value = registro.Nombre;
            comando.Parameters["@correo"].Value = registro.Correo;
            comando.Parameters["@telefono"].Value = registro.Telefono;
            comando.Parameters["@ciudad"].Value = registro.Ciudad;

            conexion.Open();
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;
        }

        public List<Registro> Seleccionar_Todo()
        {
            Conectar();
            List<Registro> lista = new List<Registro>();

            SqlCommand comando = new SqlCommand("select id, nombre, correo, telefono, ciudad from registro", conexion);
            conexion.Open();
            SqlDataReader registrados = comando.ExecuteReader();

            while (registrados.Read())
            {
                Registro registro = new Registro
                {
                    Id = int.Parse(registrados["id"].ToString()),
                    Nombre = registrados["nombre"].ToString(),
                    Correo = registrados["correo"].ToString(),
                    Telefono = registrados["telefono"].ToString(),
                    Ciudad = registrados["ciudad"].ToString(),
                };
                lista.Add(registro);
            }
            conexion.Close();
            return lista;
        }

        public Registro Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, nombre, correo, telefono, ciudad from registro where id=@id", conexion);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;

            conexion.Open();
            SqlDataReader registrados = comando.ExecuteReader();
            Registro nuevoRegistro = new Registro();

            if (registrados.Read())
            {
                nuevoRegistro.Id = int.Parse(registrados["id"].ToString());
                nuevoRegistro.Nombre = registrados["nombre"].ToString();
                nuevoRegistro.Correo = registrados["correo"].ToString();
                nuevoRegistro.Telefono = registrados["telefono"].ToString();
                nuevoRegistro.Ciudad = registrados["ciudad"].ToString();
            }
            else
                nuevoRegistro = null;

            conexion.Close();
            return nuevoRegistro;
        }
    }
}