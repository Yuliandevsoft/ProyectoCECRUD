using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCECRUD.Models
{
    public class Datacontact
    {
        public List<Contacto> ShowContact()
        {

            List<Contacto> olista = new List<Contacto>();

            using (SqlConnection oconexion = new SqlConnection(ConnectionDB.conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACTO", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new Contacto
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }

                    oconexion.Close();

                }

            }
            return olista;
        }

        public void Registrar(Contacto ocontacto)
        {
            using (SqlConnection oconexion = new SqlConnection(ConnectionDB.conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombres", ocontacto.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", ocontacto.Apellidos);
                cmd.Parameters.AddWithValue("@Telefono", ocontacto.Telefono);
                cmd.Parameters.AddWithValue("@Correo", ocontacto.Correo);

                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
