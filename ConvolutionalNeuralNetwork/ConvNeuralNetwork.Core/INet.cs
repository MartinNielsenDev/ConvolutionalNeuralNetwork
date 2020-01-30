using System;
using System.Collections.Generic;
using ConvNeuralNetwork.Core.Layers;
using ConvNeuralNetwork.Volume;

namespace ConvNeuralNetwork.Core
{
    public interface INet<T> where T : struct, IEquatable<T>, IFormattable
    {
        T Backward(Volume<T> y);

        Volume<T> Forward(Volume<T> input, bool isTraining = false);

        T GetCostLoss(Volume<T> input, Volume<T> y);

        List<ParametersAndGradients<T>> GetParametersAndGradients();

        int[] GetPrediction();
    }
}