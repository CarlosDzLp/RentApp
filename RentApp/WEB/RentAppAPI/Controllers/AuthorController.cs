using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RentAppAPI.Context;
using RentAppEntities.Entities;
using System.Linq;

namespace RentAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public AuthorController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Context.Users.ToList();
        }

        [HttpGet("Primer")]
        public ActionResult<IEnumerable<User>> GetPrimer()
        {
            return Context.Users.ToList();
        }
    }
}
