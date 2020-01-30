using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Double
{
    public class SigmoidLayer : SigmoidLayer<double>
    {
        public SigmoidLayer(Dictionary<string, object> data) : base(data)
        {
        }

        public SigmoidLayer()
        {
        }
    }
}