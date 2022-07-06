using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderAnomaly : Anomaly
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
        anomalyType = AnomalyType.Intruder;
    }
}
