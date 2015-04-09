/*
 * Tiago Fernandes 
 * 21-01-2014
 * Isi
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices
{
    [DataContract]
    public class TipoServico
    {
        int tipoServicoId;
        String nomeServico;
        string prefixoServico;

        public TipoServico(int tipoServicoId, string nomeServico, string prefixoServico)
        {
            this.tipoServicoId = tipoServicoId;
            this.nomeServico = nomeServico;
            this.prefixoServico = prefixoServico;
        }
        public TipoServico()
        {
            this.tipoServicoId = 0;
            this.nomeServico = "NomeServico";
            this.prefixoServico = "PrefixoServico";
        }
        [DataMember]
        public int TipoServicoId
        {
            get { return tipoServicoId; }
            set { tipoServicoId = value; }

        }
        [DataMember]
        public string NomeServico
        {
            get { return nomeServico; }
            set { nomeServico = value; }

        }
        [DataMember]
        public string PrefixoServico
        {
            get { return prefixoServico; }
            set { prefixoServico = value; }

        }
    }
}