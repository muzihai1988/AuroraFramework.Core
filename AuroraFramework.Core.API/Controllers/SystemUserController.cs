using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuroraFramework.Core.IRepository;
using AuroraFramework.Core.IServices;
using AuroraFramework.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraFramework.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        readonly ISystemUserServices _systemUserServices;
        public SystemUserController(ISystemUserServices systemUserServices)
        {
            _systemUserServices = systemUserServices;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            var models = await _systemUserServices.Query();
            return Ok(new
            {
                success = true,
                data = models
            });
        }
    }
}