﻿namespace EasyPTC.Web.Areas.Administration.Controllers.Base
{
    using EasyPTC.Data;
    using EasyPTC.Web.Controllers;
    using System.Web.Mvc;

    // [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IEasyPtcData data)
            : base(data)
        {

        }
    }
}