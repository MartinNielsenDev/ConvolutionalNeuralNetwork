namespace ConvNeuralNetwork.Core.Training.Double
{
    public class SgdTrainer : SgdTrainer<double>
    {
        public SgdTrainer(INet<double> net) : base(net)
        {
        }
    }
}