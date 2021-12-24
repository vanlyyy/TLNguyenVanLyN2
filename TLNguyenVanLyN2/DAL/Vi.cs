namespace TLNguyenVanLyN2.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vi")]
    public partial class Vi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vi()
        {
            GiaoDiches = new HashSet<GiaoDich>();
        }

        [Key]
        public long IdVi { get; set; }

        [StringLength(100)]
        public string TenVi { get; set; }

        public long? SoTien { get; set; }

        public long? IdPerson { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoDich> GiaoDiches { get; set; }

        public virtual Person Person { get; set; }
    }
}
