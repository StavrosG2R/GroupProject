using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class MotherboardsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MotherboardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetMotherboards()
        {
            var motherboards = _unitOfWork.Motherboards.GetAllWithCompanies();
            return Ok(motherboards);
        }

        public IHttpActionResult GetMotherboards(int id)
        {
            var cpuSocket = _unitOfWork.Cpus.GetById(id).Socket;
            return Ok(_unitOfWork.Motherboards.GetMotherboardsThatMatchTheSocket(cpuSocket));
        }
    }
}
