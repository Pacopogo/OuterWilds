using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//MADE BY PABLO JACOBS aka PACOPOGO

[System.Serializable]
public class DialogueInfo
{
    public string name = "Mark";          //Name of speaker
    [Space(10)]
    [TextArea(5,5)]
    public string text;                   //the dialogue itself

    [Header("Settings")]
    public Sprite sprite;
    public float typeSpeed = 5;           //The speed at which the dialogue will be typed
    public Color textColor = Color.white;

    [Header("Sounds & Clips")]
    public AudioClip initalClip;          //for sound effects or voice gasps
    public AudioClip typeClip;            //for when text is typed out
    public AudioClip voiceLine;           //For if we want to voice over the clip

    [Header("Events")]
    public bool hasEvent = false;
    public UnityEvent OnDialogue;
    public UnityEvent EndDialogue;


}

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public DialogueInfo[] dialogue;
}
