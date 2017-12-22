namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table2
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string Awards { get; set; }

        public int Price { get; set; }

        public virtual Table1 Table1 { get; set; }
    }
}
