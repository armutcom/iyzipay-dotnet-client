using System;
using System.Threading;
using System.Threading.Tasks;

namespace Armut.Iyzipay.Helper
{
    internal static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new
          TaskFactory(CancellationToken.None,
                      TaskCreationOptions.None,
                      TaskContinuationOptions.None,
                      TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return TaskFactory
              .StartNew<Task<TResult>>(func)
              .Unwrap<TResult>()
              .GetAwaiter()
              .GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            TaskFactory
              .StartNew<Task>(func)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }

        public static TResult RunSync<TResult>(this Task<TResult> task)
        {
            return TaskFactory
                .StartNew<Task<TResult>>(() => task)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSync(this Task func)
        {
            TaskFactory
              .StartNew<Task>(() => func)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }
    }
}