namespace ConsoleApp1.Models
{
    internal interface IBaseStation
    {
        void OnClientRegisterRequest(BaseStationClientDto client);
        void OnClientUnregisterRequest(BaseStationClientDto client);
        void OnOutcomeCall(BaseStationClientDto client, string numberTo);
        void Handshake();

        // other usefull methods and events
    }
}
