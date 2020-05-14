using System;
using uPLibrary.Networking.M2Mqtt;

namespace MQTT
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttBroker broker = new MqttBroker();
            broker.Start();
            broker.ClientConnected += Broker_ClientConnected;
            Console.WriteLine("Hello World!");
            Console.ReadLine();

            broker.Stop();
        }

        private static void Broker_ClientConnected(MqttClient obj)
        {
            Console.WriteLine(obj.ClientId);            
        }
    }
}
