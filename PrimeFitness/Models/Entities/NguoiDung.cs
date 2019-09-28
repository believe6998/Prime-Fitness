namespace PrimeFitness.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Password { get; set; }

        [StringLength(10)]
        public string HoTen { get; set; }
    }
}
