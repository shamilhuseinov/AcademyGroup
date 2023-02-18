using System;
using Core.Entities;
using Core.Helpers;
using Data.Repository.Concrete;
using Data.Contexts;
using System.Globalization;

namespace Presentation.Services
{
	public class GroupService
	{
        private readonly GroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public void CreateGroup()
        {
            ConsoleHelper.WriteWithColour("Yaratmaq istediyiniz qrupun adini daxil edin", ConsoleColor.Cyan);

            string name = Console.ReadLine();
            int maxSize;
        MaxSizeDescription: ConsoleHelper.WriteWithColour("Yaratmaq istediyiniz qrupun max size'sini daxil edin", ConsoleColor.Cyan);
            bool issucceed = int.TryParse(Console.ReadLine(), out maxSize);
            if (!issucceed)
            {
                ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                goto MaxSizeDescription;
            }
            if (maxSize > 18)
            {
                ConsoleHelper.WriteWithColour("Max size should be equal or less than 18", ConsoleColor.Red);
                goto MaxSizeDescription;
            }

            DateTime StartDate;
        StartDateDescription: ConsoleHelper.WriteWithColour("Yaratmaq istediyiniz qrupun Start date'sini daxil edin", ConsoleColor.Cyan);
            issucceed = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out StartDate);
            if (!issucceed)
            {
                ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                goto StartDateDescription;
            }

            DateTime EndDate;
        EndDateDescription: ConsoleHelper.WriteWithColour("Yaratmaq istediyiniz qrupun End date'sini daxil edin", ConsoleColor.Cyan);
            issucceed = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out EndDate);
            if (!issucceed)
            {
                ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                goto EndDateDescription;
            }
            if (EndDate < StartDate)
            {
                ConsoleHelper.WriteWithColour("End date must be later than start date", ConsoleColor.Red);
                goto EndDateDescription;
            }

