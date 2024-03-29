﻿using System.Collections.Generic;

namespace ConvNeuralNetwork.Core.Layers.Single
{
    public class LeakyReluLayer : LeakyReluLayer<float>
    {
        public LeakyReluLayer(float alpha) : base(alpha)
        {
        }

        public LeakyReluLayer(Dictionary<string, object> data) : base(data)
        {
        }
    }
}