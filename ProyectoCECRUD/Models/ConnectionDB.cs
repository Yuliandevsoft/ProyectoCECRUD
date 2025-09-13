using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProyectoCECRUD.Models
{
    public class ConnectionDB
    {
        public static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}