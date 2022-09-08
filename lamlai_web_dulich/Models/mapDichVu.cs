using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Models
{
    public class mapDichVu
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<DichVu> DanhSach()
        {
            return db.DichVus.ToList();
        }

        public string message = "";
        public bool ThemMoi(DichVu model)
        {
            try
            {
                if(string.IsNullOrEmpty(model.TenDichVu) == true)
                {
                    message = "Thiếu thông tin tên dịch vụ";
                    return false;
                }
                if (string.IsNullOrEmpty(model.LinkSeo) == true)
                {
                    message = "thiếu đường link seo";
                    return false;
                }
                if (string.IsNullOrEmpty(model.NoiDung) == true)
                {
                    message = "thiếu nội dung";
                    return false;
                }
                db.DichVus.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DichVu ChiTiet(int idDichVu)
        {
            return db.DichVus.Find(idDichVu);
        }

        public bool CapNhat(DichVu model)
        {
            try
            {
                DichVu update = db.DichVus.Find(model.ID);
                if(update == null)
                {
                    return false;
                }
                update.TenDichVu = model.TenDichVu;
                update.LinkSeo = model.LinkSeo;
                update.NoiDung = model.NoiDung;
                update.HinhAnh = model.HinhAnh;
                update.HoatDong = model.HoatDong;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idDichVu)
        {
            DichVu delete = db.DichVus.Find(idDichVu);
            if(delete != null)
            {
                db.DichVus.Remove(delete);
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