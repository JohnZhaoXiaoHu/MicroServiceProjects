namespace RabbitMQCommon
{
    public class Message
    {
        public RabbitMQConfig RabbitMQConfig { get; set; }
    }

    public class RabbitMQConfig
    {
        public MQSetting MQSetting { get; set; }

        public HostMachineInfo HostMachineInfo { get; set; }
    }

    public class HostMachineInfo
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public List<EndPointInfo> EndPointInfos { get; set; }
    }

    public class EndPointInfo
    {
        public string HostName { get; set; }

        public int Port { get; set; }
    }

    public class MQSetting
    { 
        public string QueueName { get; set; } = "/";

        public string ExchangeName { get; set; } = "/";

        public string RoutingKey { get; set; } = string.Empty;

        public bool QPersistence { get; set; }

        public bool EPersistence { get; set; }

        public bool MPersistence { get; set; }
    }
}
