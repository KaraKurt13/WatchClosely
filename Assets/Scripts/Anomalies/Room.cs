using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Anomaly> possibleAnomalies;
    public List<Anomaly> activeAnomalies;
    public string roomName;

    private void Start()
    {
        FindAllPossibleAnomalies();
    }

    private void FindAllPossibleAnomalies()
    {
        possibleAnomalies.AddRange(gameObject.GetComponentsInChildren<Anomaly>(true));
    }

}
