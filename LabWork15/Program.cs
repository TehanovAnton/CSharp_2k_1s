using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;

namespace Lab_15
{
    class Program
    {
        static Mutex mutexObj = new Mutex();
        static bool evenFirst = false;

        static void First()
        {
            Console.WriteLine("PROCESS");
            foreach (Process process in Process.GetProcesses())
            {
                Console.Write($"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority}");
                try
                {
                    Console.Write(
                        $" StartTime: {process.StartTime}  TotalProcessorTime: {process.TotalProcessorTime}\n"
                        );
                }
                catch
                {
                    Console.Write($" StartTime: No access");
                }
                Console.WriteLine();
            }
            Console.Write("--------------------------------------------------------------------------------------------------");
        }
        static void Second()
        {
            Console.WriteLine("\nDOMAIN");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine(
                $"Name: {domain.FriendlyName}\n" +
                $"Base Directory: {domain.BaseDirectory}\n" +
                $"Setup Information: {domain.SetupInformation.TargetFrameworkName}\n"
                );

            LoadAssembly(3);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Current Assemblies:");
            foreach (Assembly asm in domain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);
            Console.Write("--------------------------------------------------------------------------------------------------");
        }
        static void Third()
        {
            Thread counterThread = new Thread(new ParameterizedThreadStart(Count));
            counterThread.Name = "counterThread";
            counterThread.Start(12);
            Thread.Sleep(1800);
            Console.WriteLine($"Thread Name: {counterThread.Name}");
            Console.WriteLine($"IsAlive: {counterThread.IsAlive}");
            if (counterThread.IsAlive)
                Console.WriteLine($"Priority: {counterThread.Priority}");
            else
                Console.WriteLine($"thread is killed, Priority canot be accessed");
            Console.WriteLine($"ThreadState: {counterThread.ThreadState}");
        }
        static void Fourth()
        {
            Console.WriteLine("\nEVEN\\ODD THREADS");
            Thread evenThread = new Thread(new ParameterizedThreadStart(Even)); evenThread.Name = "evenThread";
            Thread oddThread = new Thread(new ParameterizedThreadStart(Odd)); oddThread.Name = "oddThread";
            int n = 16;
            evenThread.Priority = ThreadPriority.AboveNormal;
            evenThread.Start(n); Thread.Sleep(10); oddThread.Start(n);
            Thread.Sleep(3000);
        }
        static void Fifth()
        {
            Console.WriteLine("\nTIMER");
            Timer timer = new Timer(new TimerCallback(Count), 10, 0, 2000);
            Thread.Sleep(6000);
        }
        static void Main(string[] args)
        {
            //1
            //First();

            //2
            //Second();

            //3
            //Third();

            //4
            Fourth();

            //5
            Fifth();
        }
        public static bool IsPrime(int i)
        {
            bool prime = true;
            for(int e = 2; e < i; e++)
            {
                if (i % e == 0)
                {
                    prime = false;
                    break;
                }

            }

            return prime;
        }
        public static void Count(object n)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("count.txt", false, System.Text.Encoding.Default))
                {
                    for (int i = 2; i < (int)n; i++)
                    {
                        if (IsPrime(i))
                        {
                            sw.WriteLine(i);
                            Console.WriteLine(i);
                            Thread.Sleep(300);
                        }
                    }
                }
                Console.WriteLine("Writing done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Even(object n)
        {
            if (evenFirst)
                mutexObj.WaitOne();
            for (int i = 2; i <= (int)n; i += 2)
            {
                if (!evenFirst) mutexObj.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                Thread.Sleep(10);
                if (!evenFirst) mutexObj.ReleaseMutex();
            }
            if (evenFirst) mutexObj.ReleaseMutex();
        }
        public static void Odd(object n)
        {
            if (evenFirst) mutexObj.WaitOne();
            for (int i = 1; i <= (int)n; i += 2)
            {
                if (!evenFirst) mutexObj.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                Thread.Sleep(5);
                if (!evenFirst) mutexObj.ReleaseMutex();
            }
            if (evenFirst) mutexObj.ReleaseMutex();
        }

        public static void LoadAssembly(int number)
        {
            var context = new CustomAssemblyLoadContext();

            context.Unloading += Context_Unloading;

            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "LabWork15.dll");

            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);

            var type = assembly.GetType("LabWork15.Class1");

            var greetMethod = type.GetMethod("Factorial");

            //вызываем метод
            var instance = Activator.CreateInstance(type);
            int result = (int)greetMethod.Invoke(instance, new object[] { number });

            Console.WriteLine($"Factorial of {number} equals {result}\n");

            //какие сборки у нас загружены
            Console.WriteLine("Current Assemblies:");
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);

            // выгружаем контекст
            context.Unload();
        }
        // обработчик выгрузки контекста
        private static void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("\nLibriary Temp unloaded \n");
        }
    }
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }
}

