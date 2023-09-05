using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    [Header("CURRENT TURN")]
    public int currTurn = 1;

    [Header("SCRIPTS")]
    public playerTextManager playerTextManager;
    public stateManager stateManager;
    public dialoguePaps1 dialoguePaps;
    public attacksManager attacksManager;


    private bool repeatsTurn = false;
    private bool feeDialogue = false;
    private bool afterAttack = false;

    void Start() //preloading fucking audio LOL
    {
        FindFirstObjectByType<SAudioManager>().Play("Ballad of adicts");
        FindFirstObjectByType<SAudioManager>().Stop("Ballad of adicts");
        StartTurn();
    }

    void Update()
    {
        switch (currTurn)
        {
            case 1:
                playerTextManager.phase = 0;
                break;
            
            case 2:
                playerTextManager.phase = 1;
                break;
        }
    }

    public void StartTurn()
    {
        stateManager.playerTurn = true;
        stateManager.hasChangedState = false;
        stateManager.hasSelected = false;

        if (!repeatsTurn)
        {
            switch (currTurn)
            {
                case 1:
                    dialoguePaps.StartCoroutine("StartDialogue1");
                    break;
                case 2:
                    dialoguePaps.StartCoroutine("StartDialogue2");
                    break;
                case 3:
                    dialoguePaps.StartCoroutine("StartDialogue3");
                    break;
                case 4:
                    dialoguePaps.StartCoroutine("StartDialogue4");
                    break;
            }
        }
        else
        {
            NextAttack();
        }
        
    }

    public void NextAttack()
    {
        if (!afterAttack)
        {
            if (!feeDialogue)
            {
                FindFirstObjectByType<soulMovement>().movementislocked = false;
                switch (currTurn)
                {
                    case 1:
                        attacksManager.StartCoroutine("StartAttack1");
                        break;
                    case 2:
                        attacksManager.StartCoroutine("StartAttack2");
                        break;
                    case 3:
                        attacksManager.StartCoroutine("StartAttack3");
                        break;
                    case 4:
                        attacksManager.StartCoroutine("StartAttack4");
                        break;
                }
            }
            else
            {
                feeDialogue = false;
                StartCoroutine("FeeDialogueEnd");
            }
        }
        else
        {
            afterAttack = false;
            StartCoroutine("AfterAttackDialogueEnd");
        }
        
        
    }

    public void ChooseAction()
    {
        FindFirstObjectByType<stateManager>().isfirstturn = true;
        FindFirstObjectByType<soulMovement>().isblue = false;
        stateManager.playerTurn = false;
        stateManager.hasChangedState = false;
    }

    public void RepeatTurn()
    {
        stateManager.isRepeatTurn = true;

        if (currTurn == 1)
        {
            stateManager.playerTurn = true;
            stateManager.hasChangedState = false;
            stateManager.hasSelected = false;
            FindFirstObjectByType<soulMovement>().movementislocked = false;
            attacksManager.StartCoroutine("StartAttack2");
        }
        else
        {
            repeatsTurn = true;
            StartTurn();
        }
        
    }

    public void FeeDialogue()
    {
        feeDialogue = true;
        stateManager.playerTurn = true;
        stateManager.hasChangedState = false;
        stateManager.hasSelected = false;
        dialoguePaps.StartCoroutine("FeeDialogue");
    }

    IEnumerator FeeDialogueEnd()
    {
        yield return new WaitForSeconds(0.1f);
        ChooseAction();
        StopAllCoroutines();
    }

    public void AfterAttackDialogue()
    {
        afterAttack = true;
        dialoguePaps.StartCoroutine("StartDialogue1AFTERATTACK");
    }

    IEnumerator AfterAttackDialogueEnd()
    {
        yield return new WaitForSeconds(0.1f);
        FindFirstObjectByType<SAudioManager>().Play("Ballad of adicts");
        ChooseAction();
        StopAllCoroutines();
    }

    public void NextTurn()
    {
        repeatsTurn = false;
        currTurn++;
        StartTurn();
    }
}
