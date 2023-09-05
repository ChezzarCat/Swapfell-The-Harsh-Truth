using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenoOverworldCutsceneManager : MonoBehaviour
{
    public PlayableDirector viewToPapsCutscene;
    public GameObject dialogueManager;

    public dialogue dialogue;
    public dialogue dialogue2;
    public dialogue dialogue3;

    private int currentDeath;

    void Awake() 
    {
        dialogueManager.SetActive(false);
    }


    void Start()
    {
        currentDeath = PlayerPrefs.GetInt("DeathCount");
        StartCoroutine("papsCutsceneStart");
    }

    IEnumerator papsCutsceneStart()
    {
        viewToPapsCutscene.Play();
        yield return new WaitForSeconds(7f);
        dialogueManager.SetActive(true);

        if (currentDeath == 0)
            FindFirstObjectByType<dialogueManager>().StartDialogue(dialogue);
        else if (currentDeath == 1)
            FindFirstObjectByType<dialogueManager>().StartDialogue(dialogue2);
        else if (currentDeath >= 2)
            FindFirstObjectByType<dialogueManager>().StartDialogue(dialogue3);
        
    }

    void Update()
    {
        
    }
}
