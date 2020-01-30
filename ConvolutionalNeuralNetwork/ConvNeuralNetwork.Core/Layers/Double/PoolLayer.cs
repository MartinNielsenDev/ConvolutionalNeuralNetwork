using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Double
{
    public class PoolLayer : PoolLayer<double>
    {
        public PoolLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public PoolLayer(int width, int height) : base(width, height)
        {
        }
    }
}