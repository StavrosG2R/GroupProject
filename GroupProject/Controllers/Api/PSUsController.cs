using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class PSUsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PSUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetPSU(int id)
        {
            var psu = _unitOfWork.Psus.GetById(id);
            return Ok(psu);
        }
    }
}
