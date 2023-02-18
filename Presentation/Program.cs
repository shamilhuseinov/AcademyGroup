using System;
using Core.Helpers;
using Core.Constants;
using Presentation.Services;
using Data.Repository.Concrete;

namespace Presentation
{
    public static class Program
    {
        private readonly static GroupService _groupservice;
        static Program()
        {
            _groupservice = new GroupService();
        }

        static void Main()
        {


            ConsoleHelper.WriteWithColour("---Welcome---", ConsoleColor.Cyan);

            while (true)
                {
                    ConsoleHelper.WriteWithColour("1-Create Group", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("2-Update Group", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("3-Delete Group", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("4-Get All Groups", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("5-Get Group By Id", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("6-Get Group By Name", ConsoleColor.Yellow);

                    ConsoleHelper.WriteWithColour("0-Exit", ConsoleColor.Yellow);

                OptionDescription: ConsoleHelper.WriteWithColour("---Select Option---", ConsoleColor.Cyan);
                    int optionNumber;
                    bool issucceed = int.TryParse(Console.ReadLine(), out optionNumber);
                    if (!issucceed)
                    {
                        ConsoleHelper.WriteWithColour("Invalid input", ConsoleColor.Red);
                        goto OptionDescription;
                    }
                    if (optionNumber < 0 || optionNumber > 6)
                    {
                        ConsoleHelper.WriteWithColour("There is not any option in this input", ConsoleColor.Red);
                        goto OptionDescription;
                    }
                    else
                    {
                        switch (optionNumber)
                        {
                            case (int)GroupOptions.CreateGroup:
                            _groupservice.CreateGroup();
                                break;
                            case (int)GroupOptions.UpdateGroup:
                            _groupservice.UpdateGroup();
                                break;
                            case (int)GroupOptions.DeleteGroup:
                            _groupservice.DeleteGroup();
                                break;
                            case (int)GroupOptions.GetAllgroups:
                            _groupservice.GetAllGroups();
                                break;
                            case (int)GroupOptions.GetGroupById:
                            _groupservice.GetGroupById();
                                break;
                            case (int)GroupOptions.GetGroupByame:
                            _groupservice.GetGroupByName();
                                break;
                            case (int)GroupOptions.Exit:
                                if (_groupservice.Exit()==true)
                                {
                                    return;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
        }
    }
}
