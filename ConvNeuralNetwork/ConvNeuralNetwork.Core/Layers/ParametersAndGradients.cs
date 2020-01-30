using System;
using ConvNeuralNetwork.Volume;

namespace ConvNeuralNetwork.Core.Layers
{
    public class ParametersAndGradients<T> where T : struct, IEquatable<T>, IFormattable
    {
        public Volume<T> Volume { get; set; }

        public Volume<T> Gradient { get; set; }
    }
}