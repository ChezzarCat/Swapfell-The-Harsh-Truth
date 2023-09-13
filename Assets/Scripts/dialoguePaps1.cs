using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguePaps1 : MonoBehaviour
{
    public dialogue dialogue1;
    public dialogue dialogue1AFTERATTACK;
    public dialogue dialoguefee;
    public dialogue dialogue1ALT;
    public dialogue dialogue1ALT2;
    public dialogue dialogue1REPEAT;

    public dialogue dialogue2;
    public dialogue dialogue3;
    public dialogue dialogue4;
    public dialogue dialogue5;
    public dialogue dialogue6;
    public dialogue dialogue7;
    

    private int currentDeath;

    void Start()
    {
        currentDeath = PlayerPrefs.GetInt("DeathCount");
    }


    public IEnumerator StartDialogue1()
    {
        yield return new WaitForSeconds(3f);
        if (currentDeath == 0)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1);
        else if (currentDeath == 1)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1ALT);
        else if (currentDeath >= 2)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1ALT2);
    }

    public IEnumerator StartDialogue1AFTERATTACK()
    {
        if (currentDeath == 0)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1AFTERATTACK);
        else if (currentDeath == 1)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1REPEAT);
        else if (currentDeath >= 2)
            FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue1REPEAT);
        
        yield return null;
    }

    public IEnumerator StartDialogue2(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue2);
        yield return null;
        
    }

    public IEnumerator StartDialogue3(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue3);
        yield return null;
    }

    public IEnumerator StartDialogue4(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue4);
        yield return null;
    }

    public IEnumerator StartDialogue5(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue5);
        yield return null;
    }

    public IEnumerator StartDialogue6(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue6);
        yield return null;
    }

    public IEnumerator StartDialogue7(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialogue7);
        yield return null;
    }

    public IEnumerator FeeDialogue(){
        FindFirstObjectByType<dialogueManagerBattle>().StartDialogue(dialoguefee);
        yield return null;
    }

}
