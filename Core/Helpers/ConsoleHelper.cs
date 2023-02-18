using System;
namespace Core.Helpers
{
	public class ConsoleHelper
	{
		public static void WriteWithColour(string text, ConsoleColor color=ConsoleColor.White)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(text);
			Console.ResetColor();
		}
	}
}

