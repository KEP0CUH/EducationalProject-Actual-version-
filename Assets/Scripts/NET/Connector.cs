using UnityEngine;
using UnityEngine.UI;

public class Connector : MonoBehaviour
{
    [SerializeField] private Text inputText;
    [SerializeField] private Button sendButton;
    private Client client;
    private void Start()
    {
        client = new Client(27777);

        

        this.sendButton.onClick.AddListener(SendMessage);
    }

    private void SendMessage()
    {
        client.Connect();
        if (client != null)
        {
            string message = inputText.text;
            client.SendResponse(message);
        }
    }
}
