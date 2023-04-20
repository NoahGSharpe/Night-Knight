using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    private bool isPlaying;
    [SerializeField] private AudioClip step;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip hiss;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StepAud()
    {
        audio.Stop();
        audio.clip = step;
        audio.Play();
    }
    public void AttackAud()
    {
        audio.Stop();
        audio.clip = attack;
        audio.Play();
    }
    public void HissAud()
    {
        audio.Stop();
        audio.clip = hiss;
        audio.Play();
    }
}
