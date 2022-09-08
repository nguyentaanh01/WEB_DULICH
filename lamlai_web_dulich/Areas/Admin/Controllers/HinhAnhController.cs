using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class HinhAnhController : Controller
    {
        // GET: Admin/HinhAnh
        public ActionResult DanhSach(int idAlbum)
        {
            mapHinhAnh map = new mapHinhAnh();
            return View(map.DanhSach(idAlbum));
        }
    }
}