public class Task1053

{
    public static void Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(300));
        try
        {
            foreach (int x in MultiplyBy2(Enumerable.Range(0,1000), cts.Token))
            {
                Console.WriteLine(x);
            }
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static IEnumerable<int> MultiplyBy2(IEnumerable<int> values,
     CancellationToken cancellationToken)
    {
        return values.AsParallel()
        .WithCancellation(cancellationToken)
        .Select(item => item * 2);
    }
}