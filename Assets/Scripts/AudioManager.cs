using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audio;
    [SerializeField] private GameObject Prefab;
    // Start is called before the first frame update
    private void Awake()
    {
        audio = this;
    }
    private AudioSource AsJump;
    public AudioClip AcJump;
     private AudioSource Asdie;
    public AudioClip Acdie;
     private AudioSource AseatingCoin;
    public AudioClip AcaetingCoin;
     private AudioSource AsWin;
    public AudioClip AcWin;

   public void PlayAudio(AudioClip clip, ref AudioSource audioSc, float volumn, bool isplay = false)
    {
        if(audioSc != null && audioSc.isPlaying)
        {
            return;
        }
        audioSc = Instantiate(audio.Prefab).GetComponent<AudioSource>();
        audioSc.volume = volumn;
        audioSc.loop = isplay;
        audioSc.clip = clip;
        audioSc.Play();
        Destroy(audioSc.gameObject, audioSc.clip.length);
        
    }
    public void PlaySound(AudioClip clip, float volumn)
    {
        if(clip == AcaetingCoin)
        {
            PlayAudio(AcaetingCoin,ref AseatingCoin, 1f);
        }
        if (clip ==Acdie)
        {
            PlayAudio(Acdie, ref Asdie, 1f);
        }
        if (clip == AcJump)
        {
            PlayAudio(AcJump, ref AsJump, 1f);
        }
        if (clip == AcWin)
        {
            PlayAudio(AcWin, ref AsWin, 1f);
        }
    }
    private void StopAudio( AudioClip clip)
    {
       if(clip == this.Acdie)
        {
            Asdie?.Stop();
            return;
        }
        if (clip == this.AcWin)
        {
            AsWin?.Stop(); return;
        }
        if (clip == this.AcJump)
        {
            AsJump?.Stop(); return;
        }
        if (clip == this.AcaetingCoin)
        {
            AseatingCoin?.Stop(); return;
        }
    }
}
