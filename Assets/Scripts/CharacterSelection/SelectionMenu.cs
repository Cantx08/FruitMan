using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    private int index;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameCharacter;
    private SelectionCharacterManager selectionCharacterManager;

    private void Start()
    {
        selectionCharacterManager = SelectionCharacterManager.instance; // Obtiene la instancia del GameManager
        index = PlayerPrefs.GetInt("CharacterIndex"); // Obtiene el personaje seleccionado del PlayerPrefs

        if (index > selectionCharacterManager.characters.Count - 1)
        {
            index = 0;
        }
    }

    private void ChangeCharacter()
    {
        PlayerPrefs.SetInt("CharacterIndex", index); // Guarda el personaje seleccionado en PlayerPrefs
        image.sprite = selectionCharacterManager.characters[index].image; // Cambia la imagen del personaje
        nameCharacter.text = selectionCharacterManager.characters[index].characterName; // Cambia el nombre del personaje
    }

    public void NextCharacter()
    {
        index++;
        if (index >= selectionCharacterManager.characters.Count)
        {
            index = 0; // Vuelve al primer personaje si se supera el límite
        }
        ChangeCharacter(); // Actualiza la imagen y el nombre del personaje
    }

    public void PreviousCharacter()
    {
        index--;
        if (index < 0)
        {
            index = selectionCharacterManager.characters.Count - 1; // Vuelve al último personaje si se supera el límite
        }
        ChangeCharacter(); // Actualiza la imagen y el nombre del personaje
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la escena del juego
    }
}
