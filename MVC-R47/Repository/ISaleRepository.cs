﻿using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_R47.Repository
{
   public interface ISaleRepository
    {
        IEnumerable<sale> GetSales();
        sale GetOneSale(int? id);
        int Create(sale sale);
        int Update(sale sale);
        int Delete(int? id);
    }
}
