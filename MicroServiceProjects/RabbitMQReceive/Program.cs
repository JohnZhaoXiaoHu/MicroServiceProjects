
using RabbitMQCommon;

Console.WriteLine("Subscribe Begin");

var host = new HostMachineInfo
{
    UserName = "JohnZhao",
    Password = "JohnZhao",
    EndPointInfos = new List<EndPointInfo> 
    {
        new EndPointInfo
        {
             HostName = "127.0.0.1",
              Port = 5672
        }
    }
};

RabbitMQHelper.Subscribe(host);

Console.WriteLine("Subscribe Finish");

Console.ReadLine();
