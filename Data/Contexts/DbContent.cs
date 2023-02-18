using System;
using Core.Entities;
namespace Data.Contexts
{
	public class DbContent
	{
		static DbContent()
		{
			Groups = new List<Group>();

        }
		public static List<Group> Groups { get; set; }
	}
}

