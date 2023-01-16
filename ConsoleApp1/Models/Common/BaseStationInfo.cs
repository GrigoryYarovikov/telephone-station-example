namespace ConsoleApp1.Models
{
    internal class BaseStationInfo
    {
        private string _id;
        private SignalQuality _quality;

        public BaseStationInfo(BaseStationInfoDto station) 
        {
            _id = station.Id;
            _quality = station.SignalQuality;
        }

        public string Id { get { return _id; } }
        public SignalQuality SignalQuality { get { return _quality; } }

        public bool TryRegister(IBaseStationClient client)
        {
            // send message to BaseStation if it can register this client 
            client.GetConnectionInfo();
            return true;
        }

        public bool TryUnregister(IBaseStationClient client)
        {
            // send message to BaseStation to forget this client
            client.GetConnectionInfo();
            return true;
        }

        public bool TryMakeCall(IBaseStationClient client, string numberTo)
        {
            // send message to start call with base station
            client.GetConnectionInfo();
            return true;
        }
    }
}
