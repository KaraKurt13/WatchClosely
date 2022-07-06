using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExtraObjectAnomaly : Anomaly
{
    public override void AnomalyAction()
    {
        this.gameObject.SetActive(true);
    }

    public override void AnomalyFixed()
    {
        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        anomalyType = AnomalyType.ExtraObject;
    }
}

