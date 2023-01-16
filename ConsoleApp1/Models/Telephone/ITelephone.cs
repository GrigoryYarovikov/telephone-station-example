namespace ConsoleApp1.Models
{
    internal interface ITelephone: IBaseStationClient
    {
        // emulate user events hendler interface

        void OnIncomingCall();
        void OnSimInsert(SimCard simCard);
        void OnSimRemove();
        void OnAddContact(Contact contact);
        void OnDeleteContact(Contact contact);
        void OnCallWithNumber(string number);
        void OnCallWithContact(Contact contact);

        // other usefull methods and events
    }
}
