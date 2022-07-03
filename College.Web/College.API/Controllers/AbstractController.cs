using System;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.API.Controllers
{
    public abstract class AbstractController : ControllerBase

    {
        protected UserRecord CurrentUser => ((Task<UserRecord>)HttpContext.Items["User"]).Result;
    }
}

