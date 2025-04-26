using DataModel;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorModel
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }

    public class ViewModel
    {
        public bool HasSuccess { get; set; }

        public List<User> Users { get; set; }

        public ErrorModel Error { get; set; }
    }
}
