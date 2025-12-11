using UnityEngine;

public class GameGlobals : MonoBehaviour
{
    // "static" means this variable is shared by the whole game
    // and survives even when scenes change.
    public static string playerName = "Adventurer";
    public static bool hasKey = false;

    public static bool hasSeenIntro = false; 
} 