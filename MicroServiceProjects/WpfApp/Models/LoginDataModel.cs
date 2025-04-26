using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class LoginDataModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsEnabled { get; set; }
    }
}
