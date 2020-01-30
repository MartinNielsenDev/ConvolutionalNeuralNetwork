using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Single
{
    public class ReluLayer : ReluLayer<float>
    {
        public ReluLayer()
        {
            
        }

        public ReluLayer(Dictionary<string, object> data) : base(data)
        {
        }
    }
}