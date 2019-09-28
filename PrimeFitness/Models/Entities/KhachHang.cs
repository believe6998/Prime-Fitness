namespace PrimeFitness.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaND { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }
    }
}
