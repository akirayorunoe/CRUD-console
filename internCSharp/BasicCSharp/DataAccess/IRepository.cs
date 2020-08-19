using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRepository
    {
        List<Members> ReadFromFile();
        void Create(Members member);
        //List<Members> Read();
        List<Members> Update(int index,Members member);
        List<Members> Delete(int index);
    }
}
