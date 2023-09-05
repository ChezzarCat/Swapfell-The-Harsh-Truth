using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using EZCameraShake;


public class deathConfirmSelect : MonoBehaviour
{
    public Animator anim;
    public Animator fadeOut;
    public Animator fadeOutText;
    public Animator fadeOutMusic;
    private bool isInCutscene = false;
    private bool isYes = true;

    public TMP_Text dialogueText;

    void Start()
    {
        dialogueText.text = "";
        isYes = true;
        isInCutscene = true;
        StartCoroutine("WaitForFadeIn");

        int currentDeath = PlayerPrefs.GetInt("DeathCount");
        currentDeath++;
        PlayerPrefs.SetInt("DeathCount", currentDeath);
        PlayerPrefs.Save();
    }

    IEnumerator WaitForFadeIn()
    {
        yield return new WaitForSeconds(2);
        isInCutscene = false;
    }

    void Update()
    {
        anim.SetBool("isConfirm", isYes);

        if (!isInCutscene)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                FindFirstObjectByType<SAudioManager>().Play("Accept");
                isInCutscene = true;

                if (isYes)
                {
                    StartCoroutine("Retry");
                }
                else if (!isYes)
                {
                    StartCoroutine("MainMenu");
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                FindFirstObjectByType<SAudioManager>().Play("Select");

                if (isYes)
                    isYes = false;
                else
                    isYes = true;
                
            }
        }
        
    }

    IEnumerator Retry()
    {
        fadeOutMusic.SetTrigger("fadeOut");
        fadeOutText.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2f);

        int randomNum = Random.Range(0, 7);
        print(randomNum);
        string currTextPhase = "";

        switch (randomNum)
        {
            case 0:
                currTextPhase = "* Attempting at winning this game by force won't take you nowhere.";
                break;
            case 1:
                currTextPhase = "* You are the living proof that the superiority of humanity is nothing more than a facade.";
                break;
            case 2:
                currTextPhase = "* Time does not wait, not for me, and neither for you.";
                break;
            case 3:
                currTextPhase = "* You should have hurried up.";
                break;
            case 4:
                currTextPhase = "* Pathetic.";
                break;
            case 5:
                currTextPhase = "* Determination won't bring you far.";
                break;
            case 6:
                currTextPhase = "* You are not different from the others, you will eventually fall.";
                break;
            default:
                currTextPhase = "* Pathetic.";
                break;
        }
        
        dialogueText.text = "";
        foreach (char letter in currTextPhase.ToCharArray())
			{
				
				dialogueText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("TorielText");
				yield return new WaitForSeconds(0.045f);
				
			}

        fadeOut.SetTrigger("fadeOut");
        

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Overworld - Geno");
    }

    IEnumerator MainMenu()
    {
        fadeOut.SetTrigger("fadeOut");
        fadeOutMusic.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
