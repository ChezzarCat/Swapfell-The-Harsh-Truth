using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class dialogueManager : MonoBehaviour
{
	public TMP_Text dialogueText;

	public GameObject dialogueTextObject;

	public GameObject[] allFaces;
	public Animator[] allAnimations;
	public Animator overworldsprite;
	public float writespeed = 0.035f;
	private bool skipwritting = false;
	private bool isWritting = false;
	private bool hasFinishedWritting = false;

	public GameObject battlestart;
	private int currentDeath;


	//var or array to get all paps parts

	public Queue<string> sentences;

	public Queue<string> faces;

	private string storypart = "before clock";
	public PlayableDirector viewToClockCutscene;

	private bool pauseface = false;

    void Start()
    {
		currentDeath = PlayerPrefs.GetInt("DeathCount");
		battlestart.SetActive(false);
        sentences = new Queue<string>(); 
        faces = new Queue<string>();
        dialogueTextObject.SetActive(false);

    }

    void Update()
    {
		if (currentDeath == 1 || currentDeath >= 2)
			storypart = "after clock";

    	if (Input.GetKeyDown(KeyCode.Z)  && !pauseface && !isWritting && hasFinishedWritting)
    	{
    		DisplayNextSentence();
    	}

		if (Input.GetKeyDown(KeyCode.X)  && !pauseface)
    	{
    		skipwritting = true;
    	}
		
    }

    public void StartDialogue (dialogue dialogue)
    {
		hasFinishedWritting = false;
		skipwritting = false;
    	dialogueTextObject.SetActive(true);

    	sentences.Clear();

    	foreach (string sentence in dialogue.sentences)
    	{
    		sentences.Enqueue(sentence);
    	}


    	foreach (string face in dialogue.faces)
    	{
    		faces.Enqueue(face);
    	}

    	DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
		hasFinishedWritting = false;
    	if (sentences.Count == 0)
    	{
    		EndDialogue();
    		return;
    	}

		skipwritting = false;

    	string sentence = sentences.Dequeue();
    	string face = faces.Dequeue();
  
    	foreach (GameObject hideAllFaces in allFaces)
    	{
    		hideAllFaces.SetActive(false);
    	}

    	StopAllCoroutines();
    	StartCoroutine(Typesentence(sentence, face));
    }

    IEnumerator Typesentence(string sentence, string face)
    {
		if (face != "wait")
		{
			isWritting = true;

			dialogueText.text = "";

			if (sentence == "* tsk tsk tsk.")
				overworldsprite.SetTrigger("isShaking");
			else
				overworldsprite.SetTrigger("isTalking");

			switch (face)
			{
				case "idle":
				allFaces[0].SetActive(true);
				allAnimations[0].SetBool("isTalking", true);
				break;

				case "blink":
				allFaces[1].SetActive(true);
				allAnimations[1].SetBool("isTalking", true);
				break;

				case "lookleft":
				allFaces[2].SetActive(true);
				allAnimations[2].SetBool("isTalking", true);
				break;

				case "huh":
				allFaces[3].SetActive(true);
				allAnimations[3].SetBool("isTalking", true);
				break;

				case "disgusted":
				allFaces[4].SetActive(true);
				allAnimations[4].SetBool("isTalking", true);
				break;

			}


			foreach (char letter in sentence.ToCharArray())
			{
				if (skipwritting)
				{
					dialogueText.text = sentence;
				}
				else
				{
					dialogueText.text += letter;
					FindFirstObjectByType<SAudioManager>().Play("Paps Text");
					yield return new WaitForSeconds(writespeed);
				}
				
			}

			skipwritting = false;
			isWritting = false;
			hasFinishedWritting = true;

			switch (face)
			{
				case "idle":
				allAnimations[0].SetBool("isTalking", false);
				break;

				case "blink":
				allAnimations[1].SetBool("isTalking", false);
				break;

				case "lookleft":
				allAnimations[2].SetBool("isTalking", false);
				break;

				case "huh":
				allAnimations[3].SetBool("isTalking", false);
				break;

				case "disgusted":
				allAnimations[4].SetBool("isTalking", false);
				break;
			}

			if (sentence != "* tsk tsk tsk.")
				overworldsprite.SetTrigger("backToIdle");

		} else 
		{
			pauseface = true;
			overworldsprite.SetTrigger("backToIdle");
			dialogueTextObject.SetActive(false);
			yield return new WaitForSeconds(1.5f);
			dialogueTextObject.SetActive(true);
			pauseface = false;
			DisplayNextSentence();
			
		}
    	

    }
    

    void EndDialogue()
    {
		hasFinishedWritting = false;
		overworldsprite.SetTrigger("backToIdle");
    	dialogueTextObject.SetActive(false);
		skipwritting = false;

    	foreach (GameObject hideAllFaces in allFaces)
    	{
    		hideAllFaces.SetActive(false);
    	}

    	allFaces[0].SetActive(true);
		StopAllCoroutines();

		switch (storypart)
		{
			case "before clock":
				viewToClockCutscene.Play();
				StartCoroutine("changeto2");
			break;

			case "after clock":
				StartCoroutine("startbattle");
			break;

    	}
	}

	IEnumerator startbattle()
	{
		yield return new WaitForSeconds(0.2f);
		FindFirstObjectByType<SAudioManager>().Stop("Rain");
		battlestart.SetActive(true);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("Geno Battle");
	}

	IEnumerator changeto2()
	{
		yield return new WaitForSeconds(2f);
		storypart = "after clock";
	}

}
