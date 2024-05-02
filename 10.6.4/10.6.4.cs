using System.Drawing;
using System;
using System.Reactive.Disposables;

public class Task1064

{
    public static void Main(string[] args)
    {
        using (var cancellation = new CancellationDisposable())
        {
            CancellationToken token = cancellation.Token;
            Task.Run(() =>
                {
                    try
                    {
                        for (int i = 0; ; i++)
                        {
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Cancelled");
                    }
                });
            Thread.Sleep(5000);
            // Маркер передается методам, которые на него реагируют.
        }
        // В этой точке маркер отменяется
    }


}