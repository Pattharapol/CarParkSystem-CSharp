using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSystem.SourceCode
{
    public class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string Name, string Caption, string Description, string ProviderType, string Status)
        {
            this.DeviceID = deviceID;
            this.PNPDevideID = pnpDeviceID;
            this.Name = Name;
            this.Caption = Caption;
            this.Description = Description;
            this.ProviderType = ProviderType;
            this.Status = Status;
        }

        public string DeviceID { get; set; }

        public string PNPDevideID { get; set; }
        public string Name { get; set; }

        public string Caption { get; set; }
        public string Description { get; set; }
        public string ProviderType { get; set; }
        public string Status { get; set; }

    }
}
