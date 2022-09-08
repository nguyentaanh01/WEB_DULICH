using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class TinhThanhController : Controller
    {
        // GET: Admin/TinhThanh
        public ActionResult DanhSach()
        {
            mapTinhThanh map = new mapTinhThanh();
            List<TinhThanh> danhsach = map.DanhSach().ToList();
            return View(danhsach);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(TinhThanh model)
        {
            //Khởi tạo class mapTinhThanh
            mapTinhThanh map = new mapTinhThanh();
            //Nếu Hàm trả về true thì trở lại trang danh sách
            if(map.ThemMoi(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                //Thông báo lỗi
                ViewBag.thongbao = map.message;
                return View();
            }
        }

        public ActionResult CapNhat(int idTinh)
        {
            //Tìm đối tượng cần sửa
            mapTinhThanh map = new mapTinhThanh();
            var tinhEdit = map.ChiTiet(idTinh);
            return View(tinhEdit);
        }

        [HttpPost]
        public ActionResult CapNhat(TinhThanh model)
        {
            mapTinhThanh map = new mapTinhThanh();
            if(map.CapNhat(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Xoa(int idTinh)
        {
            //goi ham xoa trong map ra
            mapTinhThanh map = new mapTinhThanh();
            map.Xoa(idTinh);
            //xoa trong tra ve trang danh sach
            return RedirectToAction("DanhSach");
        }
    }
}