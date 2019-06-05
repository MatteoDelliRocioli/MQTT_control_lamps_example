using message_service.Models;
using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace message_service
{
    class MessageService_MQTT : IMessageService <Lamp>
    {
        static void Main(string[] args)
        {
            // Create Client instance
            MqttClient myClient = new MqttClient("test.mosquitto.org");

            // Register to message received
            myClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);

            // Subscribe to topic
            myClient.Subscribe(new String[] { "pncGroup/lampId/color" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            System.Console.ReadLine();
        }


        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
        }

        public void Connect()
        {
            
        }

        public void Send(Lamp message)
        {
            
        }
    }
}
}
