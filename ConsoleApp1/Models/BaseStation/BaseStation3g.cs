namespace ConsoleApp1.Models
{
    internal class BaseStation3g : BaseStation
    {
        public BaseStation3g(string id) : base(id)
        {
        }

        protected override void SendInfoToClient()
        {
            // fill dto and send to clients on handshake
            // 3g station fill dto with some specific data
            var info = new BaseStationInfoDto();
        }

        protected override bool CanAddClient(BaseStationClientDto client)
        {
            // check if client type supported and station has enough capacity to handle new client
            // now with 3g specifics 
            return true;
        }
    }
}
