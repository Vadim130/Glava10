using System.Drawing;
using System;
using System.Threading.Tasks.Dataflow;
using System.Net.NetworkInformation;

public class Task108

{
    async Task<PingReply> PingAsync(string hostNameOrAddress,
     CancellationToken cancellationToken)
    {
        using var ping = new Ping();
        Task<PingReply> task = ping.SendPingAsync(hostNameOrAddress);
        using CancellationTokenRegistration _ = cancellationToken
        .Register(() => ping.SendAsyncCancel());
        return await task;
    }


}