using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using System.Collections;

//MADE BY PABLO JACOBS aka PACOPOGO

public class DialogueSystem : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private Image characterImg;
    [Space(10)]
    [SerializeField] private TMP_Text nameTMP;
    [SerializeField] private TMP_Text dialogueTMP;
    [Space(10)]
    [SerializeField] private SimpleAudioPlayer audioPlayer;

    private Dialogue dialogue;
    private int current = 0;

    private bool isTyping = false;

    [Header("Events")]
    [SerializeField] private UnityEvent OnStart;
    [SerializeField] private UnityEvent OnFinish;


    #region Dialogue Functions

    public void SetDialogueData(Dialogue d) => dialogue = d;
    public void StartDialogue(Dialogue d)
    {
        StopAllCoroutines();

        SetDialogueData(d);

        dialogueCanvas.SetActive(true);

        current = 0;
        SetDialogueComponents(current);


        OnStart?.Invoke();

    }

    private void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        OnFinish?.Invoke();
    }

    public void SetDialogueComponents(int index)
    {
        if (dialogue == null)
            return;

        if (dialogue.dialogue[index].sprite == null)
        {
            characterImg.enabled = false;
        }
        else
        {
            characterImg.enabled = true;
            characterImg.sprite = dialogue.dialogue[index].sprite;
        }

        nameTMP.text = dialogue.dialogue[index].name;

        dialogueTMP.color = dialogue.dialogue[index].textColor;

        StartCoroutine(WaitAndPrint(index));
    }

    public void NextDialogue()
    {
        StopAllCoroutines();

        if(isTyping == true)
        {
            dialogueTMP.text = dialogue.dialogue[current].text;
            isTyping = false;

            return;
        }

        current++;

        if (current >= dialogue.dialogue.Length)
        {
            current = 0;
            EndDialogue();

            return;
        }
        
        SetDialogueComponents(current);
    }

    #endregion

    private IEnumerator WaitAndPrint(int index)
    {
        AudioClip clip = dialogue.dialogue[index].typeClip;
        float speed = dialogue.dialogue[index].typeSpeed * 0.01f;

        dialogueTMP.text = "";
     
        foreach (char c in dialogue.dialogue[index].text)
        {
            isTyping = true;

            yield return new WaitForSeconds(speed);

            audioPlayer.PlayAudioClip(clip);
            dialogueTMP.text += c;
        }

        isTyping = false;
        StopCoroutine(WaitAndPrint(index));
    }

}
