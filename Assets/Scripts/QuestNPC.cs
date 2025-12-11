using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuestNPC : MonoBehaviour
{
    [Header("Dialogues")]
    public Dialogue questStartDialogue; 
    public Dialogue questFinishDialogue; 
    
    [Header("Settings")]
    public string sceneToLoad = "MainMenu"; //current win Screen
    public Transform walkDestination; 
    public float walkSpeed = 3f;

    [Header("Animation")]

    public Animator npcAnimator; 

    private bool playerInRange = false;
    private bool hasStartedIntro = false;

    public void StartNPCSequence()
    {
        if (!hasStartedIntro)
        {
            hasStartedIntro = true;
            gameObject.SetActive(true);
            StartCoroutine(WalkAndTalk());
        }
    }

    IEnumerator WalkAndTalk()
    {
        if (npcAnimator != null)
        {
            npcAnimator.SetBool("isWalking", true);
        }

        if (walkDestination != null)
        {
            while (Vector2.Distance(transform.position, walkDestination.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, walkDestination.position, walkSpeed * Time.deltaTime);
                yield return null; 
            }
        }

        if (npcAnimator != null)
        {
            npcAnimator.SetBool("isWalking", false);
        }

        DialogueManager.Instance.StartDialogue(questStartDialogue);
    }

    
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueManager.Instance != null && DialogueManager.Instance.dialogueBox.activeInHierarchy) return;
            CheckQuest();
        }
    }

    void CheckQuest()
    {
        if (GameGlobals.hasKey == true)
        {
           
            StartCoroutine(PlayWinSequence());
        }
        else
        {
        
            DialogueManager.Instance.StartDialogue(questStartDialogue);
        }
    }

    IEnumerator PlayWinSequence()
    {
        DialogueManager.Instance.StartDialogue(questFinishDialogue);

        while (DialogueManager.Instance.dialogueBox.activeInHierarchy)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}