public class Task1031

{
    public static async Task Main(string[] args)
    {
        DateTime t1 =DateTime.Now;
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
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        CancellationToken token = cts.Token;
        await Task.Delay(TimeSpan.FromSeconds(10), token);
    }

}