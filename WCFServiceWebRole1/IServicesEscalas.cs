/*
 * Tiago Fernandes 
 * 21-01-2014
 * Isi
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServices
{
    [ServiceContract]
    public interface IServicesEscalas
    {

        /// <summary>
        /// Devolve GNR's
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "/gnr", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Gnr> GetAllGnr();

        /// <summary>
        /// Devolve GNR
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "/gnr/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Gnr GetGnr(string id);

        /// <summary>
        /// Apaga GNR
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "/gnr{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteGnr(string id);

        /// <summary>
        /// Add gnr
        /// </summary>
        /// <param name="gnr"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", UriTemplate = "/gnr", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool AddGnr(Gnr gnr);
        /// <summary>
        /// update gnr
        /// </summary>
        /// <param name="gnr"></param>
        /// <returns></returns>
        [WebInvoke(Method = "PUT", UriTemplate = "/gnr", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateGnr(Gnr gnr);
        /// <summary>
        /// Get all Services
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "/Servico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Servico> GetAllServico();
        /// <summary>
        /// Get servico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "/Servico/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Servico GetServico(string id);

        /// <summary>
        /// Apaga Servico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "/servico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteServico(string id);

        /// <summary>
        /// Add gnr
        /// </summary>
        /// <param name="servico"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", UriTemplate = "/servico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool AddServico(Servico s);
        /// <summary>
        /// update gnr
        /// </summary>
        /// <param name="servico"></param>
        /// <returns></returns>
        [WebInvoke(Method = "PUT", UriTemplate = "/servico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateServico(Servico s);
        /// <summary>
        /// Get all Services
        /// </summary>
        /// <returns></returns>
        /// 


        [WebGet(UriTemplate = "/TipoServico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<TipoServico> GetAllTipoServico();
        /// <summary>
        /// Get TipoServico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "/TipoServico/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TipoServico GetTipoServico(string id);

        /// <summary>
        /// Apaga TipoServico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "/TipoServico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteTipoServico(string id);

        /// <summary>
        /// Add gnr
        /// </summary>
        /// <param name="TipoServico"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", UriTemplate = "/TipoServico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool AddTipoServico(TipoServico ts);
        /// <summary>
        /// update gnr
        /// </summary>
        /// <param name="TipoServico"></param>
        /// <returns></returns>
        [WebInvoke(Method = "PUT", UriTemplate = "/TipoServico", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateTipoServico(TipoServico ts);
    }
}
