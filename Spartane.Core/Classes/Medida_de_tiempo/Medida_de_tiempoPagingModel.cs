﻿using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Medida_de_tiempo
{
    public class Medida_de_tiempoPagingModel
    {
        public List<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> Medida_de_tiempos { set; get; }
        public int RowCount { set; get; }
    }
}
