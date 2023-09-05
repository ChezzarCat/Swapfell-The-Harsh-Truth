using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class dialogueManagerBattle : MonoBehaviour
{
	public TMP_Text dialogueText;

	public Animator textBoxAnimator;

	public Animator allAnimations;
	public float writespeed = 0.035f;
	private bool skipwritting = false;
	private bool isWritting = false;
	private bool hasFinishedWritting = false;

	public turnManager turnManager;



	//var or array to get all paps parts

	public Queue<string> sentences;

	public Queue<string> faces;


	private bool pauseface = false;
	private bool startAnim = true;

    void Start()
    {
        sentences = new Queue<string>(); 
        faces = new Queue<string>();
		FindFirstObjectByType<SAudioManager>().Play("Rain");
    }

    void Update()
    {
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
		textBoxAnimator.SetTrigger("enterDialogue");
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
  

    	StopAllCoroutines();
    	StartCoroutine(Typesentence(sentence, face));
    }

    IEnumerator Typesentence(string sentence, string face)
    {
		if (face != "wait")
		{
			isWritting = true;

			dialogueText.text = "";

			switch (face)
			{
				case "idle":
				allAnimations.SetTrigger("idleTalk");
				break;

				case "blink":
				allAnimations.SetTrigger("blinkTalk");
				break;

				case "lookleft":
				allAnimations.SetTrigger("lookleftTalk");
				break;

				case "huh":
				allAnimations.SetTrigger("huhTalk");
				break;

				case "disgusted":
				allAnimations.SetTrigger("disgustedTalk");
				break;

				case "lookdown":
				allAnimations.SetTrigger("lookdownTalk");
				break;

				case "idlenocigarette":
				allAnimations.SetTrigger("idleTalkNocigarette");
				break;

				case "knife":
				allAnimations.SetTrigger("knifeTalk");
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

			hasFinishedWritting = true;
			skipwritting = false;
			isWritting = false;

			switch (face)
			{
				case "idle":
				allAnimations.SetTrigger("idleTalkEND");
				break;

				case "blink":
				allAnimations.SetTrigger("blinkTalkEND");
				break;

				case "lookleft":
				allAnimations.SetTrigger("lookleftTalkEND");
				break;

				case "huh":
				allAnimations.SetTrigger("huhTalkEND");
				break;

				case "disgusted":
				allAnimations.SetTrigger("disgustedTalkEND");
				break;

				case "lookdown":
				allAnimations.SetTrigger("lookdownTalkEND");
				break;

				case "idlenocigarette":
				allAnimations.SetTrigger("idleTalkNocigaretteEND");
				break;

				case "knife":
				allAnimations.SetTrigger("knifeTalkEND");
				break;
			}

		} else 
		{
			pauseface = true;
			textBoxAnimator.SetTrigger("leaveDialogue");
			yield return new WaitForSeconds(1.5f);
			textBoxAnimator.SetTrigger("enterDialogue");
			pauseface = false;
			DisplayNextSentence();
			
		}
    	

    }
    

    void EndDialogue()
    {
		if (startAnim)
		{
			StartCoroutine("smokeattackAnim");
			hasFinishedWritting = false;
			textBoxAnimator.SetTrigger("leaveDialogue");
			skipwritting = false;
			startAnim = false;
		}
		else
		{
			hasFinishedWritting = false;
			allAnimations.SetTrigger("idle");
			textBoxAnimator.SetTrigger("leaveDialogue");
			skipwritting = false;
			turnManager.NextAttack();
			StopAllCoroutines();
		}
		

	}

	IEnumerator smokeattackAnim()
	{
		yield return new WaitForSeconds(0.5f);
		FindFirstObjectByType<SAudioManager>().Stop("Rain");
		turnManager.NextAttack();
		StopAllCoroutines();
	}

}
