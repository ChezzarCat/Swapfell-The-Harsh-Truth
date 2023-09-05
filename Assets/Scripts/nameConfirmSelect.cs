using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameConfirmSelect : MonoBehaviour
{
    public Animator anim;
    public InputFieldName inputFieldName;
    private bool isYes = true;

    void Start()
    {
        isYes = true;
    }

    void Update()
    {
        anim.SetBool("isConfirm", isYes);

        if (!inputFieldName.isInCutscene)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                if (isYes)
                {
                    inputFieldName.Confirm();
                }
                else if (!isYes)
                {
                    inputFieldName.Back();
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
}
