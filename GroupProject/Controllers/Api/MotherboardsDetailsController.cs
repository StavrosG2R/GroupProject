using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class MotherboardsDetailsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MotherboardsDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetMotherboards(int id)
        {
            var motherboards = _unitOfWork.Motherboards.GetById(id);
            return Ok(motherboards);
        }
    }
}
