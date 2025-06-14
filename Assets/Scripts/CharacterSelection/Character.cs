using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public GameObject characterSelected;
    public Sprite image;
    public string characterName;
}
