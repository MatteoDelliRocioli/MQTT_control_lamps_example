namespace message_service
{
    using message_service.Models;
    using System;
    using uPLibrary.Networking.M2Mqtt;
    using uPLibrary.Networking.M2Mqtt.Messages;

    public class MQTTClient
    {
        // https://github.com/mohaqeq/paho.mqtt.m2mqtt
        MqttClient client;

        // https://docs.microsoft.com/en-us/dotnet/standard/events/
        public event EventHandler<LampEventArgs> ReceivedMessage;

        public void Connect(string brokerHostName, string topic)
        {
            // create client instance 
            client = new MqttClient(brokerHostName);

            // register to message received 
            client.MqttMsgPublishReceived += (sender, e) =>
            {
                // handle message received 
                try
                {
                    // https://stackoverflow.com/questions/9337255/serialize-deserialize-a-byte-array-in-json-net
                    var message = Utils.Deserialize<Lamp>(e.Message);
                    // fire the event, if there is a subscriber
                    ReceivedMessage?.Invoke(this, new LampEventArgs() { Lamp = message });
                }
                catch (Exception ex) // probably the deserialization failed
                {
                    Console.WriteLine($"Switch console error: {e.Message}");
                }
            };

            string clientId = Guid.NewGuid().ToString();
            var connResult = client.Connect(clientId);
            Console.WriteLine($"connection result: {connResult}");


            // subscribe to the topic  with QoS 2 
            var subResult = client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            Console.WriteLine($"subscription result: {subResult}");
        }

        public bool Publish(string topic, Lamp message)
        {
            // publish a message on "/home/temperature" topic with QoS 2 
            Console.WriteLine($"publis to: {topic}: {{{message.Name}, {message.Color}}}");
            client.Publish(topic, Utils.Serialize(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            return false;
        }

    }

    public class LampEventArgs : EventArgs// must implement EventArgs
    {
        public LampEventArgs()
        {
            TimeStamp = DateTime.Now;
        }
        // add your custom properties
        public DateTime TimeStamp { get; private set; }
        public Lamp Lamp { get; set; }
    }


}
