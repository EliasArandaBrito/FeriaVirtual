using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.DALC;
namespace FeriaVirtual.Negocio
{
    public class Usuario
    {
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public int TipoID { get; set; }

        FeriaVirtualEntities db = new FeriaVirtualEntities();

        public bool Autenticar()
        {
            var usuarioBD = db.USUARIOS
                .FirstOrDefault(u => u.CORREOELECTRONICO == this.Email && u.CONTRASENA == this.Contrasena);

            if (usuarioBD != null)
            {
                this.Id = usuarioBD.USUARIOID;
                this.Nombre = usuarioBD.NOMBRE;
                this.TipoID = (int)usuarioBD.TIPOUSUARIOID;
                return true;
            }

            return false;
        }

        public bool AutenticarTipo(decimal id, int expectedTipoID)
        {
            try
            {
                return db.USUARIOS.Any(u => u.USUARIOID == id && u.TIPOUSUARIOID == expectedTipoID);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during TipoID check: " + ex.Message);
                return false;
            }
        }

        public string ObtenerRolUsuario()
        {
            // Consulta la tabla "Tipo de usuario" para obtener el nombre del rol del usuario.
            var tipoUsuario = db.TIPOSUSUARIO
                .FirstOrDefault(TI => TI.TIPOUSUARIOID == this.TipoID);

            return tipoUsuario?.NOMBRETIPO;
        }

        public decimal? ObtenerIdUsuario()
        {
            // Consulta la tabla "Tipo de usuario" para obtener el nombre del rol del usuario.
            var Usuario = db.USUARIOS
                .FirstOrDefault(TI => TI.USUARIOID == this.Id);

            return Usuario?.USUARIOID;
        }


    }
}