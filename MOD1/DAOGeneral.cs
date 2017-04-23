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
    public class DAOGeneral
    {
        Conex objCon = new Conex();
        DataSet DS = new DataSet();
        public DataTable SelectPronDiarioDiscreto()
        {
            Conex con = new Conex();
            return con.execSP("MOD1_SELECT_PRO_DIARIO");
        }
        public DataTable SelectPronDiarioCalculado()
        {
            Conex con = new Conex();
            return con.execSP("MOD1_SELECT_PRO_DIARIO_AUX");
        }
        public int SelectNumInc()
        {
            Conex con = new Conex();
            return con.execNI("MOD1_SEL_NUMINC");
        }
        public void HisToMod1His()
        {
            Conex con = new Conex();
            con.execSP("MOD1_HIS_TO_MOD1HIS");
        }
        public void NormProMen()
        {
            Conex con = new Conex();
            con.execSP("NORM_PRO_MEN");
        }
        public void updPronDiarioDiscreto(EPronDiario pron)
        {
            Conex con = new Conex();
            con.updPronDiarioDiscreto("MOD1_ACTUALIZA_PRO_DIARIO", pron);
        }
        public DataTable SelectPronSemDiscreto()
        {
            Conex con = new Conex();
            return con.execSP("MOD1_SELECT_PRO_SEMANAL");
        }
        public DataTable SelectPronSemCalculado()
        {
            Conex con = new Conex();
            return con.execSP("MOD1_SELECT_PRO_SEMANAL_AUX");
        }
        public void updPronSemDiscreto(EPronSem pron)
        {
            Conex con = new Conex();
            con.updPronSemDiscreto("MOD1_ACTUALIZA_PRO_SEM", pron);
        }
        public DataTable SelectPronMensual()
        {
            Conex con = new Conex();
            return con.execSP("MOD1_SELECT_PRO_MENSUAL_2");
        }
        public void updPronMensual(EPronMen pron)
        {
            Conex con = new Conex();
            con.updPronMensual("MOD1_ACTUALIZA_PRO_MEN", pron);
        }
        public void updHisDia()
        {
            Conex con = new Conex();
            con.updHisDia("uspHis_Dia_Mnt01");
        }
    }
}
