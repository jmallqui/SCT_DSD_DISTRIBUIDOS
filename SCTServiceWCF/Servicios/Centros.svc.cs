using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SCTServiceWCF.Persistencia;
using SCTServiceWCF.Dominio;



namespace SCTServiceWCF.Servicios
{
    public class Centros : ICentro
    {

        #region Miembros de IEmpresas

        private EmpresaDAO empresaDAO = null;
        private EmpresaDAO EmpresaDAO
        {
            get
            {
                if (empresaDAO == null)
                    empresaDAO = new EmpresaDAO();
                return empresaDAO;
            }
        }
        #endregion
        
        #region Miembros de ICentros
        private CentroDAO centroDAO = null;
        private CentroDAO CentroDAO
        {
            get
            {
                if (centroDAO == null)
                    centroDAO = new CentroDAO();
                return centroDAO;
            }
        }
        

       
        public Centro CrearCentro(string descripcion, int empresa)
        {
            Empresa empresaExistente = EmpresaDAO.Obtener(empresa);
            Centro CentroACrear = new Centro()
            {
                DESCRIPCION = descripcion,
                EMPRESA = empresa
            };
            return CentroDAO.Crear(CentroACrear);
        
        }
        public Centro ObtenerCentro(int codigo)
        {
            return CentroDAO.Obtener(codigo);
        }

        public Centro ModificarCentro(int codigo, string descripcion, int empresa)
        {
            Empresa empresaExistente = EmpresaDAO.Obtener(empresa);
            Centro centroAModificar = new Centro()
            {
                ID_CENTRO = codigo,
                DESCRIPCION = descripcion,
                EMPRESA = empresa
            };

            return CentroDAO.Modificar(centroAModificar);
        }

        public List<Centro> ListarCentro()
        {
            return CentroDAO.ListarTodos().ToList();
        }
        #endregion
    }
       
}
