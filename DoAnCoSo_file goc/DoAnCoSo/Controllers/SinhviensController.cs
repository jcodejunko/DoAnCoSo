using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnCoSo.Models;

namespace DoAnCoSo.Controllers
{
    public class SinhviensController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Sinhviens
        public ActionResult Index()
        {
            var sinhviens = db.Sinhviens.Include(s => s.DanToc).Include(s => s.KhoaHoc).Include(s => s.Lop).Include(s => s.NghanhHoc).Include(s => s.QuanHuyen).Include(s => s.TonGiao).Include(s => s.TinhThanh);
            return View(sinhviens.ToList());
        }

        // GET: Sinhviens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // GET: Sinhviens/Create
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DanTocs, "MaDT", "TenDT");
            ViewBag.MaKH = new SelectList(db.KhoaHocs, "MaKH", "TenKH");
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            ViewBag.MaNH = new SelectList(db.NghanhHocs, "MaNH", "TenNH");
            ViewBag.MaQH = new SelectList(db.QuanHuyens, "MaQH", "TenQH");
            ViewBag.MaTG = new SelectList(db.TonGiaos, "MaTG", "TenTG");
            ViewBag.MaTT = new SelectList(db.TinhThanhs, "MaTT", "TenTT");
            return View();
        }

        // POST: Sinhviens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSSV,Hoten,GioTinh,NgaySinh,NamSinh,NoiSinh,Diachi,Email,SDT,TenCha,NgheCha,TenMe,NgheMe,TenNLL,DiaChiNLL,SdtNLL,MaDT,MaTG,MaTT,MaQH,MaKH,MaNH,MaLop")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Sinhviens.Add(sinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DanTocs, "MaDT", "TenDT", sinhvien.MaDT);
            ViewBag.MaKH = new SelectList(db.KhoaHocs, "MaKH", "TenKH", sinhvien.MaKH);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhvien.MaLop);
            ViewBag.MaNH = new SelectList(db.NghanhHocs, "MaNH", "TenNH", sinhvien.MaNH);
            ViewBag.MaQH = new SelectList(db.QuanHuyens, "MaQH", "TenQH", sinhvien.MaQH);
            ViewBag.MaTG = new SelectList(db.TonGiaos, "MaTG", "TenTG", sinhvien.MaTG);
            ViewBag.MaTT = new SelectList(db.TinhThanhs, "MaTT", "TenTT", sinhvien.MaTT);
            return View(sinhvien);
        }

        // GET: Sinhviens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DanTocs, "MaDT", "TenDT", sinhvien.MaDT);
            ViewBag.MaKH = new SelectList(db.KhoaHocs, "MaKH", "TenKH", sinhvien.MaKH);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhvien.MaLop);
            ViewBag.MaNH = new SelectList(db.NghanhHocs, "MaNH", "TenNH", sinhvien.MaNH);
            ViewBag.MaQH = new SelectList(db.QuanHuyens, "MaQH", "TenQH", sinhvien.MaQH);
            ViewBag.MaTG = new SelectList(db.TonGiaos, "MaTG", "TenTG", sinhvien.MaTG);
            ViewBag.MaTT = new SelectList(db.TinhThanhs, "MaTT", "TenTT", sinhvien.MaTT);
            return View(sinhvien);
        }

        // POST: Sinhviens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSSV,Hoten,GioTinh,NgaySinh,NamSinh,NoiSinh,Diachi,Email,SDT,TenCha,NgheCha,TenMe,NgheMe,TenNLL,DiaChiNLL,SdtNLL,MaDT,MaTG,MaTT,MaQH,MaKH,MaNH,MaLop")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DanTocs, "MaDT", "TenDT", sinhvien.MaDT);
            ViewBag.MaKH = new SelectList(db.KhoaHocs, "MaKH", "TenKH", sinhvien.MaKH);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhvien.MaLop);
            ViewBag.MaNH = new SelectList(db.NghanhHocs, "MaNH", "TenNH", sinhvien.MaNH);
            ViewBag.MaQH = new SelectList(db.QuanHuyens, "MaQH", "TenQH", sinhvien.MaQH);
            ViewBag.MaTG = new SelectList(db.TonGiaos, "MaTG", "TenTG", sinhvien.MaTG);
            ViewBag.MaTT = new SelectList(db.TinhThanhs, "MaTT", "TenTT", sinhvien.MaTT);
            return View(sinhvien);
        }

        // GET: Sinhviens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // POST: Sinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            db.Sinhviens.Remove(sinhvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
