using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace LabWork16
{
    class Program
    {
        static void First()
        {
            // принмает делегат
            Task task1 = new Task(findPrimeNumbers);
            task1.Start();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("\ttask id:{0}\ttask status:{1}", task1.Id, task1.Status);

            // ждём окончания задачи
            task1.Wait();
            Console.WriteLine("finished, stopwatch: {0}", stopwatch.Elapsed.Milliseconds);
        }
        static void Second()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            Task<int> task = new Task<int>(findLastPrimeNumber, cancellationToken.Token);
            task.Start();
            task.Wait();

            Console.WriteLine("\tfinished, CansselationToken: {0}", task.Result);

            //отмена задачи
            cancellationToken.Cancel();
        }
        static void Third()
        {
            Task<int[]> task1 = new Task<int[]>(() => TakeRange(1, 50));
            task1.Start(); task1.Wait();

            Task<int[]> task2 = new Task<int[]>(() => TakeEvenFromRange(task1.Result));
            task2.Start(); task2.Wait();

            Task<int> task3 = new Task<int>(() => TakeSumOfRange(task2.Result));
            task3.Start(); task3.Wait();

            Task<int> task4 = new Task<int>(() => LastPrime(task3.Result));
            task4.Start(); task4.Wait();

            Console.WriteLine(task4.Result);
        }
        static void Main(string[] args)
        {
            //First();

            //Second();

            //Third();

            //Task<int[]> task1 = Task<int[]>.Run(() => TakeRange(0, 50));        
            //Task<int> task2 = task1.ContinueWith<int>((t) => TakeSumOfRange(t.Result));
            //task2.Wait();
            //int res = task2.Result;

            Task<int> task3 = Task<int>.Run(() => Enumerable.Range(0, 100000).Count(n => n%2 == 0));
            var awaiter = task3.GetAwaiter();
            awaiter.OnCompleted(
                    () => Console.WriteLine(awaiter.GetResult())
                );
            task3.Wait();
        }

        // for Forst
        static void findPrimeNumbers()
        {
            for (int i = 1; i < 1000; i++)
            {
                bool res = true;
                for (int e = 2; e < i; e++)
                    if (i % e == 0)
                    {
                        res = false;
                        break;
                    }

                if(res)
                    Console.WriteLine("Finded prime: {0}", i);
            }
        }

        // for Second
        static int findLastPrimeNumber()
        {
            int lastPrime = 0;
            for (int i = 1; i < 1000; i++)
            {
                bool res = true;
                for (int e = 2; e < i; e++)
                    if (i % e == 0)
                    {
                        res = false;
                        break;
                    }

                if (res)
                    lastPrime = i;
            }
            return lastPrime;
        }

        static int[] TakeRange(int b, int e)
        {
            return Enumerable.Range(b, e).ToArray();
        }

        static int[] TakeEvenFromRange(int[] range)
        {          
            return range.Where(i => i % 2 == 0).Select(i => i).ToArray();
        }

        static int TakeSumOfRange(int[] range)
        {
            return range.Sum();
        }

        static int LastPrime(int sum)
        {
            int lastPrime = 0;
            for (int i = 1; i < sum; i++)
            {
                bool res = true;
                for (int e = 2; e < i; e++)
                    if (i % e == 0)
                    {
                        res = false;
                        break;
                    }

                if (res)
                    lastPrime = i;
            }
            return lastPrime;
        }
    }
}