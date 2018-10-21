using DiseaseDetection.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiseaseDetection.Controllers
{
    public class HomeController : Controller
    {
        ClinicalDecisionEntities db = new ClinicalDecisionEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Assessment()
        {
            
            var symp= "";
            
                symp = string.Join(",", db.DiseaseTSCRs.Where(x=>x.IsDeleted==false).Select(s=>s.Symptoms));
            
            ViewBag.symptoms = symp.Split(',').ToList();
            var rand = new Random();
            ViewBag.RandomSymptom = ViewBag.symptoms[rand.Next(ViewBag.symptoms.Count)];
            return View();
        }
        
        [HttpGet]
        public ActionResult GetRandomSymptom(string data)
        {
            try
            {
                string dat = data.Replace("\"", "");
                var arrayList = dat.Split(',').ToList();
                var symptoms = "";

                //Left work from here
                foreach (var item in arrayList)
                {
                    symptoms = string.Join(",", db.DiseaseTSCRs.Where(x => x.IsDeleted == false && x.Symptoms.Contains(item))
                        .Select(s => s.Symptoms).ToList());
                }
                
                ViewBag.symptoms = symptoms.Split(',').ToList();
                var rand = new Random();
                ViewBag.RandomSymptom = ViewBag.symptoms[rand.Next(ViewBag.symptoms.Count)];

                return Json(ViewBag.RandomSymptom, JsonRequestBehavior.AllowGet);
            }catch(Exception ex)
            {
                var err = ex.Message;
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult Diagnosis(string data)
        //{
        //    try
        //    {
        //        string dat = data.Replace("\"", "");
        //        var arrayList = dat.Split(',').ToList();
        //        var disease = "";

        //        //Left work from here
        //        foreach (var item in arrayList)
        //        {
        //            disease = string.Join(",", db.DiseaseTSCRs.Where(x => x.IsDeleted == false && x.Symptoms.Contains(item))
        //                .Select(s => s.Types).ToList());
        //        }
        //        var arrayLst = disease.Split(',').ToList();
        //        foreach (var item in arrayLst)
        //        {
        //            ViewBag.DiseaseType = item;
        //            ViewBag.Causes = db.DiseaseTSCRs.Where(x => x.Types.Contains(item)).Select(s => s.Causes).ToList();
        //            ViewBag.Symptoms = db.DiseaseTSCRs.Where(x => x.Types.Contains(item)).Select(s => s.Symptoms).ToList();
        //            ViewBag.Remedies = db.DiseaseTSCRs.Where(x => x.Types.Contains(item)).Select(s => s.Remedies).ToList();
        //        }
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        var err = ex.Message;
        //        return Json(0, JsonRequestBehavior.AllowGet);
        //    }
        //    return View();
        //}
        public ActionResult Diagnosis()
        {
            return View();
        }
    }
}
