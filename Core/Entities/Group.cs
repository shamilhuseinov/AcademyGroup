﻿using System;
namespace Core.Entities
{
	public class Group:BaseEntity
	{
		public string Name { get; set; }

        public int MaxSize { get; set; }

        public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}
}

