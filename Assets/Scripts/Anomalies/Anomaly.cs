using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Anomaly : MonoBehaviour
{
    //public GameObject anomalyObject;
    public AnomalyType anomalyType;

    public abstract void AnomalyAction();
    public abstract void AnomalyFixed();

    public enum AnomalyType
    {
        ExtraObject,
        ObjectMovement,
        ObjectDisappearance,
        LightAnomaly,
        Intruder, 
        PictureAnomaly,
    }

}
