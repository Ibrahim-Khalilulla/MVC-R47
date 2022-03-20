using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_R47.Repository
{
    public class SaleRepository:ISaleRepository
    {
        private cm_restoEntities _db ;
        public SaleRepository()
        {
            _db = new cm_restoEntities();
        }
        public IEnumerable<sale> GetSales()
        {
            return _db.sales;
        }
        public sale GetOneSale(int? id)
        {
            return _db.sales.Find(id);
        }
        public int Create(sale sale)
        {
            _db.sales.Add(sale);
            int i = _db.SaveChanges();
            return i;
        }
        public int Update(sale sale)
        {
            //sale s = _db.sales.Find(sale.Bookid);
            //s.SaleDate = sale.SaleDate;
            //s.Quantity = sale.Quantity;
            //_db.Entry(s).State = EntityState.Modified;
            //int i = _db.SaveChanges();
            int i = 1;
            return i;
        }
        public int Delete(int? id)
        {
            sale sale = _db.sales.Find(id);
            _db.sales.Remove(sale);
            int a = _db.SaveChanges();
            return a;
        }


    }
}