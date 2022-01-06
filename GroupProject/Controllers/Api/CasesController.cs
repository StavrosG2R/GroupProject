using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class CasesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetCase(int id)
        {
            var cases = _unitOfWork.Cases.GetById(id);
            return Ok(cases);
        }

    }
}
