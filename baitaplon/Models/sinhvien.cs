//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace baitaplon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sinhvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sinhvien()
        {
            this.diemthi = new HashSet<diemthi>();
        }
    
        public int MaSV { get; set; }
        public string TenSV { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public Nullable<int> MaLop { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diemthi> diemthi { get; set; }
        public virtual lop lop { get; set; }
    }
}