using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip DeathSound;

    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SFXSource;

    //delaying the Start method 
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        MusicSource.clip = BackgroundMusic;
        MusicSource.Play();     
    }

    public void PlayJumpSound()
    {
        SFXSource.clip = JumpSound;
        SFXSource.Play();
    }

    public void PlayDeathSound()
    {
        SFXSource.clip = DeathSound;
        SFXSource.Play();
    }

}
