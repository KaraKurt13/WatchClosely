using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportUI : MonoBehaviour
{
    [SerializeField] private GameObject reportUI;
    [SerializeField] private Button reportButtonUI;
    [SerializeField] private Button sendReportButton;
    [SerializeField] private GameObject wrongReportMessage;
    [SerializeField] private GameObject anomalyFixMessage;

    [SerializeField] private string reportAnomalyType;
    [SerializeField] private string reportRoomName;

    public delegate IEnumerator Report(string roomName,string anomalyType);
    public static event Report ReportSent;

    public void OpenReport()
    {
        reportUI.SetActive(true);
        reportButtonUI.onClick.RemoveAllListeners();
        reportButtonUI.onClick.AddListener(delegate { CloseReport(); });
    }

    public void CloseReport()
    {
        reportUI.SetActive(false);
        reportButtonUI.onClick.RemoveAllListeners();
        reportButtonUI.onClick.AddListener(delegate { OpenReport(); });
    }

    public void ChangeReportRoom(string roomName)
    {
        if(roomName==reportRoomName)
        {
            reportRoomName = null;
            return;
        }
        reportRoomName = roomName;
    }

    public void ChangeReportAnomaly(string anomalyType)
    {
        if(anomalyType==reportAnomalyType)
        {
            reportAnomalyType = null;
            return;
        }
        reportAnomalyType = anomalyType;
    }

    public void SendReport()
    {
        if(reportAnomalyType==null || reportRoomName==null)
        {
            return;
        }

        StartCoroutine(ReportSent(reportRoomName, reportAnomalyType));
        StartCoroutine(ReportDelay());
    }

    private IEnumerator ReportDelay()
    {
        CloseReport();
        reportButtonUI.gameObject.SetActive(false);

        yield return new WaitForSeconds(5);

        reportButtonUI.gameObject.SetActive(true);
    }
    private IEnumerator ShowWrongReportMessage()
    {
        wrongReportMessage.SetActive(true);
        yield return new WaitForSeconds(5);
        wrongReportMessage.SetActive(false);
    }

    private IEnumerator ShowAnomalyFixingMessage()
    {
        anomalyFixMessage.SetActive(true);
        yield return new WaitForSeconds(5);
        anomalyFixMessage.SetActive(false);
    }


    void Start()
    {
        ReportSystem.existingAnomalyReported += ShowAnomalyFixingMessage;
        ReportSystem.wrongReport += ShowWrongReportMessage;
        reportAnomalyType = null;
        reportRoomName = null;
    }

}
