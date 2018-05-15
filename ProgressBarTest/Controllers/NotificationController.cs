﻿using ProgressBarTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgressBarTest.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetNotification()
        {
            return Json(NotificationService.GetNotification(), JsonRequestBehavior.AllowGet);
        }
    }
}