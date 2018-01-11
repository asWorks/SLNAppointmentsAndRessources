namespace MySQL_Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guester_neu.berlock")]
    public partial class berlock
    {
        public int berichtid { get; set; }

        [Required]
        [StringLength(100)]
        public string maschine { get; set; }

        public int id { get; set; }
    }
}
