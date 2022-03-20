using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_R47.Repository
{
    public interface IChapter5
    {
        Mystudent2 GetAll(int id=0);
        string Create(Mystudent2 myst);
        string Update(Mystudent2 myst);
        string Delete(int? id);
        List<Mystudent2> CommonMethod();
        List<Mystudent2> GetAll1();
    }
}
