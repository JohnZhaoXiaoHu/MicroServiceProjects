using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class DeviceDataModel
    {
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }
        
        public string DeviceType { get; set; }

        public string DeviceDescription { get; set; }

        public string DeviceManufacturer { get; set; }

        public string DeviceSerial { get; set; }

        public string DeviceFirmwareVersion { get; set; }

        public string DeviceManufacturerFirmwareVersion { get; private set; }
    }
}
