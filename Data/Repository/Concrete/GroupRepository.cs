using System;
using Core.Entities;
using Data.Repository.Abstract;
using Data.Contexts;

namespace Data.Repository.Concrete
{
	public class GroupRepository:IGroupRepository
	{
        static int id;
        public List<Group> GetAll()
        {
            return DbContent.Groups;
        }

        public Group Get(int id)
        {
            return DbContent.Groups.FirstOrDefault(g => g.Id == id);
        }

        public Group GetByName(string name)
        {
            return DbContent.Groups.FirstOrDefault(g => g.Name == name);
        }

        public void Add(Group group)
        {
            id++;
            group.Id = id;
            group.CreatedAt = DateTime.Now;
            DbContent.Groups.Add(group);
        }

        public void Update(Group group)
        {
            var dbgroup = DbContent.Groups.FirstOrDefault(g=>g.Id==group.Id);
            if (dbgroup is not null)
            {
                dbgroup.Name = group.Name;
                dbgroup.StartDate = group.StartDate;
                dbgroup.EndDate = group.EndDate;
                dbgroup.MaxSize = group.MaxSize;
                dbgroup.ModifiedAt = DateTime.Now;
            }
        }

        public void Delete(Group group)
        {
            DbContent.Groups.Remove(group);
        }
    }
}

