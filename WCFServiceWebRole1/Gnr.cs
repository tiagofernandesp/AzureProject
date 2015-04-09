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
    public class Gnr
    {
        int id;
        string pNome;
        string uNome;
        DateTime dataNasc;
        int numero;
        bool ativo;

        public Gnr(int mid, string mpNome, string muNome, DateTime mdataNasc, int mnumero, bool mativo)
        {
            id = mid;
            pNome = mpNome;
            uNome = muNome;
            dataNasc = mdataNasc;
            numero = mnumero;
            ativo = mativo;
        }
        public Gnr()
        {
            this.id = 0;
            this.pNome = "PNome";
            this.uNome = "UNome";
            this.dataNasc = new DateTime(1500,01,01);
            this.numero = 0;
            this.ativo = false;
        }
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        [DataMember]
        public string PNome
        {
            get { return pNome; }
            set { pNome = value; }

        }
        [DataMember]
        public string UNome
        {
            get { return uNome; }
            set { uNome = value; }

        }
        [DataMember]
        public DateTime DataNasc
        {
            get { return dataNasc; }
            set { dataNasc = value; }

        }
        [DataMember]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }

        }
        [DataMember]
        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }

        }
    }
}