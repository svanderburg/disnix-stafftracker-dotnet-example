using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ZipcodeService
{
    
    [ServiceContract]
    public interface IZipcodeService
    {

        [OperationContract]
        Zipcode QueryZipcode(string zipcodeKey);

        [OperationContract]
        void InsertZipcode(Zipcode zipcode);

        [OperationContract]
        void UpdateZipcode(string zipcodeKey, Zipcode zipcode);

        [OperationContract]
        void DeleteZipcode(string zipcodeKey);
    }

    [DataContract]
    public class Zipcode
    {
        string zipcodeKey;

        string street;

        string city;

        [DataMember]
        public string ZipcodeKey
        {
            get { return zipcodeKey; }
            set { zipcodeKey = value; }
        }

        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
