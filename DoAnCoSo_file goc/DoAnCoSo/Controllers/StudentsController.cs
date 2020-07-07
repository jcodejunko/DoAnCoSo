using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnCoSo.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using OfficeOpenXml;

namespace DoAnCoSo.Controllers
{
    public class StudentsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Sinhviens.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien student = db.Sinhviens.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSSV,Ho,Ten,NgaySinh,NoiSinh,GioiTinh,DanToc,TonGiao,Diachithuongtru,Tinh,QuanHuyen,QuocGia,CMND,DoanDang,Uutien,KhuVuc")] Sinhvien student)
        {
            if (ModelState.IsValid)
            {
                db.Sinhviens.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien student = db.Sinhviens.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSSV,Ho,Ten,NgaySinh,NoiSinh,GioiTinh,DanToc,TonGiao,Diachithuongtru,Tinh,QuanHuyen,QuocGia,CMND,DoanDang,Uutien,KhuVuc")] Sinhvien student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien student = db.Sinhviens.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sinhvien student = db.Sinhviens.Find(id);
            db.Sinhviens.Remove(student);
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
        public void export()
        {
            SqlConnection conn = new SqlConnection();
            string DatabaseEntities = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            conn.ConnectionString = DatabaseEntities;
            conn.Open();
            DataTable DtNew = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Student", conn);
            adp.Fill(DtNew);
            if (DtNew.Rows.Count > 0)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                var filename = new FileInfo("excel");
                using (var excel = new OfficeOpenXml.ExcelPackage(filename))
                {
                    var sheetcreate = excel.Workbook.Worksheets.Add("Data");
                    for (int i = 0; i < DtNew.Columns.Count; i++)
                    {
                        sheetcreate.Cells[1, i + 1].Value = DtNew.Columns[i].ColumnName.ToString();
                    }
                    for (int i = 0; i < DtNew.Rows.Count; i++)
                    {
                        for (int j = 0; j < DtNew.Columns.Count; j++)
                        {
                            sheetcreate.Cells[i + 2, j + 1].Value = DtNew.Rows[i][j].ToString();
                        }
                    }
                    Session["DownloadExcel_FileManager"] = excel.GetAsByteArray();
                }
            }
            conn.Close();
        }
        public ActionResult Download()
        {
            export();
            byte[] data = Session["DownloadExcel_FileManager"] as byte[];
            return File(data, "application/octet-stream", "DuLieu.xlsx");
        }
    }
}
