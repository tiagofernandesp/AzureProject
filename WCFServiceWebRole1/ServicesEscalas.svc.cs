/*
 * Tiago Fernandes 
 * 21-01-2014
 * Isi
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;


namespace WCFServices
{
    public class Service1 : IServicesEscalas
    {
        #region OPENBD & CloseBD
        SqlConnection cnn;

        /// <summary>
        /// Cria ligação e testa
        /// </summary>
        /// <returns></returns>
        private bool OpenDB()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            //connetionString = "Data Source=.;Initial Catalog=BDGNR;User ID=sa;Password=Tiago1990";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Tenta fechar coneccao
        /// </summary>
        /// <returns></returns>
        private bool CloseDB()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion


        #region MetodosGNR
        /// <summary>
        /// recolhe todos gnr da bd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Gnr> GetAllGnr()
        {
            List<Gnr> list = new List<Gnr>();
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from Gnr", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Gnr g = new Gnr();
                g.Id = (int)rdr["GndID"];
                g.PNome = (string)rdr["PNome"];
                g.UNome = (string)rdr["UNome"];
                g.DataNasc = (DateTime)rdr["DataNasc"];
                g.Numero = (int)rdr["Numero"];
                g.Ativo = (bool)rdr["Ativo"];
                list.Add(g);
            }
            CloseDB();
            return list;
        }

        /// <summary>
        /// Envia um gnr
        /// </summary>
        /// <returns></returns>
        public Gnr GetGnr(string id)
        {

            int newId;
            if (!Int32.TryParse(id, out newId))
            {
                return null;
            }
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from Gnr", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (newId == (int)rdr["GndID"])
                {
                    Gnr g = new Gnr();
                    g.Id = (int)rdr["GndID"];
                    g.PNome = (string)rdr["PNome"];
                    g.UNome = (string)rdr["UNome"];
                    g.DataNasc = (DateTime)rdr["DataNasc"];
                    g.Numero = (int)rdr["Numero"];
                    g.Ativo = (bool)rdr["Ativo"];
                    return g;
                }
            }
            CloseDB();
            return null;
        }
        /// <summary>
        /// Apaga GNR
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGnr(string id)
        {
            string query = "";
            SqlDataReader rdr = null;

            OpenDB();
            query = "DELETE from gnr WHERE GndID=" + id;
            // create a command object
            SqlCommand cmd = new SqlCommand(query, cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        /// <summary>
        /// Metodo permito add um gnr
        /// </summary>
        /// <param name="gnr"></param>
        /// <returns></returns>
        public bool AddGnr(Gnr gnr)
        {

            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;

            OpenDB();
            query.AppendFormat("INSERT INTO Gnr (GndID, PNome, UNome, DataNasc, Numero, Ativo) VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5});"
                , gnr.Id, gnr.PNome, gnr.UNome, gnr.DataNasc.ToString("yyyy-MM-dd"), gnr.Numero, Convert.ToInt32(gnr.Ativo));
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        /// <summary>
        /// Metodo permite fazer update a um gnr
        /// </summary>
        /// <param name="gnr"></param>
        /// <returns></returns>
        public bool UpdateGnr(Gnr gnr)
        {
            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;

            OpenDB();
            query.AppendFormat("UPDATE Gnr SET PNome='{0}', UNome='{1}', DataNasc='{2}', Numero={3}, Ativo={4} WHERE GndID={5}"
                , gnr.PNome, gnr.UNome, gnr.DataNasc.ToString("yyyy-MM-dd"), gnr.Numero, Convert.ToInt32(gnr.Ativo), gnr.Id);
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        #endregion


        #region MetodosServico
        /// <summary>
        /// recolhe todos servicos da bd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Servico> GetAllServico()
        {
            List<Servico> list = new List<Servico>();
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from Servico", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Servico s = new Servico();
                s.ServicoID = (int)rdr["ServicoID"];
                s.DataInicio = (DateTime)rdr["DataInicio"];
                s.DataFim = (DateTime)rdr["DataFim"];
                s.TipoServicoID = (int)rdr["TipoServicoID"];
                s.GnrId = (int)rdr["GnrID"];
                s.Data = (DateTime)rdr["Data"];
                list.Add(s);
            }
            CloseDB();
            return list;
        }
        /// <summary>
        /// Get servico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Servico GetServico(string id)
        {
            int newId;
            if (!Int32.TryParse(id, out newId))
            {
                return null;
            }
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from Servico", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (newId == (int)rdr["ServicoID"])
                {
                    Servico s = new Servico();
                    s.ServicoID = (int)rdr["ServicoID"];
                    s.DataInicio = (DateTime)rdr["DataInicio"];
                    s.DataFim = (DateTime)rdr["DataFim"];
                    s.TipoServicoID = (int)rdr["TipoServicoID"];
                    s.GnrId = (int)rdr["GnrID"];
                    s.Data = (DateTime)rdr["Data"];
                    return s;
                }
            }
            CloseDB();
            return null;
        }
        /// <summary>
        /// Delete servico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteServico(string id)
        {
            string query = "";
            SqlDataReader rdr = null;
            OpenDB();
            query = "DELETE from Servico WHERE ServicoID=" + id;
            // create a command object
            SqlCommand cmd = new SqlCommand(query, cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }

        /// <summary>
        /// Add servico
        /// </summary>
        /// <param name="gnr"></param>
        /// <returns></returns>
        public bool AddServico(Servico s)
        {
            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;
            OpenDB();
            query.AppendFormat("INSERT INTO Servico (ServicoID, DataInicio, DataFim, TipoServicoID, GnrID, Data) VALUES ({0}, '{1}', '{2}', {3}, {4}, '{5}');"
                , s.ServicoID, s.DataInicio, s.DataFim, s.TipoServicoID, s.GnrId, s.Data.ToString("yyyy-MM-dd"));
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        /// <summary>
        /// Update servico by id
        /// </summary>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool UpdateServico(Servico s)
        {
            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;

            OpenDB();
            query.AppendFormat("UPDATE Servico SET DataInicio='{0}', DataFim='{1}', TipoServicoID={2}, GnrID={3}, Data='{4}' WHERE ServicoID={5};"
                , s.DataInicio, s.DataFim, s.TipoServicoID, s.GnrId, s.Data.ToString("yyyy-MM-dd"), s.ServicoID);
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        #endregion


        #region TipoServico

        /// <summary>
        /// Get all TipoServico
        /// </summary>
        /// <returns></returns>
        public List<TipoServico> GetAllTipoServico()
        {
            List<TipoServico> list = new List<TipoServico>();
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from TipoServico", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TipoServico s = new TipoServico();
                s.TipoServicoId = (int)rdr["TipoServicoID"];
                s.NomeServico = (string)rdr["NomeServico"];
                s.PrefixoServico = (string)rdr["PrefixoServico"];
                list.Add(s);
            }
            CloseDB();
            return list;
        }

        /// <summary>
        /// Get TipoServico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipoServico GetTipoServico(string id)
        {
            int newId;
            if (!Int32.TryParse(id, out newId))
            {
                return null;
            }
            SqlDataReader rdr = null;
            OpenDB();

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from TipoServico", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (newId == (int)rdr["TipoServicoID"])
                {
                    TipoServico s = new TipoServico();
                    s.TipoServicoId = (int)rdr["TipoServicoID"];
                    s.NomeServico = (string)rdr["NomeServico"];
                    s.PrefixoServico = (string)rdr["PrefixoServico"];
                    return s;
                }
            }
            CloseDB();
            return null;
        }

        /// <summary>
        /// Delete TipoServico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTipoServico(string id)
        {
            string query = "";
            SqlDataReader rdr = null;

            OpenDB();
            query = "DELETE from TipoServico WHERE TipoServicoID=" + id;
            // create a command object
            SqlCommand cmd = new SqlCommand(query, cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }

        /// <summary>
        /// Add TipoServico 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public bool AddTipoServico(TipoServico st)
        {
            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;

            OpenDB();
            query.AppendFormat("INSERT INTO TipoServico (TipoServicoID, NomeServico, PrefixoServico) VALUES ({0}, '{1}', '{2}');"
                , st.TipoServicoId, st.NomeServico, st.PrefixoServico);
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }

        /// <summary>
        /// Update TipoServico
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public bool UpdateTipoServico(TipoServico st)
        {
            StringBuilder query = new StringBuilder();
            SqlDataReader rdr = null;

            OpenDB();
            query.AppendFormat("UPDATE TipoServico SET NomeServico='{0}', PrefixoServico='{1}' WHERE TipoServicoID={2};"
                , st.NomeServico, st.PrefixoServico, st.TipoServicoId);
            // create a command object
            SqlCommand cmd = new SqlCommand(query.ToString(), cnn);
            rdr = cmd.ExecuteReader();
            CloseDB();
            return true;
        }
        #endregion
    }
}
