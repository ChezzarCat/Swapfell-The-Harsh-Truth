using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GenoOverworldCutsceneManager2 : MonoBehaviour
{
    public dialogue dialogue;

    void Start()
    {
        FindFirstObjectByType<dialogueManager>().StartDialogue(dialogue);
    }

}