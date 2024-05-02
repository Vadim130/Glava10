public class Task104

{
    public static async Task Main(string[] args)
    {
        
        for (int i = 1; i <= 3; i += 2)
        {
            DateTime t1 = DateTime.Now;
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(i));
            try
            {
                int res = await CancelableMethodAsync(cts.Token);
                Console.WriteLine("Result = {0}", res);
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
    }
    public static async Task<int> CancelableMethodAsync(CancellationToken
     cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        return 42;
    }

}