using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Double
{
    public class RegressionLayer : RegressionLayer<double>
    {
        public RegressionLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public RegressionLayer()
        {
        }
    }
}