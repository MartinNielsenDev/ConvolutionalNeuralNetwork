using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Single
{
    public class SoftmaxLayer : SoftmaxLayer<float>
    {
        public SoftmaxLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public SoftmaxLayer(int classCount) : base(classCount)
        {
        }
    }
}