using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Single
{
    public class PoolLayer : PoolLayer<float>
    {
        public PoolLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public PoolLayer(int width, int height) : base(width, height)
        {
        }
    }
}