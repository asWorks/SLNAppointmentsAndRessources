namespace MySQL_Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guester_neu.tbar")]
    public partial class tbar
    {
        [StringLength(2)]
        public string TBKLASSE { get; set; }

        [StringLength(40)]
        public string TBTHEMA { get; set; }

        [StringLength(15)]
        public string TBABSATZ { get; set; }

        public sbyte? TBBLOCK { get; set; }

        [StringLength(15)]
        public string TBOBER { get; set; }

        [StringLength(2)]
        public string TBRANG { get; set; }

        [StringLength(50)]
        public string TBTITEL { get; set; }

        [StringLength(40)]
        public string TBUNTERT { get; set; }

        [StringLength(1073741823)]
        public string TBTEXT { get; set; }

        public int id { get; set; }
    }
}
