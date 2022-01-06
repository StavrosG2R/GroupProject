using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroupProject.Controllers.Api
{
    public class StoragesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoragesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult GetStorage(int id)
        {
            var storage = _unitOfWork.Storages.GetById(id);
            return Ok(storage);
        }
    }
}
