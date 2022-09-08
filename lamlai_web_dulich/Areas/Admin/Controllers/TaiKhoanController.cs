using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {
            //1. Kiểm tra tên đăng nhập hoặc mật khẩu có trông không 
                //=> Trở về trang đăng nhập: Thông báo thiếu thông tin
            if(string.IsNullOrEmpty(tenDangNhap) == true | string.IsNullOrEmpty(matKhau) == true)
            {
                ViewBag.thongbao = "Thông báo thiếu thông tin";
                return View();
            }
            //2. Tìm tài khoản theo tên đăng nhập trong database
            var taikhoan = new mapTaiKhoan().ChiTiet(tenDangNhap);

            //3. Kiểm tra tồn tại tài khoản => nếu không tồn tại 
                //=> Trở về trang đăng nhập: Tài khoản hoặc mật khẩu không đúng
            if(taikhoan == null)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //4. Kiểm tra mật khẩu => Nếu sai => Trở về trang đăng nhập: Tài khoản hoặc mật khẩu không đúng
            if(taikhoan.MatKhau != matKhau)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //5. Kiểm tra active(hoat dong)
            if(taikhoan.Active != true)
            {
                ViewBag.thongbao = "Tài khoản đang tạm khoá";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }

            //6. Tài khoản đăng nhập ok: Lưu lại session sever
            Session["user"] = taikhoan;


            //7. Chuyển hướng sang trang chủ Admin
            return Redirect("/Admin/HomeAdmin/Index");
        }

        public ActionResult DanhSach()
        {
            return View(new mapTaiKhoan().DanhSach());
        }

        //Bước 2: Tạo form 
        public ActionResult CapNhatAnh(string tendangNhap)
        {
            return View(new mapTaiKhoan().ChiTiet(tendangNhap));
        }
        [HttpPost]
        //Bước 3: Xử lý lưu ảnh
        public ActionResult CapNhatAnh(string tenDangNhap, HttpPostedFileBase avatar)
        {
            //1. Kiểm tra file có tồn tại không
            if(avatar == null)
            {
                ViewBag.error = "Chưa chọn file";
                return View(new mapTaiKhoan().ChiTiet(tenDangNhap));
            }
            //2. Lưu file
            //Đường dẫn thư mục lưu file 
            var duongDanTuongDoi = "/Data/avatar";
            //Đường dẫn tuyệt đối
            var duongDanTuyetDoi = Server.MapPath(duongDanTuongDoi);
            //Đường dẫn lưu ảnh = duongDanTuyetDoi + tên hình ảnh
            var ddHinhAnhTuongDoi = duongDanTuongDoi + avatar.FileName;
            var ddHinhAnhTuyetDoi = duongDanTuyetDoi + avatar.FileName;
            //Lưu
            avatar.SaveAs(ddHinhAnhTuyetDoi);

            //3. Lưu thành công thì cập nhật link cho model (tài khoản)
            new mapTaiKhoan().DoiHinhAnh(tenDangNhap, ddHinhAnhTuongDoi);

            return RedirectToAction("DanhSach");
        }
    }
}