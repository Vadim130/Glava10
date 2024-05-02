public class Task1022
{
    public static void Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task task = Task.Run(() => { CancelableMethod(cts.Token); });
        DateTime t1 = DateTime.Now;
        Thread.Sleep(10000);
        Console.WriteLine("#1");
        Thread.Sleep(10000);
        Console.WriteLine("#2");
        cts.Cancel();
        Console.WriteLine("Elapsed:{0}", DateTime.Now.Subtract(t1));
    }
    public static int CancelableMethod(CancellationToken cancellationToken)
    {
        for (int i = 0; i != 100000; ++i)
        {
            Thread.Sleep(1); // Некоторые вычисления.
            if (i % 100 == 0)
                Console.WriteLine(i);
            if (i % 1000 == 0)
                cancellationToken.ThrowIfCancellationRequested();
        }
        return 42;
    }

}