using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    internal class Telephone3g : Telephone
    {
        public Telephone3g(string imei) : base(imei)
        {
        }

        protected override BaseStationInfo GetBestSignalStation(IList<BaseStationInfo> baseStations)
        {
            // emulate some intellectual search of 3g net
            return baseStations.FirstOrDefault();
        }
    }
}
