using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Single
{
    public class RegressionLayer : RegressionLayer<float>
    {
        public RegressionLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public RegressionLayer()
        {
        }
    }
}