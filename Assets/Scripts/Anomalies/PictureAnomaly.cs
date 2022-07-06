using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureAnomaly : Anomaly
{
    [SerializeField] private Material anomalyPainting;
    private Material basicPainting;
    private MeshRenderer pictureSetting;

    public override void AnomalyAction()
    {
        pictureSetting.material = anomalyPainting;
    }

    public override void AnomalyFixed()
    {
        pictureSetting.material = basicPainting;
    }

    private void Awake()
    {
        anomalyType = AnomalyType.PictureAnomaly;
        pictureSetting = GetComponent<MeshRenderer>();
        basicPainting = pictureSetting.material;
    }

}
