namespace MySQL_Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guester_neu.edifact")]
    public partial class edifact
    {
        public int R_NUMMER { get; set; }

        [Column(TypeName = "date")]
        public DateTime R_DATUM { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string R_EDIFACT { get; set; }

        public int ID { get; set; }
    }
}
