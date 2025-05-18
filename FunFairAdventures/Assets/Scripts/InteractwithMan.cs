using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InteractwithMan : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text dialogueText; // Use TMP_Text se estiver usando TextMeshPro
    public float typingSpeed = 0.03f;

    [TextArea(3, 10)]
    public string fullParagraph =
        "Parece que você precisa arrumar o painel de energia!!";
        

    private List<string> sentences = new List<string>();
    private int currentSentence = 0;
    private bool isTalking = false;
    private bool isTyping = false;

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = sentences[currentSentence];
                isTyping = false;
            }
            else
            {
                currentSentence++;
                if (currentSentence < sentences.Count)
                {
                    StartCoroutine(TypeSentence(sentences[currentSentence]));
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    public void Interact()
    {
        if (isTalking) return;

        SplitParagraph();
        currentSentence = 0;
        dialogueUI.SetActive(true);
        isTalking = true;
        StartCoroutine(TypeSentence(sentences[currentSentence]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        isTalking = false;
    }

    void SplitParagraph()
    {
        sentences.Clear();
        string[] parts = fullParagraph.Split('.');
        foreach (string part in parts)
        {
            string trimmed = part.Trim();
            if (!string.IsNullOrEmpty(trimmed))
            {
                sentences.Add(trimmed + ".");
            }
        }
    }
}
