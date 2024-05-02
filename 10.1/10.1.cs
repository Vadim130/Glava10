public class Task101
{
    public static void Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task t = new Task(() => CancelableMethodWithOverload(cts.Token));
        t.Start();
        Thread.Sleep(2000);
        cts.Cancel();
        try
        {
            t.Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Operation cancelled");
        }

    }
    public static void CancelableMethodWithOverload(CancellationToken
 cancellationToken)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(300);
            if (cancellationToken.IsCancellationRequested)
                cancellationToken.ThrowIfCancellationRequested();
        }
        // Здесь размещается код.
    }
    public static void CancelableMethodWithOverload()
    {
        CancelableMethodWithOverload(CancellationToken.None);
    }
    public static void CancelableMethodWithDefault(
     CancellationToken cancellationToken = default)
    {
        CancelableMethodWithOverload(cancellationToken);
        // Здесь размещается код.
    }
}