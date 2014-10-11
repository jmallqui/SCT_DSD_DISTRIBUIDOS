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

    public class Empresas : IEmpresas
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



        public Empresa CrearEmpresa(string empresa, string ruc, string telefono, string direccion)
        {
            Empresa EmpresaACrear = new Empresa()
            {

                EMPRESA = empresa,
                RUC = ruc,
                DIRECCION = direccion,
                TELEFONO = telefono
            };

            return EmpresaDAO.Crear(EmpresaACrear);
        }


        public Empresa ObtenerEmpresa(int codigo)
        {
            return EmpresaDAO.Obtener(codigo);
        }

        public Empresa ModificarEmpresa(int codigo, string empresa, string ruc, string telefono, string direccion)
        {
            Empresa empresaAModificar = new Empresa()
            {
                ID_EMPRESA = codigo,
                EMPRESA = empresa,
                RUC = ruc,
                DIRECCION = direccion,
                TELEFONO = telefono
            };

            return EmpresaDAO.Modificar(empresaAModificar);
        }

        public void EliminarEmpresa(int codigo)
        {
            Empresa empresaExistente = EmpresaDAO.Obtener(codigo);
            EmpresaDAO.Eliminar(empresaExistente);
        }

        public List<Empresa> ListarEmpresa()
        {
            return EmpresaDAO.ListarTodos().ToList();
        }

     
    }

        #endregion
}

