using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RoomService
{
    [ServiceContract]
    public interface IRoomService
    {

        [OperationContract]
        string[] QueryAllRoomIdentifiers();

        [OperationContract]
        Room QueryRoom(string roomKey);

        [OperationContract]
        void InsertRoom(Room room);

        [OperationContract]
        void UpdateRoom(Room room, String roomKey);

        [OperationContract]
        void DeleteRoom(String roomKey);
    }

    [DataContract]
    public class Room
    {
        string room;

        string zipcode;

        [DataMember]
        public string RoomKey
        {
            get { return room; }
            set { room = value; }
        }

        [DataMember]
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
    }
}
