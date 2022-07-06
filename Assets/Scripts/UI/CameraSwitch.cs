using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    private Canvas cameraCanvas;
    private int currentCamera;
    private int previousCamera;
    [SerializeField] private Camera[] cameras;
    [SerializeField] private GameObject cameraNoise;
    [SerializeField] private string[] roomNames;
    [SerializeField] private Text cameraRoomName;

    public delegate void CameraSwitchEvent(int cameraNum);
    public static event CameraSwitchEvent cameraSwitched;



    void Start()
    {
        Initialization();
    }
    
    void Initialization()
    {
        cameraCanvas = this.gameObject.GetComponent<Canvas>();
        currentCamera = 0;
        previousCamera = 1;
        cameraRoomName.text = roomNames[currentCamera];
        cameras[currentCamera].enabled = true;
        cameras[previousCamera].enabled = false;
        cameraSwitched(currentCamera);
    }
    public void SwitchCameraToNext()
    {
        previousCamera = currentCamera;
        if(currentCamera== cameras.Length-1)
        {
            currentCamera = 0;
            StartCoroutine(ChangeCamera());
            cameraRoomName.text = roomNames[currentCamera];
            return;

        }

        currentCamera++;
        cameraRoomName.text = roomNames[currentCamera];
        StartCoroutine(ChangeCamera());
    }

    public void SwitchCameraToPrevious()
    {
        previousCamera = currentCamera;
        if (currentCamera==0)
        {
            currentCamera = cameras.Length-1;
            StartCoroutine(ChangeCamera());
            cameraRoomName.text = roomNames[currentCamera];
            return;
        }

        currentCamera--;
        cameraRoomName.text = roomNames[currentCamera];
        StartCoroutine(ChangeCamera());
    }

    IEnumerator ChangeCamera()
    {
        ShowCameraNoise();
        SoundManager.PlaySound("camera_switch_sound");
        yield return new WaitForSeconds(0.5f);
        cameraSwitched(currentCamera);
        cameras[currentCamera].enabled = true;
        cameras[previousCamera].enabled = false;
        SoundManager.StopPlayingSound();
        HideCameraNoise();
        Debug.Log(currentCamera);
    }

    private void ShowCameraNoise()
    {
        cameraNoise.SetActive(true);
    }

    private void HideCameraNoise()
    {
        cameraNoise.SetActive(false);
    }
}