            var group = new Group
            {
                Name = name,
                MaxSize = maxSize,
                StartDate = StartDate,
                EndDate = EndDate
            };
            _groupRepository.Add(group);
            ConsoleHelper.WriteWithColour($"Group is successfully created with\nName: {group.Name}\nmaxSize: {group.MaxSize}\nStartDate: {group.StartDate}\nEndDate: {group.EndDate}", ConsoleColor.Green);



        }

        public void GetAllGroups()
		{
            var groups = _groupRepository.GetAll();
            if (groups.Count == 0)
            {
                ConsoleHelper.WriteWithColour("There is no group to get", ConsoleColor.Red);

            }
            else
            {
                ConsoleHelper.WriteWithColour("---All groups---", ConsoleColor.Cyan);
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteWithColour($"Id: {group.Id}\nName: {group.Name}\nMax size: {group.MaxSize}\nStart date: {group.StartDate}\nEnd Date: {group.EndDate}", ConsoleColor.Cyan);
                }
            }
        }

        public void GetGroupById()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count == 0)
            {
                ConsoleHelper.WriteWithColour("There is not any groups", ConsoleColor.Red);
            CreatingGroupDescription: ConsoleHelper.WriteWithColour("Do you want to create a group? --y or n--", ConsoleColor.Cyan);
                char option;
                bool isSucceed = char.TryParse(Console.ReadLine(), out option);
                if (!isSucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto CreatingGroupDescription;
                }
                if (!(option == 'y' || option == 'n'))
                {
                    ConsoleHelper.WriteWithColour("Input is not correct", ConsoleColor.Red);
                    goto CreatingGroupDescription;
                }
                if (option=='y')
                {
                    CreateGroup();
                }
            }
            else
            {
                ConsoleHelper.WriteWithColour("All groups", ConsoleColor.Cyan);
                GetAllGroups();
                GroupIdDescription:  ConsoleHelper.WriteWithColour("Id ni daxil edin", ConsoleColor.Cyan);
                int id;
                bool issucceed = int.TryParse(Console.ReadLine(), out id);

                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                    goto GroupIdDescription;
                }

                var group = _groupRepository.Get(id);
                if (group is null)
                {
                    ConsoleHelper.WriteWithColour("There is not any group in this id", ConsoleColor.Red);
                    goto GroupIdDescription;
                }

                ConsoleHelper.WriteWithColour($"Id: {group.Id}\nName: {group.Name}\nMax size: {group.MaxSize}\nStart date: {group.StartDate}\nEnd Date: {group.EndDate}", ConsoleColor.Cyan);
            }
        }

        public void GetGroupByName()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count == 0)
            {
                ConsoleHelper.WriteWithColour("There is no groups", ConsoleColor.Red);

            }
            EnterNameDescription: ConsoleHelper.WriteWithColour("Qrupun adini daxil edin", ConsoleColor.Cyan);


            string name = Console.ReadLine();
            var group = _groupRepository.GetByName(name);
            if (group is null)
            {
                ConsoleHelper.WriteWithColour("There is not any group in this name", ConsoleColor.Red);
                goto EnterNameDescription;
            }
            ConsoleHelper.WriteWithColour($"Id: {group.Id}\nName: {group.Name}\nMax size: {group.MaxSize}\nStart date: {group.StartDate}\nEnd Date: {group.EndDate}", ConsoleColor.Cyan);


        }

        public void UpdateGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count == 0)
            {
                ConsoleHelper.WriteWithColour("There is not any groups", ConsoleColor.Red);
            CreatingGroupDescription: ConsoleHelper.WriteWithColour("Do you want to create a group? --y or n--", ConsoleColor.Cyan);
                char option;
                bool isSucceed = char.TryParse(Console.ReadLine(), out option);
                if (!isSucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto CreatingGroupDescription;
                }
                if (!(option == 'y' || option == 'n'))
                {
                    ConsoleHelper.WriteWithColour("Input is not correct", ConsoleColor.Red);
                    goto CreatingGroupDescription;
                }
                if (option == 'y')
                {
                    CreateGroup();
                }
            }
            else
            {
                ConsoleHelper.WriteWithColour("All groups", ConsoleColor.Cyan);
                GetAllGroups();
                int id;
                IdDescription: ConsoleHelper.WriteWithColour("Enter Id of the group that you want to update", ConsoleColor.Cyan);

                bool issucceed = int.TryParse(Console.ReadLine(), out id);
                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto IdDescription;
                }
                var group = _groupRepository.Get(id);
                if (group is null)
                {
                    ConsoleHelper.WriteWithColour("There is not any groups in this id", ConsoleColor.Red);
                    goto IdDescription;
                }

                ConsoleHelper.WriteWithColour("Enter new name", ConsoleColor.Cyan);
                string name = Console.ReadLine();
                MaxSizeDescription: ConsoleHelper.WriteWithColour("Enter new max size", ConsoleColor.Cyan);
                int maxSize;
                issucceed = int.TryParse(Console.ReadLine(), out maxSize);
                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto MaxSizeDescription;
                }
                if (maxSize>18)
                {
                    ConsoleHelper.WriteWithColour("MaxSize should be equal or less than 18", ConsoleColor.Red);
                    goto MaxSizeDescription;
                }

            StartTimeDescription: ConsoleHelper.WriteWithColour("Enter new start date", ConsoleColor.Cyan);
                DateTime startDate;
                issucceed = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto StartTimeDescription;
                }

            EndTimeDescription: ConsoleHelper.WriteWithColour("Enter new end date", ConsoleColor.Cyan);
                DateTime endDate;
                issucceed = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("Input is not in a correct format", ConsoleColor.Red);
                    goto EndTimeDescription;
                }

                if (startDate>endDate)
                {
                    ConsoleHelper.WriteWithColour("End date must br later than start date", ConsoleColor.Red);
                    goto EndTimeDescription;
                }

                group.Name = name;
                group.MaxSize = maxSize;
                group.StartDate = startDate;
                group.EndDate = endDate;
                _groupRepository.Update(group);

                ConsoleHelper.WriteWithColour($"New group:\nName: {group.Name}\nmaxSize: {group.MaxSize}\nStartDate: {group.StartDate}\nEndDate: {group.EndDate}", ConsoleColor.Green);

            }
        }

        public void DeleteGroup()
            {
                var groups = _groupRepository.GetAll();
                if (groups.Count == 0)
                {
                    ConsoleHelper.WriteWithColour("There is no group to delete", ConsoleColor.Red);

                }

                else
                {
                    ConsoleHelper.WriteWithColour("All groups", ConsoleColor.Cyan);
                    GetAllGroups();
            DeleteGroupDescription: ConsoleHelper.WriteWithColour("Silmek istediyiniz qrupun id si ni daxil edin", ConsoleColor.Cyan);

                    int id;
                    bool issucceed = int.TryParse(Console.ReadLine(), out id);
                    if (!issucceed)
                    {
                        ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                        goto DeleteGroupDescription;
                    }
                    var group = _groupRepository.Get(id);
                    if (group is null)
                    {
                        ConsoleHelper.WriteWithColour("There is no group in this id", ConsoleColor.Red);
                        goto DeleteGroupDescription;
                    }

                    _groupRepository.Delete(group);
                    ConsoleHelper.WriteWithColour("Group is successfully deleteed", ConsoleColor.Green);
                }

            }

        public bool Exit()
            {
            AreYouSureDescription: ConsoleHelper.WriteWithColour("Are you sure? --y or n--", ConsoleColor.DarkRed);
                char decision;
                bool issucceed = char.TryParse(Console.ReadLine(), out decision);
                if (!issucceed)
                {
                    ConsoleHelper.WriteWithColour("input is not in a correct format", ConsoleColor.Red);
                    goto AreYouSureDescription;
                }
                if (!(decision == 'y' || decision == 'n'))
                {
                    ConsoleHelper.WriteWithColour("Your choice is not correct", ConsoleColor.Red);
                    goto AreYouSureDescription;
                }
                if (decision == 'y')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}
