using DatabaseAccess.Models;
using System;
using System.Collections.Generic;

namespace DatabaseAccess.Repositories
{
    public interface IStudioRepository
    {
        List<Studio> GetAll();
        Studio GetById(int studioId);
        void Create(Studio studio);
        //List<Members> Read();
        void Update(int index, Studio studio);
        void Delete(int index);
        Studio Get(Func<Studio, bool> expression);
    }
}
