namespace MySQL_Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guester_neu.dtatypen")]
    public partial class dtatypen
    {
        [StringLength(40)]
        public string fallname { get; set; }

        public int? fallposition { get; set; }

        public int id { get; set; }
    }
}
