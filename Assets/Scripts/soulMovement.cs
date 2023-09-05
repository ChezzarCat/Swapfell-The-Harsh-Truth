using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using EZCameraShake;

public class soulMovement : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float moveSpeed = 0.8f;
    public float jumpSpeed = 1f;
    Vector2 movement;
    public bool movementislocked = false;

    [Header("HEALTH")]
    public int maxHealth = 92;
    public int currentHealth; 
    public HealthBar healthBar;

    [Header("OBJECTS")]
    public Rigidbody2D rb;
    public Animator anim;
    public Animator deathAnim;
    public Animator damageShade;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public TMP_Text healthText;
    public TMP_Text recoverText;
    public GameObject healAnim;
    public GameObject deathscreen;
    public GameObject toxinBorder;
    public GameObject toxinText;
    public GameObject attacks;
    public TMP_Text playerName;
    

    [Header("VARIABLES")]
    public bool isblue = false; //blue heart mechanic
    private bool isGrounded;
    public float checkRadius;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private float toxin = 0;
    private float slowmovement = 0;

    private bool hasPlayedDamageSound = true;

    void Start()
    {
        Time.timeScale = 1;
        playerName.text = PlayerPrefs.GetString("InputText");

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        isblue = false;
        movementislocked = true;
        deathscreen.SetActive(false);
        healAnim.SetActive(false);
        toxinBorder.SetActive(false);
        toxinText.SetActive(false);
        attacks.SetActive(true);
        toxin = 0;
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("GAME OVER");
    }

    
    void Update()
    {
        //DELETE BEFORE RELEASE
        if (Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        healthText.text = (currentHealth.ToString());
        healthBar.SetHealth(currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > 92)
            currentHealth = 92;

        if (currentHealth == 0)
        {
            deathAnim.SetTrigger("dies");
            movementislocked = true;
            toxinBorder.SetActive(false);
            toxinText.SetActive(false);
            attacks.SetActive(false);
            FindFirstObjectByType<SAudioManager>().Stop("Ballad of adicts");
            deathscreen.SetActive(true);
            StartCoroutine("LoadGameOver");
            Time.timeScale = 0;
        }

        if (!movementislocked)
        {
            if (Input.GetKey(KeyCode.X))
                slowmovement = 0.3f;
            else
                slowmovement = 0;

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (isblue)
            {                
                movement.x = Input.GetAxisRaw("Horizontal");
                
                if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
                {
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    rb.velocity = Vector2.up * jumpSpeed;
                }

                if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
                {
                    if (jumpTimeCounter > 0)
                    {
                        rb.velocity = Vector2.up * jumpSpeed;
                        jumpTimeCounter -= Time.deltaTime;
                    } else
                    {
                        isJumping = false;
                    }
                    
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    isJumping = false;
                    Vector2 newVelocity = rb.velocity;
                    newVelocity.y = (rb.velocity.y / 2);
                    newVelocity.x = rb.velocity.x;
                    rb.velocity = newVelocity;
                }
                
            } else
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                if (movement.sqrMagnitude > 1)
                    moveSpeed = 0.7f;
                else
                    moveSpeed = 0.8f;

            }
        }

        if (isblue)
            anim.SetBool("isHeartBlue", true);
        else
            anim.SetBool("isHeartBlue", false);

        //palceholder for activating blue heart or desactivating it

        /*if (Input.GetKeyDown(KeyCode.Space) && !movementislocked)
        {
            ToggleBlueSoul();
        }

        if (movementislocked)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = 0;
            newVelocity.x = 0;
            rb.velocity = newVelocity;
        }*/
    }

    public void ToggleBlueSoul()
    {
        if (isblue)
            {
                isblue = false;
                Vector2 newVelocity = rb.velocity;
                newVelocity.y = 0;
                newVelocity.x = 0;
                rb.velocity = newVelocity;
                FindFirstObjectByType<SAudioManager>().Play("Ping2");

            } else if (!isblue)
            {
                isblue = true;
                Vector2 newVelocity = rb.velocity;
                newVelocity.y = 0;
                newVelocity.x = 0;
                rb.velocity = newVelocity;
                FindFirstObjectByType<SAudioManager>().Play("Ping");
            }
    }

    void FixedUpdate()
    {
       if (!movementislocked)
       {
            if (!isblue)
                rb.MovePosition(rb.position + movement * (moveSpeed - toxin - slowmovement) * Time.fixedDeltaTime);
            else
                rb.velocity = new Vector2(movement.x * (moveSpeed - toxin - slowmovement), rb.velocity.y);
       }
            

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!movementislocked)
        {
            if (other.CompareTag("enemies"))
            {
                TakeDamage(8);
            
            }

            if (other.CompareTag("toxic"))
            {
                if (hasPlayedDamageSound)
                {
                    StopCoroutine("intoxicated");
                    StartCoroutine("intoxicated");
                }

                TakeDamage(8);      
            }
        }
       
    }
    

    public void TakeDamage(int damage)
    {
        if (hasPlayedDamageSound)
        {
            currentHealth -= damage;
            StartCoroutine("damageSound");
        }
    }

    public void RestoreHealth(int health)
    {
        currentHealth += health;
        healAnim.SetActive(true);

        int randomIndex = Random.Range(1, 5);

        SAudioManager audioManager = FindFirstObjectByType<SAudioManager>();
        audioManager.Play("Heal" + randomIndex);

        recoverText.text = (health.ToString());
        StartCoroutine("healAnimEnd");
    }

    IEnumerator damageSound()
    {
        
        hasPlayedDamageSound = false;
        damageShade.SetBool("isActive", true);

        if (currentHealth >= 0)
            FindFirstObjectByType<SAudioManager>().Play("Damage");

        CameraShaker.Instance.ShakeOnce(0.5f, 10f, 0f, 0.5f);
        yield return new WaitForSeconds(0.4f);
        hasPlayedDamageSound = true;
        damageShade.SetBool("isActive", false);
        StopCoroutine("damageSound");
        
        
    }

    IEnumerator intoxicated()
    {
        toxinBorder.SetActive(true);
        toxinText.SetActive(true);
        toxin = 0.3f;
        yield return new WaitForSeconds(2f);
        toxinBorder.SetActive(false);
        toxinText.SetActive(false);
        toxin = 0;
    }

    IEnumerator healAnimEnd()
    {
        yield return new WaitForSeconds(3);
        healAnim.SetActive(false);
    }

}
