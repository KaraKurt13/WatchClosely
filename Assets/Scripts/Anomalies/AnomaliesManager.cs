using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomaliesManager : MonoBehaviour
{
    [SerializeField]private int anomaliesCounter=0;
    public float timeLeftForAnomalySpawning;
    [SerializeField] private List<Room> rooms;

    private static float RANDOM_MAX_TIME_TO_ANOMALY_SPAWN=55f;
    private static float RANDOM_MIN_TIME_TO_ANOMALY_SPAWN=75f;

    public delegate void AnomaliesAmount();
    public static event AnomaliesAmount tooMuchAnomalies;
    public static event AnomaliesAmount criticalAmountOfAnomalies;
    private bool warningIsAvaible = true;


    public bool ReportedAnomalyExist(string roomName, string anomalyType)
    {
        bool anomalyExist = false;
        List<Anomaly> anomaliesToFix=new List<Anomaly>();
        foreach(Room room in rooms)
        {
            if(room.roomName != roomName)
            {
                continue;
            }

            foreach (Anomaly activeAnomaly in room.activeAnomalies)
            {
                if (activeAnomaly.anomalyType.ToString() == anomalyType)
                {
                    Debug.Log(activeAnomaly);
                    anomaliesToFix.Add(activeAnomaly);
                    anomalyExist = true;
                }
            }

            FixAnomaly(room, anomaliesToFix);
            return anomalyExist;
        }

        return anomalyExist;
    }

    private void GenerateAnomaly()
    {
        Room randomRoom = rooms[Random.Range(0, rooms.Count)];

        if(randomRoom.possibleAnomalies.Count==0)
        {
            return;
        }

        Anomaly randomAnomaly = randomRoom.possibleAnomalies[Random.Range(0, randomRoom.possibleAnomalies.Count)];

        foreach(Anomaly activeAnomaly in randomRoom.activeAnomalies)
        {
            if(randomAnomaly.gameObject==activeAnomaly.gameObject)
            {
                return;
            }
        }

        SetRandomTimeForAnomalySpawning();
        randomRoom.activeAnomalies.Add(randomAnomaly);
        randomRoom.possibleAnomalies.Remove(randomAnomaly);
        randomAnomaly.AnomalyAction();        
        IncreaseAnomaliesCount();
    }

    private void FixAnomaly(Room fixRoom,List<Anomaly> fixAnomaly)
    {
        if(fixAnomaly.Count==0)
        {
            return;
        }

        for (int i = 0; i < fixRoom.activeAnomalies.Count; i++)
        {
            foreach (Anomaly anomalyToFix in fixAnomaly)
            {
                if (fixRoom.activeAnomalies[i] == anomalyToFix)
                {
                    anomalyToFix.AnomalyFixed();
                    fixRoom.activeAnomalies.Remove(anomalyToFix);
                    DecreaseAnomaliesCount();
                    i--;
                    break;
                }
            }
                
        }
    }

    /*private void FixAnomaly(Room fixRoom,Anomaly fixAnomaly)
    {
        
        foreach(Anomaly activeAnomaly in fixRoom.activeAnomalies)
        {
            if(activeAnomaly==fixAnomaly)
            {
                activeAnomaly.AnomalyFixed();
                DecreaseAnomaliesCount();
                break;
            }
        }

        fixRoom.activeAnomalies.Remove(fixAnomaly);
    }*/

    private void IncreaseAnomaliesCount()
    {
        anomaliesCounter++;

        if(anomaliesCounter==5 && warningIsAvaible)
        {
            criticalAmountOfAnomalies();
            return;
        }

        if (anomaliesCounter > 5)
        {
            tooMuchAnomalies();
        }
    }

    private void DecreaseAnomaliesCount()
    {
        anomaliesCounter--;
    }

    private void Update()
    {
        timeLeftForAnomalySpawning -= Time.deltaTime;
        if(timeLeftForAnomalySpawning<0)
        {
            GenerateAnomaly();
        }

        
    }

    private void SetRandomTimeForAnomalySpawning()
    {
        timeLeftForAnomalySpawning = Random.Range(RANDOM_MIN_TIME_TO_ANOMALY_SPAWN, RANDOM_MAX_TIME_TO_ANOMALY_SPAWN);
    }

    private void Start()
    {
        SetRandomTimeForAnomalySpawning();
    }

   
}
