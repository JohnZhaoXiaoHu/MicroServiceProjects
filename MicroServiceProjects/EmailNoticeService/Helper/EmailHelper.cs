using System;
using System.Text;
using System.Net.Mail;
using Newtonsoft.Json;

namespace EmailNoticeService.Helper
{
    public class EmailHelper
    {
        public static void SendHealthEmail(EmailSettings settings, string content)
        {
            try
            {
                var mailMessage = new MailMessage(
                    settings.From,
                    settings.To,
                    settings.Subject,
                    content);

                dynamic list = JsonConvert.DeserializeObject(content);

      
                if (list != null && list.Count > 0)
                {
                    var emailBody = new StringBuilder("Health Check Failure Report:\r\n");
                    foreach (var noticy in list)
                    {
                        emailBody.AppendLine($"--------------------------------------");
                        emailBody.AppendLine($"        Node : {noticy.Node}");
                        emailBody.AppendLine($"  Service ID : {noticy.ServiceID}");
                        emailBody.AppendLine($"Service Name : {noticy.ServiceName}");
                        emailBody.AppendLine($"    Check ID : {noticy.CheckID}");
                        emailBody.AppendLine($"  Check Name : {noticy.Name}");
                        emailBody.AppendLine($"Check Status : {noticy.Status}");
                        emailBody.AppendLine($"Check Output : {noticy.Output}");
                        emailBody.AppendLine($"--------------------------------------");
                        Console.WriteLine(emailBody.ToString());
                    }      
                }
                else
                {
                    Console.WriteLine("Email Notice successful");
                }
                //using (var client = new SmtpClient("127.0.0.1"))
                //{
                //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    client.EnableSsl = true;
                //    client.Send(mailMessage);
                //    Console.WriteLine("Email Notice successful");
                //}

                #region MyRegion
                //dynamic list = JsonConvert.DeserializeObject(content);
                //if (list != null && list.Count > 0)
                //{
                //    var emailBody = new StringBuilder("健康检查故障:\r\n");
                //    foreach (var noticy in list)
                //    {
                //        emailBody.AppendLine($"--------------------------------------");
                //        emailBody.AppendLine($"Node:{noticy.Node}");
                //        emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                //        emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                //        emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                //        emailBody.AppendLine($"Check Name:{noticy.Name}");
                //        emailBody.AppendLine($"Check Status:{noticy.Status}");
                //        emailBody.AppendLine($"Check Output:{noticy.Output}");
                //        emailBody.AppendLine($"--------------------------------------");
                //    }

                //    var mailMessage = new MailMessage(
                //        settings.From,
                //        settings.To,
                //        settings.Subject,
                //        emailBody.ToString());

                //    using (var client = new SmtpClient())
                //    {
                //        client.SendMailAsync(mailMessage);
                //    }
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
