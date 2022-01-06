using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class GPUsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public GPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetGPU(int id)
        {
            var gpu = _unitOfWork.Gpus.GetById(id);
            return Ok(gpu);
        }
    }
}
