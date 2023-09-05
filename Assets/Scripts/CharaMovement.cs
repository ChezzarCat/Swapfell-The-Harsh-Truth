using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMovement : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    [Header("OBJECTS")]
    public GameObject cutsceneTrigger;
    public GameObject dialogueManager;
    public GameObject savepointtextbox;
    public GameObject triggercollider;

    public bool movementislocked = false;

    Vector2 movement;
    Vector2 lastmovement;
    public dialogue dialogue;

    void Start ()
    {
        FindFirstObjectByType<SAudioManager>().Play("Rain");
        movementislocked = false;
        cutsceneTrigger.SetActive(false);
        dialogueManager.SetActive(false);
        triggercollider.SetActive(true);
    }

    void Update()
    {
        if (!movementislocked)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //so it stays at the position it was walking at when stopping

            if (movement.sqrMagnitude > 0)
            {
                lastmovement.x = movement.x;
                lastmovement.y = movement.y;
            }

            //fix so chara moves at the same speed when moving in diagonal and doesn't duplicate both x and y speed

            if (movement.sqrMagnitude == 2)
                moveSpeed = 0.9f;
            else
                moveSpeed = 1f;


            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetFloat("LastHorizontal", lastmovement.x);
            animator.SetFloat("LastVertical", lastmovement.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        
    }

    void FixedUpdate() 
    {
        if (!movementislocked)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DownExit"))
        {
            animator.SetFloat("Speed", 0f);
            movementislocked = true;
            FindFirstObjectByType<dialogueManagerleave>().StartDialogue(dialogue);
        }
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!movementislocked)
        {
            if (other.CompareTag("savepoint") && Input.GetKey(KeyCode.Z))
            {
                triggercollider.SetActive(false);
                movementislocked = true;
                animator.SetFloat("Speed", 0f);
                savepointtextbox.SetActive(true);
                movementislocked = true;
            
            }

            if (other.CompareTag("GameController"))
            {
                animator.SetFloat("Speed", 0f);
                animator.SetTrigger("lookup");
                movementislocked = true;
                cutsceneTrigger.SetActive(true);
            }
        }
       
    }

    /*IEnumerator opensavebox()
    {
        //yield return new WaitForSeconds(0.1f);
        
    }*/

    public IEnumerator starttriggeragain()
    {
        yield return new WaitForSeconds(0.3f);
        triggercollider.SetActive(true);
    }   
    
}
