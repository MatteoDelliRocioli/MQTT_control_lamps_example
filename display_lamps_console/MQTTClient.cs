using message_service.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace display_lamps_console
{
    public class MQTTClient
    {
        public void Connect(string brokerHostName, string topic)
        {
            // create client instance 
            uPLibrary.Networking.M2Mqtt.MqttClient client = new uPLibrary.Networking.M2Mqtt.MqttClient(brokerHostName);

            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic  with QoS 2 
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = e.Message as Lamp;
            // handle message received 
        }
    }
}
