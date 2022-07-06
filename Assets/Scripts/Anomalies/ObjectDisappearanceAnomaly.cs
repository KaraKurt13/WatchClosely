using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Anomalies/Object Disappearance")]
public class ObjectDisappearanceAnomaly : Anomaly
{

    public override void AnomalyAction()
    {
        this.gameObject.SetActive(false);
    }

    public override void AnomalyFixed()
    {
        this.gameObject.SetActive(true);
    }

    private void Awake()
    {
        anomalyType = AnomalyType.ObjectDisappearance;
    }
}
