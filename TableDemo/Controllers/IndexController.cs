using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TableDemo.Controllers
{
    public class IndexController : Controller
    {
        private static List<demo> d;
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDepartment(int limit, int offset,string text1 = "",string text2 = "")
        {
            List<demo> demolist = new List<demo>();
            for (var i = 0; i < 100; i++)
            {
                demo d = new demo();
                d.id = i;
                d.one = "one" + i;
                d.two = "two" + i;
                demolist.Add(d);
            }
      
            if (text1 != "") {
                demolist = demolist.Where(a => a.one.Contains(text1)).ToList();
            }
            if (text2 != "") {
                demolist = demolist.Where(a =>  a.two.Contains(text2)).ToList();
            } 
            return Json(new { total = 100, rows = demolist.Skip(offset).Take(limit).ToList()}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        //行内编辑使用
        public JsonResult Edit(demo user)
        {
            //逻辑

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }


        public class demo
        {
            public int id { get; set; }

            public string one { get; set; }
            public string two { get; set; }
        }

    }
}