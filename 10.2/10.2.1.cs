public class Task1021
{
    public static void Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task t = Task.Run(() => CancellableMethod(cts.Token));
        Thread.Sleep(3000);
       
        try
        {
            cts.Cancel();
            t.Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Operation Cancelled:\n Details:{0}",ex.ToString());
        }


    }
    public static int CancellableMethod(CancellationToken cancellationToken)
    {
        for (int i = 0; i != 100; ++i)
        {
            Thread.Sleep(1000); // Некоторые вычисления.
            Console.WriteLine(i);
            cancellationToken.ThrowIfCancellationRequested();
        }
        return 42;
    }

}