using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    internal class Telephone: ITelephone
    {
        private readonly string _imei;
        private readonly IList<Contact> _contacts;
        private SimCard _sim;
        private BaseStationInfo _baseStation;

        public Telephone(string imei)
        {
            _imei = imei;
            _contacts = new List<Contact>();
            _sim = null;
            _baseStation = null;
        }

        public void OnIncomingCall()
        {
            // handle incoming call
        }

        public void OnSimInsert(SimCard simCard)
        {
            InsertSim(simCard);
        }

        public void OnSimRemove()
        {
            RemoveSim();
        }

        public void OnAddContact(Contact contact)
        {
            AddContact(contact);
        }
        public void OnDeleteContact(Contact contact)
        {
            DeleteContact(contact);
        }
        public void OnCallWithNumber(string number)
        {
            MakeCall(number);
        }
        public void OnCallWithContact(Contact contact)
        {
            MakeContactCall(contact);
        }

        public BaseStationClientDto GetConnectionInfo()
        {
            // fill and return dto object
            return new BaseStationClientDto();
        }

        protected void InsertSim(SimCard sim)
        {
            _sim = sim;
        }

        protected void RemoveSim()
        {
            _sim = null;
        }

        protected SimCard GetSim()
        {
            return _sim;
        }

        protected string GetImei()
        {
            return _imei;
        }

        protected void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        protected void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        protected IList<Contact> GetContacts()
        {
            return _contacts;
        }

        protected void RegisterOnNearestBaseStation(IList<BaseStationInfo> baseStations)
        {
            // try to find a base station with better signal
            var bestSignalStation = GetBestSignalStation(baseStations);
            if (bestSignalStation != null)
            {
                if (_baseStation.Id == bestSignalStation.Id)
                {
                    _baseStation = bestSignalStation;
                }
                else
                {
                    _baseStation.TryUnregister(this); // error handling is out of this demo
                    _baseStation = bestSignalStation;
                    _baseStation.TryRegister(this);
                }
            }
        }

        protected void MakeContactCall(Contact contact)
        {
            MakeCall(contact.Number);
        }

        protected void MakeCall(string number)
        {
            // call to base station
            _baseStation.TryMakeCall(this, number);
        }

        protected virtual BaseStationInfo GetBestSignalStation(IList<BaseStationInfo> baseStations)
        {
            // emulate some intellectual search
            return baseStations.FirstOrDefault();
        }
    }
}
