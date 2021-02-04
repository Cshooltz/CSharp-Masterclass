using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSMasterClass
{
    /*
     * Async/Await:
     * This is a bit of a tricky topic to grasp, but is important.
     * They work in conjunction with threads, which is what truely allows for asynchronous programming to work.
     * In asynchronous programming, you are still delegating work to a thread that does something in the background.
     * However, you are intentionally pausing the execution of the function that calls it, using the await keyword on the
     * returned task object. 
     * 
     * What this does is actually pauses (or yield's, in threading parlance) the function that is running the background task.
     * The function that called the async function can either choose to pause its own execution somewhere using the await keyword,
     * or it can choose to not pause its own execution. In the latter case, the calling function continues as if the
     * async function completed, even while the async function is still doing something in a separate thread.
     * 
     * After the Task the async function was waiting on finishes, it can run additional code *IN THE CALLING THREAD*.
     * It is like the finally block of a try/catch statement. You execute the async code, then after it finishes
     * the function will stop the main thread and finish the function's remaining code, then resume the main thread
     * from wherever it left off. 
     * 
     * The fact that the code runs in the calling thread is important. You could use Thread.Join() or
     * Thread.IsAlive to do similar things, and accomplish the same thing using only threads, but it is more
     * complex because threads can't access data in other threads. So communication between threads needs to be
     * handled in a special way. 
     * 
     * Async/Await gets around that issue by offloading the threads into functions and then the functions call main thread
     * finally code after the threads finish. So instead of the thread messing with shared data outside of itself,
     * it tells the main thread when it is done so the main thread can make changes to its own data based on the outcome
     * of the thread. This pattern is very similar to how Javascript, especially Node.js, works. 
     */
    
    class ThreadPools
    {
        static public async Task Main()
        {
            Console.WriteLine("Entered ThreadPools");

            Task run = Task.Run(() =>
            {
                //int Counter = 0;
                Enumerable.Range(0, 200).ToList().ForEach(f =>
                {
                    new Thread(() =>
                    {
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                    }).Start();
                    //Console.WriteLine($"Work Item {Counter} Queued");
                    //Counter++;
                });
            });


            /*
            new Thread(() =>
            {
                int Counter = 0;
                Enumerable.Range(0, 1000).ToList().ForEach(f =>
                {
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                    });
                    //Console.WriteLine($"Work Item {Counter} Queued");
                    Counter++;
                });
            }){ IsBackground = true }.Start();
            */

            // With ThreadPool
            /*
            Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                    {
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                    });
            });
            */

            // Without ThreadPool
            // Creating all of the threads is sequential, all of the threads ending is parallel.
            /*
            Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                }).Start();
            });
            */
            await run;
            Console.WriteLine("End of ThreadPools"); // After all threads are created. Execution pauses at the await. 
            //Console.ReadKey();

            return;
        }
    }
}
