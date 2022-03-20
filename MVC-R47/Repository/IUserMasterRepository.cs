using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_R47.Repository
{
    public interface IUserMasterRepository
    {
        IEnumerable<UserMaster> GetAll();
        UserMaster Get(int id);

    }
}