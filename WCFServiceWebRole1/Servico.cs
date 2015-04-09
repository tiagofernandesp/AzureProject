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
    public class Servico
    {
        int servicoId;
        DateTime dataInicio;
        DateTime dataFim;
        DateTime data;
        int tipoServicoId;
        int gnrId;
        public Servico(int servicoId, DateTime dataInicio, DateTime dataFim, DateTime data, int tipoServicoId, int gnrId)
        {
            this.servicoId = servicoId;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.data = data;
            this.tipoServicoId = tipoServicoId;
            this.gnrId = gnrId;
        }
        public Servico()
        {
            this.servicoId = 0;
            this.dataInicio = new DateTime(1500, 01, 01);
            this.dataFim = new DateTime(1500, 01, 01);
            this.data = new DateTime(1500, 01, 01);
            this.tipoServicoId = 0;
            this.gnrId = 0;
        }
        [DataMember]
        public int ServicoID
        {
            get { return servicoId; }
            set { servicoId = value; }

        }
        [DataMember]
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }

        }
        [DataMember]
        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }

        }
        [DataMember]
        public DateTime Data
        {
            get { return data; }
            set { data = value; }

        }
        [DataMember]
        public int TipoServicoID
        {
            get { return tipoServicoId; }
            set { tipoServicoId = value; }

        }
        [DataMember]
        public int GnrId
        {
            get { return gnrId; }
            set { gnrId = value; }

        }
    }
}