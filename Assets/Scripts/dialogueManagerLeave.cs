using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManagerleave : MonoBehaviour
{
	public TMP_Text dialogueText;
	public GameObject dialogueTextObject;

	public CharaMovement chara;

	public float writespeed = 0.035f;


	public Queue<string> sentences;
	private bool isWritting = false;
	private bool skipwritting = false;

    void Start()
    {
        sentences = new Queue<string>(); 
    }

    void Update()
    {
		if (dialogueTextObject.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.Z) && !isWritting)
    	{
    		DisplayNextSentence();
    	}

		if (Input.GetKeyDown(KeyCode.X))
    	{
    		skipwritting = true;
    	}
		}
		
    }

    public void StartDialogue (dialogue dialogue)
    {
    	dialogueTextObject.SetActive(true);
		skipwritting = false;

    	sentences.Clear();

    	foreach (string sentence in dialogue.sentences)
    	{
    		sentences.Enqueue(sentence);
    	}

    	DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
    	if (sentences.Count == 0)
    	{
    		EndDialogue();
    		return;
    	}

		skipwritting = false;

    	string sentence = sentences.Dequeue();

    	StopAllCoroutines();
    	StartCoroutine(Typesentence(sentence));
    }

    IEnumerator Typesentence(string sentence)
    {
		isWritting = true;
    	dialogueText.text = "";

    	foreach (char letter in sentence.ToCharArray())
    	{
    		if (skipwritting)
				{
					dialogueText.text = sentence;
				}
				else
				{
					dialogueText.text += letter;
					FindFirstObjectByType<SAudioManager>().Play("Default Text");
					yield return new WaitForSeconds(writespeed);
				}
    	}

		skipwritting = false;
		isWritting = false;
    }
    

    void EndDialogue()
    {
		skipwritting = false;
		chara.movementislocked = false;
    	dialogueTextObject.SetActive(false);
		StopAllCoroutines();
    }

}
