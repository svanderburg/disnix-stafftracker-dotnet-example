using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StaffService
{
    [ServiceContract]
    public interface IStaffService
    {

        [OperationContract]
        Staff[] QueryAllStaff();

        [OperationContract]
        Staff QueryStaff(int id);

        [OperationContract]
        void InsertStaff(Staff staff);

        [OperationContract]
        void UpdateStaff(int id, Staff staff);

        [OperationContract]
        void DeleteStaff(int id);
    }

    [DataContract]
    public class Staff
    {
        int id;
        string name;
        string lastName;
        string room;
        string ipAddress;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataMember]
        public string Room
        {
            get { return room; }
            set { room = value; }
        }

        [DataMember]
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
    }
}
