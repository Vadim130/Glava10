public class Task1011
{
    public static void Main(string[] args)
    {
        IssueCancelRequest();
    }
    static async Task CancellableMethodAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
            await Task.Delay(300, cancellationToken);
        }
    }
    static async void IssueCancelRequest()
    {
        using var cts = new CancellationTokenSource();
        var task = CancellableMethodAsync(cts.Token);
        // В этой точке операция была запущена.
        // Выдать запрос на отмену.
        Thread.Sleep(2000);
        cts.Cancel();
        await task;
    }

}