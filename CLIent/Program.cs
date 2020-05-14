using System;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace CLIent
{
    class Program
    {
        static System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to START:");
            Console.ReadKey();

            MqttClient client = new MqttClient("localhost");

            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

            client.Subscribe(new string[] { "home/chat2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            client.Connect(Guid.NewGuid().ToString());

            string msg;
            while (true)
            {
                Console.WriteLine("Digite sua messagem:");

                msg = Console.ReadLine();
                watch.Restart();
                client.Publish("home/chat2", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

            }  
        }

        private static void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            watch.Stop();
            var msg = Encoding.UTF8.GetString(e.Message);
            Console.Clear();
            Console.WriteLine($"recebido:{msg}");
            Console.WriteLine($"Tempo:{watch.Elapsed}");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite sua messagem:");
        }
    }
}
