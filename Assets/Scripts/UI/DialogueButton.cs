using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    [Tooltip("put in the dialogues you want to play, 0 is the first to play")]
    [SerializeField] private List<DialogueData> dialoguesToPlay = new();
    [Header("sprites")]
    [SerializeField] private Sprite backgroundSprite;
    [SerializeField] private List<Sprite> spritesToPlay = new();
    int currentDialogue = 0;
    public void playNextDialogue()
    {
        DialogueWriter.Instance.InitializeDialogue(dialoguesToPlay[currentDialogue]);
        backgroundSprite = spritesToPlay[currentDialogue];
        currentDialogue++;
        
    }
}