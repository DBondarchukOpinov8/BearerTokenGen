﻿using Microsoft.AspNetCore.Mvc;

namespace BearerTokenGen.Controllers {
    public class TokenController : Controller {

        public IActionResult Index() {
            return View();
        }
    }
}
