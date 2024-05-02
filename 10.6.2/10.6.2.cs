using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

public class Task1062

{
    public static async Task Main(string[] args)
    {
        CancellationToken cancellationToken = new CancellationToken();
        IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(1));
        long lastElement = await observable.TakeLast(1).ToTask(cancellationToken);
        // или: int lastElement = await observable.ToTask(cancellationToken)
    }

}