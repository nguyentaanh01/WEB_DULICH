//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lamlai_web_dulich.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TourDuLich
    {
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<double> SoNgayDiTour { get; set; }
        public string LichDinhKy { get; set; }
        public string DiaDiem { get; set; }
        public Nullable<int> SoNguoiToiDa { get; set; }
        public Nullable<double> GiaTour { get; set; }
        public string BaiViet { get; set; }
        public Nullable<int> idTinh { get; set; }
        public Nullable<int> idLoaiTour { get; set; }
        public Nullable<int> id_MucGia { get; set; }
    
        public virtual LoaiTour LoaiTour { get; set; }
        public virtual MucGia MucGia { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
    }
}
