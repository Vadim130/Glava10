using System.Drawing;
using System;
using System.Threading.Tasks.Dataflow;

public class Task108

{
    public static void Main(string[] args)
    {
        async Task<HttpResponseMessage> GetWithTimeoutAsync(HttpClient client,
 string url, CancellationToken cancellationToken)
        {
            using CancellationTokenSource cts = CancellationTokenSource
            .CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(TimeSpan.FromSeconds(2));
 CancellationToken combinedToken = cts.Token;
            return await client.GetAsync(url, combinedToken);
        }
    }

}