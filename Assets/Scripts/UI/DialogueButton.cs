using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    [Tooltip("put in the dialogues you want to play, 0 is the first to play")]
    [SerializeField] private List<DialogueData> dialoguesToPlay;// = new();
    [Header("sprites")]
    [SerializeField] private Sprite backgroundSprite;
    [SerializeField] private List<Sprite> spritesToPlay;// = new();
    [SerializeField] private GameObject sceneswapButton;
    int currentDialogue = 0;
    public void playNextDialogue()
    {
        if (currentDialogue < dialoguesToPlay.Count - 1)
        {
            DialogueWriter.Instance.InitializeDialogue(dialoguesToPlay[currentDialogue]);
            Debug.Log(dialoguesToPlay[currentDialogue]);
            backgroundSprite = spritesToPlay[currentDialogue];
            currentDialogue++;
        }
        else
        {
            DialogueWriter.Instance.InitializeDialogue(dialoguesToPlay[currentDialogue]);
            this.gameObject.SetActive(false);
            sceneswapButton.SetActive(true); 
        }

    }
}