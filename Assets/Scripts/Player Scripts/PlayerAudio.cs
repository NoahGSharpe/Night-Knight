using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    private bool isPlaying;
    [SerializeField] private AudioClip run;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip land;
    [SerializeField] private AudioClip attack1;
    [SerializeField] private AudioClip attack2;
    [SerializeField] private AudioClip toss;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip die;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
        {
            RunAud();
        }
        else
        {
            if (isPlaying == true)
            {
                audio.loop = false;
                audio.Stop();
                isPlaying = false;
            }
            
        }
    }

    public void RunAud()
    {
        audio.Stop();
        if (isPlaying == false)
        {
            audio.clip = run;
            audio.loop = true;
            audio.Play();
            isPlaying = true;
        }
        
    }
    public void JumpAud()
    {
        audio.Stop();
        audio.clip = jump;
        audio.Play();
    }
    public void LandAud()
    {
        audio.Stop();
        audio.clip = land;
        audio.Play();
    }
    public void Attack1Aud()
    {
        audio.Stop();
        audio.clip = attack1;
        audio.Play();
    }
    public void Attack2Aud()
    {
        audio.Stop();
        audio.clip = attack2;
        audio.Play();
    }
    public void TossAud()
    {
        audio.Stop();
        audio.clip = toss;
        audio.Play();
    }
    public void HurtAud()
    {
        audio.Stop();
        audio.clip = hurt;
        audio.Play();
    }
    public void DieAud()
    {
        audio.Stop();
        audio.clip = die;
        audio.Play();
    }
}
