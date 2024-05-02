using System.Drawing;
using System;

public class Task1063

{
    public static void Main(string[] args)
    {

    }
    CancellationToken cancellationToken = ...
IObservable<int> observable = ...
int firstElement = await
 observable.Take(1).ToTask(cancellationToken);
}