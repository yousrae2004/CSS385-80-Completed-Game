using UnityEngine;
using System.Collections;

public class ButterflySequence : MonoBehaviour
{
    [Header("Settings")]
    public float flySpeed = 5f;
    public Vector2 flyDirection = new Vector2(1, 1);
    public float flyDuration = 2f;

    [Header("Dialogues")]
    public bool playInitialDialogue = true;
    public Dialogue initialDialogue;
    public Dialogue lostDialogue; // "Oh no, where am I?"

    [Header("Connections")]
    public QuestNPC questNPC; 

    private bool isFlying = false;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (DialogueManager.Instance == null)
            {
                Debug.LogError("DialogueManager Instance is NULL!");
                return;
            }

            hasTriggered = true;
            StartCoroutine(StartTheSequence());
        }
    }

    IEnumerator StartTheSequence()
    {
       
        if (playInitialDialogue)
        {
            DialogueManager.Instance.StartDialogue(initialDialogue);
            while (DialogueManager.Instance.dialogueBox.activeInHierarchy)
            {
                yield return null; 
            }
        }

        
        isFlying = true;
        yield return new WaitForSeconds(flyDuration);
        isFlying = false;
        
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

     
        DialogueManager.Instance.StartDialogue(lostDialogue);

        while (DialogueManager.Instance.dialogueBox.activeInHierarchy)
        {
            yield return null; 
        }

       
        if (questNPC != null)
        {
            questNPC.StartNPCSequence();
        }
    }

    void Update()
    {
        if (isFlying)
        {
            transform.Translate(flyDirection.normalized * flySpeed * Time.deltaTime);
        }
    }
}