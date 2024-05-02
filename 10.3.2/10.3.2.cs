public class Task1032

{
    public static async Task Main(string[] args)
    {
        DateTime t1 = DateTime.Now;
        try
        {
            await IssueTimeoutAsync();
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected exception:{0}", ex.Message);
            throw;
        }
        Console.WriteLine("Elapsed: {0}", DateTime.Now.Subtract(t1).TotalMilliseconds);
    }
    static async Task IssueTimeoutAsync()
    {
        using var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        cts.CancelAfter(TimeSpan.FromSeconds(5));
        await Task.Delay(TimeSpan.FromSeconds(10), token);
    }

}