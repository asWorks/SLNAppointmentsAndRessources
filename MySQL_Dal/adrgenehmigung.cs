namespace MySQL_Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guester_neu.adrgenehmigung")]
    public partial class adrgenehmigung
    {
        [StringLength(9)]
        public string ik { get; set; }

        public int id { get; set; }
    }
}
