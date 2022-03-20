using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC_R47.Repository
{
    public class Chapter5 : IChapter5
    {
        private cm_restoEntities db = new cm_restoEntities();
        List<Mystudent2> a = new List<Mystudent2>();
        public string Create(Mystudent2 myst)
        {
            string FileName = Path.GetFileName(myst.ImageFile.FileName);
            string FilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), FileName);

            student2 a = new student2();
            a.id = myst.id;
            a.name = myst.name;
            a.@class = myst.@class;
            a.fee = myst.fee;
            a.picturepath = FileName;
            try
            {
                myst.ImageFile.SaveAs(FilePath);
                db.student2.Add(a);
                db.SaveChanges();
                return "Successfully inserted";

            }
            catch (Exception ex)
            {
                return  ex.Message.ToString();
                

            }
        }

        public string Delete(int? id)
        {
            student2 student;
            student = (from st1 in db.student2 where st1.id == id select st1).FirstOrDefault();

            db.student2.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            return $"Succesfully deleted {id}";
            
        }

        public Mystudent2 GetAll(int id = 0)
        {
            Mystudent2 b = new Mystudent2();
            var item = (from c in db.student2 where c.id == id select c).Distinct().FirstOrDefault();
            if (item != null)//if the item exists
            {
                b = new Mystudent2() { id = item.id, name = item.name, @class = item.@class, fee = item.fee };
            }
            return b;
        }

        public List<Mystudent2> GetAll1()
        {
            List<Mystudent2> b = new List<Mystudent2>();
            var item1 = (from c in db.student2 select c).ToList();
          foreach(var item in item1)
            {
                b.Add(new Mystudent2() { id = item.id, name = item.name, @class = item.@class, fee = item.fee }); ;
            }
            return b;
        }

        public string Update(Mystudent2 myst)
        {
            try
            {
                student2 item = null;
                item = (from c in db.student2 where c.id == myst.id select c).FirstOrDefault();
                if (item == null)
                {
                    return $"Item with id {myst.id} was not found";
                }
                db.Entry(item).State = EntityState.Modified;
                //TryUpdateModel(item);
                db.SaveChanges();

                return $"Successfully Updated the record: {myst.id}";
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

               return ex.Message.ToString();

            }
        }
        

        List<Mystudent2> IChapter5.CommonMethod()
        {
            foreach (var d in db.student2.ToList())
            {
                a.Add(new Mystudent2() { id = d.id, name = d.name, fee = d.fee, @class = d.@class, picturepath = d.picturepath });
            }
            return a;
        }
    }
}