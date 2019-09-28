namespace PrimeFitness.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaGT { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual GoiTap GoiTap { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
