﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult SendMessage()
        {
            return View();
        }

        public ActionResult IncomingMessage()
        {
            return View();
        }
    }
}