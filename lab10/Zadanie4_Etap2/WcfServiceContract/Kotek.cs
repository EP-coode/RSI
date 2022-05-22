using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    [DataContract]
    public enum Plec
    {
        SAMIEC,
        SAMICA
    }

    [DataContract]
    public class Kotek
    {
        static int nextId = 1;

        [DataMember]
        public int id;

        [DataMember]
        public string name;

        [DataMember]
        public Plec plec;

        public Kotek(string name, Plec plec)
        {
            this.id = nextId;
            nextId++;
            this.name = name;
            this.plec = plec;
        }

        public override string ToString()
        {
            string prefix = plec == Plec.SAMICA ? "kotka:" : "kocur:";
            return $"{prefix} {name} - {id}";
        }
    }
}
