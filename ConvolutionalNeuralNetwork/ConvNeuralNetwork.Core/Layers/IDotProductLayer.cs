using System;

namespace ConvNeuralNetwork.Core.Layers
{
    public interface IDotProductLayer<T> where T : struct, IEquatable<T>, IFormattable
    {
        T BiasPref { get; set; }
    }
}