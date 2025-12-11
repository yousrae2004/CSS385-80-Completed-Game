using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip gardenMusic; 
    void Start()
    {
        // When this scene starts, tell the persistent music player to switch tracks
        if (KeepAudio.instance != null)
        {
            KeepAudio.instance.ChangeMusic(gardenMusic);
        }
    }
}