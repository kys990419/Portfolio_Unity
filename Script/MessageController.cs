using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public GameObject UI;
    public Text messageText;
    private void Start()
    {
        messageText = GetComponent<Text>();
    }

    public void UpdateMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = "" + message;
            Debug.Log(message);
            //UI.gameObject.SetActive(true);
        }

        else
            Debug.LogError("Message Text is not assigned in the Inspector!");
    }
}
