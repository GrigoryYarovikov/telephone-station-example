using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    internal class BaseStation: IBaseStation
    {
        private string _id;
        private IDictionary<string, ClientInfo> _clients;

        public BaseStation(string id) 
        {
            _id = id;
            _clients = new Dictionary<string, ClientInfo>();
        }

        public void OnClientRegisterRequest(BaseStationClientDto client)
        {
            HandleNewClientRequest(client);
        }

        public void OnClientUnregisterRequest(BaseStationClientDto client)
        {
            HandleClientUnregister(client);
        }

        public void OnOutcomeCall(BaseStationClientDto client, string numberTo)
        {
            ProduseCall(client, numberTo);
        }

        public void Handshake()
        {
            // method to give clients information about station
            SendInfoToClient();
        }

        protected bool HandleNewClientRequest(BaseStationClientDto client)
        {
            if (CanAddClient(client))
            {
                var clientInfo = new ClientInfo(client);
                 _clients.Add(client.Imei, clientInfo);
                 return true;
            }
            return false;
        }
        
        protected bool HandleClientUnregister(BaseStationClientDto client)
        {
            // needs add checks and validate request
            return _clients.Remove(client.Imei);
        }

        protected virtual void SendInfoToClient()
        {
            // fill dto and send to clients on handshake
            var info = new BaseStationInfoDto();
        }

        protected virtual bool CanAddClient(BaseStationClientDto client)
        {
            // check if client type supported and station has enough capacity to handle new client
            return true;
        }

        protected void ProduseCall(BaseStationClientDto client, string number)
        {
            // connect logic
        }
    }
}
