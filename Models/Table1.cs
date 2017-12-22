namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table1()
        {
            Table2 = new HashSet<Table2>();
        }

        [Required]
        [StringLength(10)]
        public string Songs { get; set; }

        [Required]
        [StringLength(10)]
        public string Album { get; set; }

        [Required]
        [StringLength(10)]
        public string Movie { get; set; }

        [Key]
        public int Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table2> Table2 { get; set; }
    }
}
