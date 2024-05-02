using System.Drawing;
using System;

public class Task1061

{
    public static void Main(string[] args)
    {

    }
    private IDisposable _mouseMovesSubscription;
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        IObservable<Point> mouseMoves = Observable
        .FromEventPattern<MouseEventHandler, MouseEventArgs>(
        handler => (s, a) => handler(s, a),
        handler => MouseMove += handler,
        handler => MouseMove -= handler)
        .Select(x => x.EventArgs.GetPosition(this));
        _mouseMovesSubscription = mouseMoves.Subscribe(value =>
        {
            MousePositionLabel.Content = "(" + value.X + ", " + value.Y + ")";
        });
    }
    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (_mouseMovesSubscription != null)

     _mouseMovesSubscription.Dispose();
    }
}