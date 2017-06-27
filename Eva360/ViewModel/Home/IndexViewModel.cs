using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eva360.Models;
using static Eva360.Controllers.HomeController;

namespace Eva360.ViewModel.Home
{
    public class IndexViewModel
    {
        public List<Usuario> LstUsuario { get; set; }
    }
}