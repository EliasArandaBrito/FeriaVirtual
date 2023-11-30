using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeriaVirtual.Negocio
{
    public class Contratos
    {
        public decimal Contratoid { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafinalizacion { get; set; }
        public string Tipocontrato { get; set; }
        public decimal Estadocontratoid { get; set; }
        public string Demanda { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal Usuarioid { get; set; }
        public short? Published { get; set; }

        public Cliente ClienteId { get; set; }
        public EstadoContrato Estadocontrato { get; set; }
       

        private readonly FeriaVirtualEntities db = new FeriaVirtualEntities();



        public List<Contratos> ReadById(decimal Id)
        {
            try
            {
                return this.db.CONTRATOS
                    .Where(c => c.USUARIOID == Id)
                    .Select(c => new Contratos()
                    {
                        Contratoid = c.CONTRATOID,
                        Fechainicio = c.FECHAINICIO,
                        Fechafinalizacion = c.FECHAFINALIZACION,
                        Tipocontrato = c.TIPOCONTRATO,
                        Estadocontratoid = c.ESTADOCONTRATOID,
                        Estadocontrato = new EstadoContrato()
                        {
                            Estadocontratoid = c.ESTADOCONTRATOID,
                            Nombreestado = c.ESTADOCONTRATO.NOMBREESTADO
                        },
                        Demanda = c.DEMANDA,
                        Cantidad = c.CANTIDAD,
                        Usuarioid = c.USUARIOID,
                        ClienteId = new Cliente()
                        {
                            Id = c.USUARIOID,
                        },
                        Published = c.PUBLISHED
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }


        public List<Contratos> ReadPublished()
        {
            return db.CONTRATOS
                 .Where(c => c.PUBLISHED == 1)
                 .Select(c => new Contratos()
            {
                Contratoid = c.CONTRATOID,
                Fechainicio = c.FECHAINICIO,
                Fechafinalizacion = c.FECHAFINALIZACION,
                Tipocontrato = c.TIPOCONTRATO,
                Estadocontratoid = c.ESTADOCONTRATOID,
                Estadocontrato = new EstadoContrato()
                {
                    Estadocontratoid = c.ESTADOCONTRATOID,
                    Nombreestado = c.ESTADOCONTRATO.NOMBREESTADO
                },
                Demanda = c.DEMANDA,
                Cantidad = c.CANTIDAD,
                Usuarioid = c.USUARIOID,
                ClienteId = new Cliente()
                {
                    Id = c.USUARIOID,
                },
                Published = c.PUBLISHED
            }).ToList();
        }

        public List<Contratos> ReadAll()
        {
            return db.CONTRATOS.Select(c => new Contratos
            {
                Contratoid = c.CONTRATOID,
                Fechainicio = c.FECHAINICIO,
                Fechafinalizacion = c.FECHAFINALIZACION,
                Tipocontrato = c.TIPOCONTRATO,
                Estadocontratoid = c.ESTADOCONTRATOID,
                Estadocontrato = new EstadoContrato()
                {
                    Estadocontratoid = c.ESTADOCONTRATOID,
                    Nombreestado = c.ESTADOCONTRATO.NOMBREESTADO
                },
                Demanda = c.DEMANDA,
                Cantidad = c.CANTIDAD,
                Usuarioid = c.USUARIOID,
                ClienteId = new Cliente()
                {
                    Id = c.USUARIOID,
                },
                Published = c.PUBLISHED
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                // Llama al procedimiento almacenado
                db.INSERT_CONTRATO(
                    this.Fechainicio,
                    this.Fechafinalizacion,
                    this.Tipocontrato,
                    this.Estadocontratoid,
                    this.Demanda,
                    this.Cantidad,
                    this.Usuarioid
                );

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar: " + ex.Message);
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                var contratoAEliminar = db.CONTRATOS.FirstOrDefault(c => c.CONTRATOID == this.Contratoid);

                if (contratoAEliminar != null)
                {
                    db.CONTRATOS.Remove(contratoAEliminar);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar: " + ex.Message);
                return false;
            }
        }

    }
}
