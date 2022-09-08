using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Models
{
    public class mapTaiKhoan
    {
        public List<TaiKhoan> DanhSach()
        {
            try
            {
                DuLichDBEntities db = new DuLichDBEntities();
                return db.TaiKhoans.ToList();
            }
            catch
            {
                return new List<TaiKhoan>();
            }
        }
        public TaiKhoan ChiTiet(string tenDangNhap)
        {
            try
            {
                DuLichDBEntities db = new DuLichDBEntities();
                var model = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap == tenDangNhap.ToLower());
                return model;
            }
            catch
            {
                return null;
            }
        }

        public bool  AdminCapNhat(TaiKhoan model)
        {
            //1. Tìm đối tượng 
            DuLichDBEntities db = new DuLichDBEntities();
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == model.TenDangNhap.ToLower());
            //2. Kiểm tra tồn tại
            if(updateModel == null)
            {
                return false;
            }
            //3. Cập Nhật
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.TenHienThi = model.TenHienThi;
            updateModel.Email = model.Email;
            db.SaveChanges();
            return true;
        }

        public bool DoiMatkhau(string tenDangNhap, string matkhaumoi)
        {
            //1. Tìm đối tượng 
            DuLichDBEntities db = new DuLichDBEntities();
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == tenDangNhap.ToLower());
            //2. Kiểm tra tồn tại
            if (updateModel == null)
            {
                return false;
            }
            //3. Cập Nhật
            updateModel.MatKhau = matkhaumoi;
            db.SaveChanges();
            return true;
        }

        public bool DoiHinhAnh(string tenDangNhap, string linkAnh)
        {
            //1. Tìm đối tượng 
            DuLichDBEntities db = new DuLichDBEntities();
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == tenDangNhap.ToLower());
            //2. Kiểm tra tồn tại
            if (updateModel == null)
            {
                return false;
            }
            //3. Cập Nhật
            updateModel.HinhAnh = linkAnh;
            db.SaveChanges();
            return true;
        }


    }
}