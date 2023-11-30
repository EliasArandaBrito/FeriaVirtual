using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class SubastaMedio
    {
        public decimal MedioId { get; set; }
        public decimal SubastaId { get; set; }
        public decimal Selected { get; set; }
        public MedioTransporte MedioTransporte { get; set; }
        public Subasta Subasta { get; set; }

        private readonly FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<SubastaMedio> ReadAll()
        {
            try
            {
                return db.SUBASTA_MEDIO.Select(c => new SubastaMedio
                {
                    MedioId = c.MEDIOID,
                    SubastaId = c.SUBASTAID,
                    Selected = (decimal)c.SELECTED,
                    MedioTransporte = new MedioTransporte(),
                    Subasta = new Subasta()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }

        }

        public List<SubastaMedio> ReadBySubastaId(decimal Id)
        {
            try
            {
                return this.db.SUBASTA_MEDIO
                    .Where(c => c.SUBASTAID == Id)
                    .Select(c => new SubastaMedio()
                    {
                        MedioId = c.MEDIOID,
                        SubastaId = c.SUBASTAID,
                        Selected = (decimal)c.SELECTED,
                        MedioTransporte = new MedioTransporte(),
                        Subasta = new Subasta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<SubastaMedio> ReadBySubastaIdAndTransportistaId(decimal subastaId, decimal transportistaId)
        {
            try
            {
                return this.db.SUBASTA_MEDIO
                    .Where(c => c.SUBASTAID == subastaId &&
                                this.db.MEDIOTRANSPORTE.Any(m => m.MEDIOID == c.MEDIOID && m.TRANSPORTISTAID == transportistaId))
                    .Select(c => new SubastaMedio()
                    {
                        MedioId = c.MEDIOID,
                        SubastaId = c.SUBASTAID,
                        Selected = (decimal)c.SELECTED,
                        MedioTransporte = new MedioTransporte(),
                        Subasta = new Subasta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }
        public List<SubastaMedio> ReadByMedioId(decimal Id)
        {
            try
            {
                return this.db.SUBASTA_MEDIO
                    .Where(c => c.MEDIOID == Id)
                    .Select(c => new SubastaMedio()
                    {
                        MedioId = c.MEDIOID,
                        SubastaId = c.SUBASTAID,
                        Selected = (decimal)c.SELECTED,
                        MedioTransporte = new MedioTransporte(),
                        Subasta = new Subasta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public bool Save()
        {
            try
            {


                // Llama al procedimiento almacenado
                db.INSERT_SUBASTA_MEDIO(this.MedioId, this.SubastaId);



                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al guardar: " + ex.Message);

                return false;
            }
        }
    }
}
