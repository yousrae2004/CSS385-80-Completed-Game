using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public AudioClip meowSound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            source.PlayOneShot(meowSound);
        }
    }
}