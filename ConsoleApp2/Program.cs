using System;
using System.Threading;


//use Release mod with optimization
namespace ConsoleApp2
{
	class Program
	{
		//static volatile bool stopValue;  // disable jit for stopValue
		static  bool stopValue;

		static void Change(ref bool x)
		{
			 x = true;
		}

		static void DoSomething()
		{
			int counter = 0;
			while(!stopValue)
			{
				counter++;
			}
			Console.WriteLine("Метод DoSomething завершен на {0} итерации", counter);
		}
		static void Main(string[] args)
		{

			Thread thread1 = new Thread(DoSomething);

			thread1.Start();

			Thread.Sleep(1500);

			stopValue = true;
			Console.WriteLine("{0} = {1}", nameof(stopValue), stopValue) ;

			Console.WriteLine("Метод Main ожидает завершение {0}",nameof(thread1));
			thread1.Join();
		}
	}
}
