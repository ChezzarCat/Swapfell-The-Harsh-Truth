using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class InputFieldName : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text yourNameReferences;
    public string inputText;

    public GameObject canvasType;
    public GameObject canvasConfirm;
    public GameObject fadeout;


    private bool haschoosen;
    private bool cantchoose = false;
    public bool isInCutscene = false;
    //public GameObject reactionGroup;
    //public TMP_Text reactionTextBox;


    private void Start()
    {
        PlayerPrefs.SetInt("DeathCount", 0);
        PlayerPrefs.Save();

        canvasType.SetActive(true);
        canvasConfirm.SetActive(false);
        fadeout.SetActive(false);
        haschoosen = false;
        isInCutscene = false;
        cantchoose = false;

        if (inputField != null)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    void Update()
    {        
        if (!haschoosen)
        {
            inputField.ActivateInputField();
            inputField.interactable = true;
        } 
        else if (haschoosen)
        {
            inputField.interactable = false;

        }
            
    }

    public void Confirm()
    {
        if (!isInCutscene)
            {
                if (cantchoose)
                {
                    haschoosen = false;
                    canvasType.SetActive(true);
                    canvasConfirm.SetActive(false);
                    cantchoose = false;
                } else
                {
                    PlayerPrefs.SetString("InputText", inputText);
                    PlayerPrefs.Save();

                    CameraShaker.Instance.ShakeOnce(2f, 10f, 1f, 0f);
                    fadeout.SetActive(true);
                    FindFirstObjectByType<SAudioManager>().Play("Accept");
                    isInCutscene = true;
                    StartCoroutine("LoadNextScene");
                }
                

            }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5);
        fadeout.SetActive(false);
        canvasType.SetActive(false);
        canvasConfirm.SetActive(false);
        FindFirstObjectByType<IntroNameTextCutscene>().StartCoroutine("endCutscene");
        
    }

    public void Back()
    {
        if (!isInCutscene)
            {
                haschoosen = false;
                canvasType.SetActive(true);
                canvasConfirm.SetActive(false);
                cantchoose = false;
            }
    }

    public void GrabFromInputField(string input)
    {
        inputText = input;
        DisplayReactionToInput();
    }

    public void Screenshake()
    {
        FindFirstObjectByType<SAudioManager>().Play("ItemText");
        CameraShaker.Instance.ShakeOnce(0.3f, 10f, 0f, 0.5f);
    }

    

    private void DisplayReactionToInput()
    {
        haschoosen = true;
        FindFirstObjectByType<SAudioManager>().Play("Accept");
        CameraShaker.Instance.ShakeOnce(0.8f, 10f, 0f, 1f);
        Debug.Log("your name is " + inputText + ".");

        canvasType.SetActive(false);
        canvasConfirm.SetActive(true);

        SetNameReference();
    }

    public void SetNameReference()
    {
        string referenceText = "";

        switch (inputText.ToLower())
        {
            case "papyru":
                referenceText = "not happenin'";
                cantchoose = true;
                break;

            case "sans":
                referenceText = "YOU AIN'T DESERVING, LOW LIFE!";
                cantchoose = true;
                break;

            case "toriel":
                referenceText = "...";
                break;

            case "asgore":
                referenceText = "If you wish.";
                break;

            case "undyne":
                referenceText = "Tsk. Like you can be even a fraction of me.";
                cantchoose = true;
                break;

            case "alphys":
                referenceText = "no.";
                cantchoose = true;
                break;

            case "napsta":
                referenceText = "If ya want it.";
                break;

            case "frisk":
                referenceText = "The first to take the risk.";
                break;

            case "chara":
                referenceText = "You.";
                break;

            // funny references below

            case "daniz":
                referenceText = "Blerg. I'm dead.";
                break;

            case "bwend":
                referenceText = "Bwomp.";
                break;

            case "soja":
                referenceText = "Pepper.";
                break;

            case "ness":
                referenceText = "Still not sans.";
                break;

            case "gyigas":
                referenceText = "The embodiment of Evil.";
                break;

            case "batter":
                referenceText = "...";
                break;

            case "nikki":
                referenceText = "No good.";
                break;

            case "mogeko":
                referenceText = "MO- GE - KO!";
                break;

            case "aika":
                referenceText = "TMK's worst nigtmare.";
                break;

            case "marmar":
            case "marmqr":
                referenceText = "117.";
                break;

            case "chuf":
                referenceText = "Stop playing and get back to work chuf.";
                break;

            case "demo":
                referenceText = "Demo where's the healthbar.";
                break;

            case "inksus":
            case "e-":
                referenceText = "Nightmare Sans tentacles.";
                break;

            case "soup":
                referenceText = "Transabisoja.";
                break;

            case "jade":
                referenceText = "This dumb rabbit.";
                break;


            case "sergio":
                referenceText = "I hope you are playing this on Linux.";
                break;

            case "a":
            case "b":
            case "c":
            case "d":
            case "e":
            case "f":
            case "g":
            case "h":
            case "aaaaaa":
                referenceText = "Did you even try?";
                break;

            case "moralx":
                referenceText = "El fondo?";
                break;

            case "nld":
                referenceText = "When can you code dustin?";
                break;

            case "godo":
                referenceText = "GODO???????";
                break;

            case "jackt":
                referenceText = "fag.";
                break;

            case "gay":
                referenceText = "So you're one of them queers?";
                break;

            case "trans":
                referenceText = "Trans lefts!!";
                break;

            case "peter":
                referenceText = "Peter por favor termina el sprite.";
                break;

            case "shashi":
                referenceText = "Wassabi?";
                break;

            case "croaso":
                referenceText = "Corred por vuestras vidas.";
                break;

            case "volka":
                referenceText = "Volkapocalipsis.";
                break;

            case "penis":
                referenceText = "It takes one to know one.";
                break;

            case "merg":
                referenceText = "The apple guy! Whoops, I mean the cherry!";
                break;

            case "among":
                referenceText = "us.";
                break;

            case "linux":
                referenceText = "Linux (LIN-uuks)[11] is a family of open-source Unix-like operating systems based on the Linux kernel,[12] an operating system kernel first released on September 17, 1991, by Linus Torvalds.[13][14][15] Linux is typically packaged as a Linux distribution, which includes the kernel and supporting system software and libraries, many of which are provided by the GNU Project. Many Linux distributions use the word Linux in their name, but the Free Software Foundation uses the name GNU/Linux to emphasize the use and importance of GNU software in many distributions, causing some controversy.";
                break;

            case "money":
                referenceText = "I like that, got some to spare?";
                break;

            case "wallet":
                referenceText = "Was just messing around, but i won't stop ya.";
                break;

            case "toby":
                referenceText = "WOOF, WOOF, WOOF, WOOF, WOOF, WOOF, WOOF, WOOF, WOOF, WOOF.";
                break;

            case "toilet":
                referenceText = "Skibidi dom dom dom yes yes.";
                break;

            case "sex":
                referenceText = "sex.";
                break;

            case "gaster":
                referenceText = "👎︎✌︎☼︎😐︎ ✡︎☜︎❄︎ 👎︎✌︎☼︎😐︎☜︎☼︎";
                Application.Quit();
                break;

            case "Kys":
                referenceText = "Ok.";
                Application.Quit();
                break;

            default:
                referenceText = "Is this name correct?";
                break;
        }

        yourNameReferences.text = (referenceText.ToString());
    }
}
