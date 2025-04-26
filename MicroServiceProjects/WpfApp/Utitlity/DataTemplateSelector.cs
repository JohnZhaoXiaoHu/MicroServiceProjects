using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp.ViewModels.DTO;

namespace WpfApp.Utitlity
{
    public class StatusDataTemplateSelector: DataTemplateSelector
    {
        public DataTemplate WarnDataTemplate { get; set; }
        public DataTemplate NomalDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DeviceModelDTO? deviceModel = item as DeviceModelDTO;
            Random random = new Random();
            if (deviceModel?.Id > random.Next(50))
            {
                return WarnDataTemplate;
            }
            return NomalDataTemplate;
        }
    }
}
