using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Models
{
    public class mapHinhAnh
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<HinhAnh> DanhSach(int idAlbum)
        {
            List<HinhAnh> data = (from hinhanh in db.HinhAnhs
                                  where hinhanh.idAlbum == idAlbum
                                  select hinhanh).ToList();
            return data;
        }
    }
}