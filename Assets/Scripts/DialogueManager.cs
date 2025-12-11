using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    public static DialogueManager Instance;

    void Awake()
    {
        Instance = this;
        sentences = new Queue<string>();
        /*
     if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        sentences = new Queue<string>(); 
        */
    }
    void Start()
    {
        
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (dialogueBox == null) return;

        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true); 
        nameText.text = dialogue.name.Replace("{player}", GameGlobals.playerName);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            // replaces {player} with the name typed in the Main Menu
            string finalSentence = sentence.Replace("{player}", GameGlobals.playerName);
            sentences.Enqueue(finalSentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // If no more sentences, close the box
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false); 
    }
}
