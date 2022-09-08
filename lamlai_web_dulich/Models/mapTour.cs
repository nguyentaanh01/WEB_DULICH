using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lamlai_web_dulich.Models
{
    public class mapTour
    {
        public string message = "";
        //Danh sách theo tỉnh thành
        public List<TourDuLich> DanhSachTheoTinh(int? idTinh)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var data = (from tour in db.TourDuLiches
                        join tinh in db.TinhThanhs on tour.idTinh equals tinh.ID_Tinh
                        where tinh.ID_Tinh == idTinh
                        select tour
                        ).ToList();
            return data;
        }

        //Danh sách theo loại tour
        public List<TourDuLich> DanhSachTheoLoai(int? idLoaiTour)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var data = (from tour in db.TourDuLiches
                        where tour.idLoaiTour == idLoaiTour
                        select tour
                        ).ToList();
            return data;
        }

        //Danh sách theo mức giá
        public List<TourDuLich> DanhSachTheoMucGia(int? idMucGia)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var data = (from tour in db.TourDuLiches
                        where tour.id_MucGia == idMucGia
                        select tour
                        ).ToList();
            return data;
        }

        //Danh sách theo tỉnh, loại tour, mức giá
        public List<TourDuLich> DanhSach(int? idTinh, int? idLoaiTour, int? idMucGia)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var data = (from item in db.TourDuLiches
                        where (item.idTinh == idTinh | idTinh == null)
                             & (item.idLoaiTour == idLoaiTour | idLoaiTour == null)
                             & (item.id_MucGia == idMucGia | idMucGia == null)
                        select item
                        ).ToList();
            return data;
        }

        public bool ThemMoi(TourDuLich model)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            try
            {
                if(string.IsNullOrEmpty(model.TieuDe) == true)
                {
                    message = "Thiếu thông tin tiêu đề";
                    return false;
                }
                db.TourDuLiches.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhat(TourDuLich model)
        {
            try
            {
                DuLichDBEntities db = new DuLichDBEntities();
                var updateModel = db.TourDuLiches.Find(model.ID);
                //Kiểm tra null 
                if (updateModel == null)
                {
                    return false;
                }
                //Cập Nhật giá trị cho các trường thông tin
                updateModel.TieuDe = model.TieuDe;
                updateModel.BaiViet = model.BaiViet;
                updateModel.DiaDiem = model.DiaDiem;
                updateModel.GiaTour = model.GiaTour;
                updateModel.HinhAnh = model.HinhAnh;
                updateModel.idLoaiTour = model.idLoaiTour;
                updateModel.idTinh = model.idTinh;
                updateModel.id_MucGia = model.id_MucGia;
                updateModel.LichDinhKy = model.LichDinhKy;
                updateModel.SoNgayDiTour = model.SoNgayDiTour;
                updateModel.SoNguoiToiDa = model.SoNguoiToiDa;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TourDuLich ChiTiet(int idTour)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            // return db.TourDuLiches.Find(idTour);
            return db.TourDuLiches.SingleOrDefault(item => item.ID == idTour);
        }


        public bool xoa(int idTour)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var model = db.TourDuLiches.Find(idTour);
            if(model != null)
            {
                db.TourDuLiches.Remove(model);
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