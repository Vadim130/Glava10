using System.Drawing;
using System;
using System.Threading.Tasks.Dataflow;

public class Task107

{
    public static void Main(string[] args)
    {
        IPropagatorBlock<int, int> CreateMyCustomBlock(
    CancellationToken cancellationToken)
        {
            var blockOptions = new ExecutionDataflowBlockOptions
            {
                CancellationToken = cancellationToken
            };
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2,
            blockOptions);
            var addBlock = new TransformBlock<int, int>(item => item + 2,
            blockOptions);
            var divideBlock = new TransformBlock<int, int>(item => item / 2,
            blockOptions);
            var flowCompletion = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };
            multiplyBlock.LinkTo(addBlock, flowCompletion);
            addBlock.LinkTo(divideBlock, flowCompletion);
            return DataflowBlock.Encapsulate(multiplyBlock, divideBlock);
        }
    }

}