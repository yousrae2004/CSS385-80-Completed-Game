using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class MainMenuController : MonoBehaviour
{
    public GameObject namePanel;     
    public TMP_InputField nameInput;  

    //runs when you click the play button
    public void OpenNamePrompt()
    {
        namePanel.SetActive(true); 
    }

    public void StartGameWithName()
    {
        if (nameInput.text.Length > 0)
        {
            GameGlobals.playerName = nameInput.text;
        }

        // Load the house scene
        SceneManager.LoadScene("HouseInterior");

        GameGlobals.hasKey = false; // Reset the quest item!
        GameGlobals.hasSeenIntro = false; 

        SceneManager.LoadScene("HouseInterior");
    }
}

