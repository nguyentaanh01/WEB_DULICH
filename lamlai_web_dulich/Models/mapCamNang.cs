using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Models
{
    public class mapCamNang
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<CamNangDuLich> DanhSach()
        {
            return db.CamNangDuLiches.ToList();
        }

        public CamNangDuLich ChiTiet(int idCamNang)
        {
            return db.CamNangDuLiches.Find(idCamNang);
        }

        public string message = "";
        public bool ThemMoi(CamNangDuLich model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TieuDe) == true)
                {
                    message = "Thiếu thông tin tieu de";
                    return false;
                }
                if (string.IsNullOrEmpty(model.TomTat) == true)
                {
                    message = "thiếu thong tin tom tat";
                    return false;
                }
                if (string.IsNullOrEmpty(model.NoiDung) == true)
                {
                    message = "thiếu nội dung";
                    return false;
                }
                db.CamNangDuLiches.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhat(CamNangDuLich model)
        {
            try
            {
                CamNangDuLich update = db.CamNangDuLiches.Find(model.ID);
                if (update == null)
                {
                    return false;
                }
                update.TieuDe = model.TieuDe;
                update.TomTat = model.TomTat;
                update.HinhAnh = model.HinhAnh;
                update.NoiDung = model.NoiDung;
                update.NgayViet = model.NgayViet;
                update.HienTrangChu = model.HienTrangChu;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idCamNang)
        {
            CamNangDuLich delete = db.CamNangDuLiches.Find(idCamNang);
            if (delete != null)
            {
                db.CamNangDuLiches.Remove(delete);
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