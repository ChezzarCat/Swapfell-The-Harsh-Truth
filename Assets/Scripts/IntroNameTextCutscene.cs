using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroNameTextCutscene : MonoBehaviour
{
    public TMP_Text cutsceneText;
    private string inputText;

    public GameObject canvas;
    public GameObject bg;
    public Animator animFade;

    void Start()
    {
        StartCoroutine("CutsceneBruh");
        canvas.SetActive(false);
        bg.SetActive(true);
    }

    IEnumerator endCutscene()
    {
        bg.SetActive(false);
        canvas.SetActive(false);
        FindFirstObjectByType<SAudioManager>().Stop("name");
        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        inputText = "Thank you.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}

        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        inputText = "Enjoy your stay.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}

        yield return new WaitForSeconds(2);
        animFade.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Overworld - Geno");
    }

    IEnumerator CutsceneBruh()
    {
        yield return new WaitForSeconds(3);

        cutsceneText.text = "";
        inputText = "Welcome.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}
        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        inputText = "In the next few moments you will spectate a fraction of time from a world different from what's common.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}
        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        inputText = "A world of bad and good where the money tells how much your life truly is worth.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}
        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        inputText = "But, before I allow you to enter, I will need something in return.";
        foreach (char letter in inputText.ToCharArray())
			{
				
				cutsceneText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.045f);
				
			}
        yield return new WaitForSeconds(2);

        cutsceneText.text = "";
        canvas.SetActive(true);
        

    }
}
