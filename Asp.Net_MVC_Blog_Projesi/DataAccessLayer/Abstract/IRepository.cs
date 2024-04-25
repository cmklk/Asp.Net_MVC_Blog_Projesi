﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>
    {
        List<T>  List(); // tüm listeyi alma.

        int Insert(T p);

        int Delete(T p);

        int Update(T p);

        T GetById(int id);

        List<T> List(Expression<Func<T,bool>> filter); // şartlı listeleme.

        T Find(Expression<Func<T, bool>> where);
    }
}
