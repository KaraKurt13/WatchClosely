using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementAnomaly : Anomaly
{
    [SerializeField] private Vector3 currentPosition;
    [SerializeField] private Quaternion currentRotation;
    [SerializeField] private Vector3 newPosition;
    [SerializeField] private Quaternion newRotation;

    public override void AnomalyAction()
    {
        this.gameObject.transform.localRotation = newRotation;
        this.gameObject.transform.localPosition = newPosition;
        
    }

    public override void AnomalyFixed()
    {
        this.gameObject.transform.localRotation = currentRotation;
        this.gameObject.transform.localPosition = currentPosition;
    }

    private void Awake()
    {

        anomalyType = AnomalyType.ObjectMovement;
        currentPosition = this.gameObject.transform.localPosition;
        currentRotation = this.gameObject.transform.localRotation;
    }
}
