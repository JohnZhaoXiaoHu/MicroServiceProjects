using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.ViewModels.DTO;

namespace WpfApp.ViewModels
{
    public class DeviceViewModel : ViewModel
    {
        public ObservableCollection<DeviceModelDTO> _DataList { get; set; } = new ObservableCollection<DeviceModelDTO>();

        public DeviceViewModel() 
        {
            for (int i = 0; i < 50; i++)
            {
                _DataList.Add(new DeviceModelDTO
                {
                    Id = i,
                    DeviceId = $"Device-Id: 00000{i}",
                    DeviceName = $"Device-Name: 00000{i}",
                    DeviceType = $"Device-Type: 00000-{i}",
                    DeviceDescription = $"Device-Desc: 00000{i}"
                });
            }
        } 
    }
}
