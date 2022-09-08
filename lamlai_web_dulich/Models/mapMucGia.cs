using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lamlai_web_dulich.Models
{
    public class mapMucGia
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<MucGia> DanhSach()
        {
            return db.MucGias.ToList();
        }

        public string message = "";
        public bool ThemMoi(MucGia model)
        {
            try
            {
                //1. kiem tra da dien thong tin chua
                if (string.IsNullOrEmpty(model.Gia) == true)
                {
                    message = "ban chua dien loai gia";
                    return false;
                }
                //2. add du lieu vao
                db.MucGias.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MucGia ChiTiet(int idMucGia)
        {
            return db.MucGias.Find(idMucGia);
        }

        public bool CapNhat(MucGia model)
        {
            try
            {
                //1. tim no da
                MucGia update = db.MucGias.Find(model.ID);
                if(update == null)
                {
                    return false;
                }
                update.Gia = model.Gia;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idMucGia)
        {
            MucGia delete = db.MucGias.Find(idMucGia);
            if(delete != null)
            {
                db.MucGias.Remove(delete);
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