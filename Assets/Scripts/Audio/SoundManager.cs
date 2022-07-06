using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    
    private static AudioClip cameraSwitch;
    private static AudioSource audioSource;
    [SerializeField] private AudioSource roomCameraSource;
    [SerializeField] private AudioClip[] roomSounds;


    public static void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "camera_switch_sound":
                {
                    audioSource.PlayOneShot(cameraSwitch);
                    break;
                }
        }

    }

    public static void StopPlayingSound()
    {
        audioSource.Stop();
    }

    private void PlayRoomSound(int roomNum)
    {
        roomCameraSource.Stop();
        roomCameraSource.PlayOneShot(roomSounds[roomNum]);
    }


    void Start()
    {
        cameraSwitch = Resources.Load<AudioClip>("Audio/camera_switch_sound");
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Awake()
    {
        CameraSwitch.cameraSwitched += PlayRoomSound;
    }


}
