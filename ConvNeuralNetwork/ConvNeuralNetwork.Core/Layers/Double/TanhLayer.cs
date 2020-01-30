using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Double
{
    public class TanhLayer : TanhLayer<double>
    {
        public TanhLayer()
        {
        }

        public TanhLayer(Dictionary<string, object> data) : base(data)
        {
        }
    }
}