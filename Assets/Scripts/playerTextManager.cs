using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerTextManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public int phase = 0;
    public string currTextPhase;
    public float writespeed = 0.035f;

    void Start()
    {
        dialogueText.text = "";
    }

    void Update()
    {
        switch (phase)
        {
            case 0:
                currTextPhase = "* The rain pierces your skin like acid.";
            break;

            case 1:
                currTextPhase = "* You feel the soil under your feet pulling you down.";
            break;

            case 2:
                currTextPhase = "* You feel the loam under your feet pulling you down.";
            break;
        }
    }
    
    public IEnumerator WriteText()
    {
        yield return new WaitForSeconds(0.75f);
        FindFirstObjectByType<stateManager>().isfirstturn = false;
        dialogueText.text = "";
        foreach (char letter in currTextPhase.ToCharArray())
			{
				
				dialogueText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(writespeed);
				
			}
    }

    public IEnumerator WriteTextNoDelay()
    {
        dialogueText.text = "";
        foreach (char letter in currTextPhase.ToCharArray())
			{
				
				dialogueText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(writespeed);
				
			}
    }

    public void DeleteText()
    {
        dialogueText.text = "";
    }

}
