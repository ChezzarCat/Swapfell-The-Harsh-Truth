using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class savepoint : MonoBehaviour
{
    public Animator animator;
    public CharaMovement chara;
    private bool isreturn = true;
    private bool hassaved = false;
    private bool isabletopress = false;

    public TMP_Text saveName;

    void Start()
    {
        isreturn = true;
        saveName.text = PlayerPrefs.GetString("InputText");
    }

    void Update()
    {
        StartCoroutine("canpress");

        if (isabletopress == true)
        {
            if (!hassaved)
            {
                if (!isreturn)
                    animator.SetBool("returned", true);

                if (isreturn)
                    animator.SetBool("returned", false);

                if (Input.GetKeyDown(KeyCode.RightArrow) && isreturn)
                {
                    isreturn = false;
                    FindFirstObjectByType<SAudioManager>().Play("Select");
                }
                
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isreturn)
                {
                    isreturn = true;
                    FindFirstObjectByType<SAudioManager>().Play("Select");
                }


                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (!isreturn)
                    {
                        chara.movementislocked = false;
                        isreturn = true;
                        isabletopress = false;
                        animator.SetBool("returned", false);
                        chara.StartCoroutine("starttriggeragain");
                        chara.savepointtextbox.SetActive(false);
                    } 
                    else if (isreturn)
                    {
                        animator.SetTrigger("savepoint");
                        FindFirstObjectByType<SAudioManager>().Play("Save");
                        chara.movementislocked = true;
                        StartCoroutine("cansave");
                    }
                }
            }
            else if (hassaved)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    hassaved = false;
                    isabletopress = false;
                    chara.StartCoroutine("starttriggeragain");
                    chara.movementislocked = false;
                    chara.savepointtextbox.SetActive(false);
                }
            }
        }
    }

    IEnumerator cansave()
    {
        yield return new WaitForSeconds(0.02f);
        hassaved = true;
    }

    IEnumerator canpress()
    {
        yield return new WaitForSeconds(0.02f);
        isabletopress = true;
    }
}
