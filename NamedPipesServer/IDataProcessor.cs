using System.ServiceModel;

namespace NamedPipesSharp
{
    [ServiceContract]
    public interface IDataProcessor
    {
        [OperationContract]
        DataMessage Process(DataMessage message);
    }
}