﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Dashboard_Editor;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Dashboard_Config_Detail
{
    /// <summary>
    /// Dashboard_Config_Detail table
    /// </summary>
    public class Dashboard_Config_Detail: BaseEntity
    {
        public int Detail_Id { get; set; }
        public int? Dashboard { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }

        [ForeignKey("Dashboard")]
        public virtual Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor Dashboard_Dashboard_Editor { get; set; }

    }
}

