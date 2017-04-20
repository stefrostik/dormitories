using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dormitories.DAL.Models;

namespace Dormitories.WEB.Controllers
{
    public class DormitoriesController : ApiController
    {
        
        public List<Dormitory> Get()
        {
            //todo: implement fetching logic
            return new List<Dormitory>();
        }
    }
}
