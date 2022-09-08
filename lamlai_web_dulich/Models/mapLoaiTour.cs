using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lamlai_web_dulich.Models
{
    public class mapLoaiTour
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<LoaiTour> DanhSach()
        {
            return db.LoaiTours.ToList();
        }

        public LoaiTour Chitiet(int idLoaiTour)
        {
            //tìm kiếm đối tượng nếu có khoá là kiểu số , 1 khoá
            return db.LoaiTours.Find(idLoaiTour);
        }

        public string message = "";
        public bool ThemMoi(LoaiTour model)
        {
            try
            {
                //1. Kiểm tra đã điền thông tin chưa 
                if(string.IsNullOrEmpty(model.Ten) == true)
                {
                    message = "thiếu thông tin tên loại tour";
                    return false;
                }
                //2. Add thông tin vào csdl
                db.LoaiTours.Add(model);
                //3. Lưu lại
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhat(LoaiTour model)
        {
            try
            {
                //1. tim no da
                LoaiTour update = db.LoaiTours.Find(model.ID);
                //2. Kiem tra dieu kien
                if(update == null)
                {
                    return false;
                }
                //3. Add cái mới vào cái cũ
                update.Ten = model.Ten;
                //4. Luu lai
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idLoaiTour)
        {
            //1. tim no da
            LoaiTour delete = db.LoaiTours.Find(idLoaiTour);
            if(delete != null)
            {
                //2. xoa n di
                db.LoaiTours.Remove(delete);
                //3. luu lai
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