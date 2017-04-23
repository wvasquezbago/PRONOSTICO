using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MOD1.Entidades;

namespace MOD1
{
    public class BOGeneral
    {
        public DataTable SelectPronDiarioDiscreto()
        {
            DAOGeneral objPronDiario = new DAOGeneral();
            return objPronDiario.SelectPronDiarioDiscreto();
        }
        public DataTable SelectPronDiarioCalculado()
        {
            DAOGeneral objPronDiario = new DAOGeneral();
            return objPronDiario.SelectPronDiarioCalculado();
        }
        public int SelectNumInc()
        {
            DAOGeneral objPronDiario = new DAOGeneral();
            return objPronDiario.SelectNumInc();
        }
        public void updPronDiarioDiscreto(System.Data.DataTable dt)
        {
            DAOGeneral obj = new DAOGeneral();
            EPronDiario pron = new EPronDiario();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                //willy
                pron.ID_ARTICULO = Convert.ToString(row["ID_ARTICULO"]);
                pron.FECHA = Convert.ToDateTime(row["FECHA"]);
                pron.VENTA = Convert.ToDouble(row["VENTA"]);
                obj.updPronDiarioDiscreto(pron);
            }
        }
        public DataTable SelectPronSemDiscreto()
        {
            DAOGeneral objPronSem = new DAOGeneral();
            return objPronSem.SelectPronSemDiscreto();
        }
        public void NormProMen()
        {
            DAOGeneral objPronSem = new DAOGeneral();
            objPronSem.NormProMen();
        }
        public void HisToMod1His()
        {
            DAOGeneral obj = new DAOGeneral();
            obj.HisToMod1His();
        }
        public DataTable SelectPronSemCalculado()
        {
            DAOGeneral objPronSem = new DAOGeneral();
            return objPronSem.SelectPronSemCalculado();
        }
        public void updPronSemDiscreto(System.Data.DataTable dt)
        {
            DAOGeneral obj = new DAOGeneral();
            EPronSem pron = new EPronSem();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                pron.ID_ARTICULO = Convert.ToString(row["ID_ARTICULO"]);
                pron.ID_SEM = Convert.ToString(row["ID_SEM"]);
                pron.VENTA = Convert.ToDouble(row["VENTA"]);
                obj.updPronSemDiscreto(pron);
            }
        }
        public DataTable SelectPronMensual()
        {
            DAOGeneral objPronMen = new DAOGeneral();
            return objPronMen.SelectPronMensual();
        }
        public void UpdHisDia()
        {
            DAOGeneral dao = new DAOGeneral();
            dao.updHisDia();
        }
        public void updPronMensual(System.Data.DataTable dt)
        {
            DAOGeneral obj = new DAOGeneral();
            EPronMen pron = new EPronMen();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                pron.ID_ARTICULO = Convert.ToString(row["ID_ARTICULO"]);
                pron.ID_YEAR = Convert.ToInt32(row["ID_YEAR"]);
                pron.ID_MONTH = Convert.ToInt32(row["ID_MONTH"]);
                pron.VENTA = Convert.ToDouble(row["VENTA"]);
                obj.updPronMensual(pron);
            }
        }
    }
}
