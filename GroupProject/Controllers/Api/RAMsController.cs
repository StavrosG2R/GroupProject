using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class RAMsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public RAMsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetRAM(int id)
        {
            var ram = _unitOfWork.Rams.GetById(id);
            return Ok(ram);
        }
    }
}
