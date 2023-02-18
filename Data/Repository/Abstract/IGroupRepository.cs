using System;
using Core.Entities;
namespace Data.Repository.Abstract
{
	public interface IGroupRepository
	{
		List<Group> GetAll();
		Group Get(int id);
		Group GetByName(string name);
		void Add(Group group);
		void Update(Group group);
		void Delete(Group group);
	}
}

