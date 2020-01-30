using System;
using ConvNeuralNetwork.Volume;

namespace ConvNeuralNetwork.Core.Layers
{
    public interface ILastLayer<T> where T : struct, IEquatable<T>, IFormattable
    {
        void Backward(Volume<T> y, out T loss);
    }
}