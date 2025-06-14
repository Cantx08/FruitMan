using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacterManager : MonoBehaviour
{
    public static SelectionCharacterManager instance; // Singleton instance
    public List<Character> characters; // List of characters available for selection

    private void Awake()
    {
        if (SelectionCharacterManager.instance == null)
        {
            SelectionCharacterManager.instance = this;
            DontDestroyOnLoad(this.gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
