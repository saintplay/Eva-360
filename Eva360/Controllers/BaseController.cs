using Eva360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eva360.Controllers
{
    public class BaseController : Controller
    {
        public EVA360Entities context { get; set; }
        public BaseController()
        {
            context = new EVA360Entities();
        }
        public void PostMessage(MessageType type, String message)
        {
            TempData["FlashMessage"] = message;
            switch (type)
            {
                case MessageType.Success: TempData["FlashMessageType"] = "alert alert-success"; break;
                case MessageType.Error: TempData["FlashMessageType"] = "alert alert-danger"; break;
                case MessageType.Info: TempData["FlashMessageType"] = "alert alert-info"; break;
                case MessageType.Warning: TempData["FlashMessageType"] = "alert alert-warning"; break;
            }
        }
    }

    public enum MessageType
    {
        Success,
        Error,
        Info,
        Warning
    }
}