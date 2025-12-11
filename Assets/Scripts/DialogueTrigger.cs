using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; 
    public bool triggerOnStart = false;
    public bool triggerOnPlayerEnter = true; 

    private bool hasTriggered = false;

    void Start()
    {
        if (triggerOnStart)
        {
            // checks if weve seen the intro 
            if (GameGlobals.hasSeenIntro == false)
            {
                TriggerDialogue();
       
                GameGlobals.hasSeenIntro = true; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggerOnPlayerEnter || hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}