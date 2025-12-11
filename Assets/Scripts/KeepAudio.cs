using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    public static KeepAudio instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           Destroy(gameObject);
           return;
        }

    }
    public void ChangeMusic(AudioClip newClip)
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source.clip != newClip)
        {
            source.clip = newClip;
            source.Play();
        }
    }
}