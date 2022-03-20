using MVC_R47.Filters;
using MVC_R47.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class Chapter8Controller : Controller
    {
        readonly IUserMasterRepository userRepository;
        // GET: Chapter8
        public Chapter8Controller()
        {

        }
        public Chapter8Controller(IUserMasterRepository repository)
        {
            this.userRepository = repository;
        }
        public ActionResult User_Index()
        {
            var data = userRepository.GetAll();//3 records
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = userRepository.Get(id);
            return View(data);
        }
        [Compress(Order = 2)]
        [Authorize(Order = 1)]
        public ActionResult MyHeaders()
        {
            return View();
        }

    }
}