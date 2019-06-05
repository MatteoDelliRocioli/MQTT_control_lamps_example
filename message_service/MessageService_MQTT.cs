using message_service.Models;
using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace message_service
{
    class MessageService_MQTT : IMessageService <Lamp>
    {
        public MqttClient Client;

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
        }

        public void Connect()
        {
            // Create Client instance
            Client = new MqttClient("test.mosquitto.org");

            // Register to message received
            Client.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            Client.Connect(clientId);

           
        }
        // Subscribe to topic
        /*
        myClient.Subscribe(new String[] { "pncGroup/lampId/color" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE
});
            System.Console.ReadLine();
            */
        public void Send(Lamp message)
        {
            Client = new MqttClient("test.mosquitto.org");

            Client.MqttMsgPublished += client_MqttMsgPublished;

            ushort msgId = Client.Publish("pncGroup/lampId/color", // topic
               Encoding.UTF8.GetBytes("MyMessageBody"), // message body
               MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
               false); // retained
        }
    }
}

