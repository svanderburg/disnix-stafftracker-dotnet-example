using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GeolocationService
{
    [ServiceContract]
    public interface IGeolocationService
    {
        [OperationContract]
        string GetCountry(string ipAddress);
    }
}
