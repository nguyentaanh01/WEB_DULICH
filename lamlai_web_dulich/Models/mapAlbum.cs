using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Models
{
    public class mapAlbum
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<AlbumAnh> DanhSach()
        {
            return db.AlbumAnhs.ToList();
        }

        public string message = "";
        public bool ThemMoi(AlbumAnh model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenAlbum) == true)
                {
                    message = "Thiếu thông tin tên AlBum";
                    return false;
                }
                if (string.IsNullOrEmpty(model.NguoiDang) == true)
                {
                    message = "thiếu thông tin người đăng";
                    return false;
                }
                if (string.IsNullOrEmpty(model.MoTa) == true)
                {
                    message = "thiếu nội dung mô tả";
                    return false;
                }
                db.AlbumAnhs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AlbumAnh ChiTiet(int idAlbum)
        {
            return db.AlbumAnhs.Find(idAlbum);
        }

        public bool CapNhat(AlbumAnh model)
        {
            try
            {
                AlbumAnh update = db.AlbumAnhs.Find(model.ID);
                if (update == null)
                {
                    return false;
                }
                update.TenAlbum = model.TenAlbum;
                update.NguoiDang = model.NguoiDang;
                update.ThoiGian = model.ThoiGian;
                update.MoTa = model.MoTa;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idAlbum)
        {
            AlbumAnh delete = db.AlbumAnhs.Find(idAlbum);
            if (delete != null)
            {
                db.AlbumAnhs.Remove(delete);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}