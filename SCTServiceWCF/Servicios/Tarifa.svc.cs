using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SCTServiceWCF.Persistencia.AccesoDatos;
using SCTServiceWCF.Dominio;

namespace SCTServiceWCF.Interfaces
{
    public class Tarifas : ITarifa
    {

        #region Dependencias
        private TarifaDAO tarifaDAO = null;
        private TarifaDAO TarifaDAO
        {
            get
            {
                if (tarifaDAO == null)
                    tarifaDAO = new TarifaDAO();
                return tarifaDAO;
            }
        }
        #endregion

        //public Dominio.Tarifa RegistrarTarifa(Dominio.Tarifa addTarifa)
        public Dominio.Tarifa RegistrarTarifa(string NOM_TARIFA,decimal PRECIO, string MONEDA)
        {
            Tarifa addTarifa = new Tarifa();
            addTarifa.NOM_TARIFA = NOM_TARIFA;
            addTarifa.PRECIO = PRECIO;
            addTarifa.MONEDA = MONEDA;
            return TarifaDAO.Crear(addTarifa);
        }

        public Dominio.Tarifa ModificarTarifa(int ID_TARIFA,string NOM_TARIFA, decimal PRECIO, string MONEDA)
        {
            Tarifa editTarifa = new Tarifa();
            editTarifa.ID_TARIFA = ID_TARIFA;
            editTarifa.NOM_TARIFA = NOM_TARIFA;
            editTarifa.PRECIO = PRECIO;
            editTarifa.MONEDA = MONEDA;

            return TarifaDAO.Modificar(editTarifa);
        }

        public void EliminarTarifa(int ID_TARIFA)
        {
            Tarifa objBungalows = TarifaDAO.Obtener(ID_TARIFA);
            TarifaDAO.Eliminar(objBungalows);
        }

        public Dominio.Tarifa ObtenerTarifa(int ID_TARIFA)
        {
            return TarifaDAO.Obtener(ID_TARIFA);
        }

        public ICollection<Dominio.Tarifa> ListarTarifa()
        {
            return TarifaDAO.ListarTodos();
        }
    }
}
