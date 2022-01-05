using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class CPUsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public IHttpActionResult GetCpus()
        {
            var cpus = _unitOfWork.Cpus.GetAll();
            return Ok(cpus);
        }

        public IHttpActionResult GetCpus(int id)
        {
            var motherboardSocket = _unitOfWork.Motherboards.GetById(id).Socket;
            return Ok(_unitOfWork.Cpus.GetCPUsThatMatchTheSocket(motherboardSocket));
        }

        public IHttpActionResult Details(int id)
        {
            var details = _unitOfWork.Cpus.GetById(id);
            return Ok(details);
        }
    }
}
