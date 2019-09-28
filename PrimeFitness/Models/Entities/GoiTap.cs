namespace PrimeFitness.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoiTap")]
    public partial class GoiTap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiTap()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(10)]
        public string MaGT { get; set; }

        [Required]
        [StringLength(50)]
        public string TenGT { get; set; }

        public double? GiaGT { get; set; }

        [Required]
        [StringLength(50)]
        public string UrlAnh { get; set; }

        [StringLength(10)]
        public string MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
