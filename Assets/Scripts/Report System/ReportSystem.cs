using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportSystem : MonoBehaviour
{
    [SerializeField] private AnomaliesManager anomaliesManager;

    public delegate IEnumerator AnomalyReport();
    public static event AnomalyReport existingAnomalyReported;
    public static event AnomalyReport wrongReport;

    private IEnumerator CheckReport(string roomName, string anomalyType)
    {
        yield return new WaitForSeconds(5);
        if (anomaliesManager.ReportedAnomalyExist(roomName, anomalyType))
        {
            StartCoroutine(existingAnomalyReported());
        }
        else
        {
            StartCoroutine(wrongReport());
        }

    }
    private void Start()
    {
        ReportUI.ReportSent += CheckReport;
    }

}
