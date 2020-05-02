using System;
using System.Collections.Generic;

namespace BEntidad.BModels_Northwind
{
    public partial class Tmusua
    {
        public string CoUsua { get; set; }
        public string NoUsua { get; set; }
        public string NoClav { get; set; }
        public DateTime FeModiClav { get; set; }
        public string CoGrup { get; set; }
        public string DeDireMail { get; set; }
        public string StActi { get; set; }
        public string CoUsuaCrea { get; set; }
        public DateTime FeUsuaCrea { get; set; }
        public string CoUsuaModi { get; set; }
        public DateTime FeUsuaModi { get; set; }

        public TmgrupUsua CoGrupNavigation { get; set; }
    }
}
