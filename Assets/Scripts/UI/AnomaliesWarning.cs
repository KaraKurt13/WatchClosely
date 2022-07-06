using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomaliesWarning : MonoBehaviour
{
    [SerializeField] private GameObject warningObject;
    [SerializeField] private Text warningTextObject;
    [SerializeField] private string warningMessage;

    void Start()
    {
        AnomaliesManager.criticalAmountOfAnomalies += Warning;
    }
    
    private void Warning()
    {
        StartCoroutine(ShowWarningMessage());
    }

    private IEnumerator ShowWarningMessage()
    {
        warningObject.SetActive(true);

        for (int i = 0; i < warningMessage.Length; i++)
        {
            warningTextObject.text += warningMessage[i];
            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(5f);

        warningObject.SetActive(false);
    }

}
