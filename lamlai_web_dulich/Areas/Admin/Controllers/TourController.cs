using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class TourController : Controller
    {
        // GET: Admin/Tour
        public ActionResult DanhSach()
        {
            mapTour map = new mapTour();
            return View(map.DanhSach(null, null, null));
        }

        public ActionResult ThemMoi()
        {
            return View(new TourDuLich());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(TourDuLich model)
        {
            mapTour map = new mapTour();
            if(map.ThemMoi(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                //Thông báo lỗi:
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }

        public ActionResult CapNhat(int idTour)
        {
            //Tìm đối tượng cần sửa
            var map = new mapTour();
            var tourEdit = map.ChiTiet(idTour);
            return View(tourEdit);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(TourDuLich model)
        {
            mapTour map = new mapTour();
            if(map.CapNhat(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                //Thông báo lỗi:
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }

        public ActionResult Xoa(int idTour)
        {
            //Gọi Hàm xoá trong Map(class)
            mapTour map = new mapTour();
            map.xoa(idTour);
            //Xoá xong quay về trang danh sách
            return RedirectToAction("DanhSach");
        }
    }
}