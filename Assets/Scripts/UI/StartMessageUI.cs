using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMessageUI : MonoBehaviour
{
    [SerializeField] private string messageText;
    [SerializeField] private Text textObject;
    [SerializeField] private GameObject messageUI;
    [SerializeField] private GameObject messageButton;

    public void OpenStartMessage()
    {
        messageUI.SetActive(true);
        messageButton.SetActive(false);
    }

    public void CloseStartMessage()
    {
        messageUI.SetActive(false);
    }

    void Start()
    {
        textObject.text = messageText;
    }

    
}
