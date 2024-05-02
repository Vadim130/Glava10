public class Task1012
{
    public static async Task Main(string[] args)
    {
        await IssueCancelRequestAsync();
    }
    static async Task CancellableMethodAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
            await Task.Delay(300, cancellationToken);
        }
    }
    static async Task IssueCancelRequestAsync()
    {
        using var cts = new CancellationTokenSource();
        var task = CancellableMethodAsync(cts.Token);
        // В этой точке операция выполняется.
        // Выдать запрос на отмену.
        await Task.Delay(2000);
        cts.Cancel();
        // (Асинхронно) ожидать завершения операции.
        try
        {
            await task;
            // Если управление окажется в этой точке, значит, операция
            // была успешно завершена перед тем, как вступил в силу
            // запрос на отмену.
            Console.WriteLine("Operation completed successfully");
        }
        catch (OperationCanceledException)
        {
            // Если управление окажется в этой точке, значит, операция
            // была отменена до ее завершения.
            Console.WriteLine("Operation cancelled successfully");
        }
        catch (Exception)
        {
            // Если управление окажется в этой точке, значит, операция
            // завершилась с ошибкой перед тем как вступил в силу
            // запрос на отмену.
            Console.WriteLine("Operation failed before the cancellation event");
            throw;
        }
    }

}