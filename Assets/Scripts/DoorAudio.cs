using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    private AudioSource audio;
    private Animator anim;
    [SerializeField] private AudioClip door;
    [SerializeField] private AudioClip stop;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void DoorAud()
    {
        audio.clip = door;
        audio.Play();
    }
    public void StopDoorAud()
    {
        audio.clip = stop;
        audio.Play();
    }

}
