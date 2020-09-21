using DatabaseAccess.DBContexts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAccess.Repositories
{
    public class StudioRepository:IStudioRepository
    {
        private MemberProfileContext _DBContext = null;
        public StudioRepository(MemberProfileContext context)
        {
            _DBContext = context;
        }
        public List<Studio> GetAll()
        {
            return _DBContext.Studios.ToList();
        }

        public Studio GetById(int studioId)
        {
            var studio = _DBContext.Studios.FirstOrDefault(stu => stu.StudioId == studioId);
            return studio;
        }

        public void Create(Studio studio)
        {
            _DBContext.Studios.Add(studio);
            _DBContext.SaveChanges();
        }

        public void Update(int index, Studio updateStudio)
        {

            foreach (var studio in _DBContext.Studios.ToList())
            {
                if (studio.StudioId == index)
                {
                    studio.StudioName = updateStudio.StudioName;
                    studio.ManagerEmail = updateStudio.ManagerEmail;
                    studio.Address = updateStudio.Address;
                    _DBContext.Studios.Update(studio);
                    _DBContext.SaveChanges();

                }
            }
        }

        public void Delete(int index)
        {
            var studio = new Studio()
            {
                StudioId = index
            };
            _DBContext.Studios.Remove(studio);
        }

        
        public Studio Get(Func<Studio, bool> expression)
        {
            if (expression != null)
                return _DBContext.Studios.FirstOrDefault(expression);
            else return null;
        }
    }
}
