using System.ServiceModel;

namespace NamedPipesSharp
{
    [ServiceContract]
    public interface IDataProcessor
    {
        [OperationContract]
        int Process();
    }
}