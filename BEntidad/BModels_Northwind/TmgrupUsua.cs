using System;
using System.Collections.Generic;

namespace BEntidad.BModels_Northwind
{
    public partial class TmgrupUsua
    {
        public TmgrupUsua()
        {
            Tmusua = new HashSet<Tmusua>();
        }

        public string Co_grup { get; set; }
        public string No_grup { get; set; }

        public ICollection<Tmusua> Tmusua { get; set; }
    }
}
