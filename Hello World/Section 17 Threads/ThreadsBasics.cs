using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSMasterClass
{
    class ThreadsBasics
    {
        static public void Main()
        {
            /*
            Console.WriteLine("Hello World! 1");
            Console.WriteLine("Hello World! 2");
            Console.WriteLine("Hello World! 3");
            Console.WriteLine("Hello World! 4");
            */
            /*
            new Thread(() => 
            {
                Thread.Sleep(2000);
                Console.WriteLine("Thread 1");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Thread 3");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            }).Start();
            */
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var thread = new Thread(()=>
            {
                Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5000);
                taskCompletionSource.TrySetResult(true);
            });
            //Console.WriteLine($"Thread number: {thread.ManagedThreadId}");
            thread.Start();
            var test = taskCompletionSource.Task.Result;
            Console.WriteLine("Task was done: " + test);

            return;
        }
    }
}
