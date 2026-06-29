using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    [Tooltip("put in the dialogues you want to play, 0 is the first to play")]
    [SerializeField] private List<DialogueData> dialoguesToPlay;// = new();
    [Header("sprites")]
    [SerializeField] private RawImage backgroundSprite;
    [SerializeField] private List<Texture> spritesToPlay;// = new();
    [SerializeField] private GameObject sceneswapButton;
    int currentDialogue = 0;

    public void playNextDialogue()
    {
        DialogueWriter.Instance.InitializeDialogue(dialoguesToPlay[currentDialogue]);
        backgroundSprite.texture = spritesToPlay[currentDialogue];
        if (currentDialogue < dialoguesToPlay.Count - 1)
        {
            currentDialogue++;
        }
        else
        { 
            this.gameObject.SetActive(false);
            sceneswapButton.SetActive(true); 
        }

    }
}