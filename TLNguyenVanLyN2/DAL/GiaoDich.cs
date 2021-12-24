namespace TLNguyenVanLyN2.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoDich")]
    public partial class GiaoDich
    {
        [Key]
        public long IdGD { get; set; }

        public long? SoTien { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGD { get; set; }

        [StringLength(20)]
        public string IdLoai { get; set; }

        public long? IdVi { get; set; }

        public virtual LoaiGD LoaiGD { get; set; }

        public virtual Vi Vi { get; set; }
    }
}
