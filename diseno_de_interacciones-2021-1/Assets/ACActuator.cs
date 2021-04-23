using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System;

public class ACActuator : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
    public float temperatureUpperThreshold = 30f;
    public float temperatureLowerThreshold = 20f;
    private MqttClient client;
    string lastMessage;
    public GameObject acObject;
    volatile bool acState = false;

    void Start ()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
        client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
	}

    // Update is called once per frame
    void Update()
    {
        if (acState != acObject.activeSelf)
			acObject.SetActive(acState);
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		float temp;
        float.TryParse(lastMessage, out temp);
        if ( temp >= temperatureUpperThreshold)
        {
            // acObject.SetActive(true);
            acState = true;
        }
        else if (temp <= temperatureLowerThreshold)
        {
            // acObject.SetActive(false);
            acState = false;
        }
	}
}
