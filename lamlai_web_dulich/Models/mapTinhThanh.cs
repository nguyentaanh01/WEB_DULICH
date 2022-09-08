using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lamlai_web_dulich.Models
{
    public class mapTinhThanh
    {
        public string message = "";
        public List<TinhThanh> DanhSach()
        {
            DuLichDBEntities db = new DuLichDBEntities();
            //Lấy hết tất cả bảng Tỉnh thành
            //List<TinhThanh> data = db.TinhThanhs.ToList();
            //Sử dụng query linq để lọc dữ liệu
            List<TinhThanh> data2 = (from tinh in db.TinhThanhs
                                     select tinh
                                     ).ToList();

            return data2;
        }

        //Lấy 2 tỉnh thành có ID lớn nhất
        public List<TinhThanh> Top2TinhThanh()
        {
            DuLichDBEntities db = new DuLichDBEntities();
            //Sử dụng linq
            List<TinhThanh> data3 = (from tinh in db.TinhThanhs
                                     orderby tinh.ID_Tinh descending
                                     select tinh
                                     ).ToList().Take(2).ToList();
            return data3;
        }

        //Lọc dữ liệu với where
        public List<TinhThanh> DanhSachTheoTen(string ten)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            //Sử dụng linq
            List<TinhThanh> data3 = (from tinh in db.TinhThanhs
                                     where tinh.Ten.ToLower().Contains(ten.ToLower()) == true
                                     select tinh
                                     ).ToList();
            return data3;
        }

        public bool ThemMoi(TinhThanh model)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(model.Ten) == true)
                {
                    message = "Thiếu Tên Tỉnh";
                    return false;
                }
                //Thêm mới
                db.TinhThanhs.Add(model);
                db.SaveChanges();
                //Nếu thêm được : trả về true
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TinhThanh ChiTiet(int idTinh)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            return db.TinhThanhs.Find(idTinh);
        }

        public bool CapNhat(TinhThanh model)
        {
            try
            {
                //Tìm kiếm tỉnh thành cần sửa
                DuLichDBEntities db = new DuLichDBEntities();
                var update = db.TinhThanhs.Find(model.ID_Tinh);
                //Kiểm tra null
                if(update == null)
                {
                    return false;
                }
                //Cập nhật giá trị cho các trường
                update.Ten = model.Ten;
                //Lưu lại và trả về giá trị true
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(int idTinh)
        {
            //tim doi tuong
            DuLichDBEntities db = new DuLichDBEntities();
            var model = db.TinhThanhs.Find(idTinh);
            if(model != null)
            {
                db.TinhThanhs.Remove(model);
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