using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.ViewModels.DTO
{
    public class DeviceModelDTO: ViewModel
    {
        private DeviceDataModel _DeviceDataModel = new DeviceDataModel();

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set 
            { 
                _Id = value;
                OnProertyChanged(nameof(Id));
            }
        }

        public string DeviceId
        {
            get { return _DeviceDataModel.DeviceId; }
            set
            {
                _DeviceDataModel.DeviceId = value;
                OnProertyChanged(nameof(DeviceId));
            }
        }

        public string DeviceName
        {
            get { return _DeviceDataModel.DeviceName; }
            set
            {
                _DeviceDataModel.DeviceName = value;
                OnProertyChanged(nameof(DeviceName));
            }
        }

        public string DeviceType
        {
            get { return _DeviceDataModel.DeviceType; }
            set
            {
                _DeviceDataModel.DeviceType = value;
                OnProertyChanged(nameof(DeviceName));
            }
        }

        public string DeviceDescription
        {
            get { return _DeviceDataModel.DeviceDescription; }
            set
            {
                _DeviceDataModel.DeviceDescription = value;
                OnProertyChanged(nameof(DeviceDescription));
            }
        }
    }
}
