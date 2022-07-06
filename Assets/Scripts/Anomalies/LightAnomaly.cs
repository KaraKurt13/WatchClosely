using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Anomalies/Light Anomaly")]
public class LightAnomaly : Anomaly
{
    private Light lightSettings;
    private float basicLightIntensity;
    [SerializeField] private float anomalyLightIntensity;
    [SerializeField] private LightAnomalyType lightAnomalyType;
    
    public override void AnomalyAction()
    {
        switch(lightAnomalyType)
        {
            case LightAnomalyType.TurnOnLight:
                {
                    lightSettings.enabled = true;
                    break;
                }

            case LightAnomalyType.TurnOffLight:
                {
                    lightSettings.enabled = false;
                    break;
                }
            case LightAnomalyType.IncreaseIntensity:
                {
                    lightSettings.intensity = anomalyLightIntensity;
                    break;
                }
        }
    }

    public override void AnomalyFixed()
    {
        switch (lightAnomalyType)
        {
            case LightAnomalyType.TurnOnLight:
                {
                    lightSettings.enabled = false;
                    break;
                }

            case LightAnomalyType.TurnOffLight:
                {
                    lightSettings.enabled = true;
                    break;
                }
            case LightAnomalyType.IncreaseIntensity:
                {
                    lightSettings.intensity = basicLightIntensity;
                    break;
                }


        }
    }

    private void Awake()
    {
        anomalyType = AnomalyType.LightAnomaly;
        lightSettings = GetComponent<Light>();
        basicLightIntensity = lightSettings.intensity;
        //AnomalyAction();
    }

    private enum LightAnomalyType
    {
        TurnOnLight,
        TurnOffLight,
        IncreaseIntensity,
    }

}
