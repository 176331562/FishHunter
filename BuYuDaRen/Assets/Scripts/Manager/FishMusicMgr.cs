using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMusicMgr : MonoBehaviour
{
    private static FishMusicMgr instance;
    public static FishMusicMgr Instance => instance;

    private AudioSource audioSource;


    private Dictionary<string, AudioClip> loadClip = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audioSource = this.GetComponent<AudioSource>();
    }



    public void PlayerAudio(string audioClipName)
    {
        if (loadClip.ContainsKey(audioClipName))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = loadClip[audioClipName];

                audioSource.Play();
            }
            

        }
        else
        {           
            if (!audioSource.isPlaying)
            {
                ResourceRequest rq = Resources.LoadAsync<AudioClip>("Sound/" + audioClipName);

                audioSource.clip = rq.asset as AudioClip;

                loadClip.Add(audioClipName, rq.asset as AudioClip);

                audioSource.Play();
            }           
        }
    }
}