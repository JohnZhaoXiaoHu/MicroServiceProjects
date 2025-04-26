namespace DockerAppSetting
{
    public class ApiSetting
    {
        public string Ip { get; set; }

        public int Port { get; set; }

        public int Tags { get; set; }

        public int Index { get; set; }
    }

    public class ConsulSetting
    {
        public string Name { get; set; }

        public string Ip { get; set; }

        public int Port { get; set; }

        public int Interval { get; set; }

        public int Timeout { get; set; }

        public int DeregisterInterval { get; set; }
    }
}
