using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCTServiceWCF.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SCTServiceWCF.Persistencia.AccesoDatos
{
    public class TarifaDAO : BaseDAO<Tarifa, int>
    {
        public ICollection<Tarifa> ListarTarifa()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICollection<Tarifa> resultado = sesion.CreateCriteria(typeof(Tarifa)).List<Tarifa>();
                return resultado;
            }
        }
    }
}