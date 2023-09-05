using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stateManager : MonoBehaviour
{
	[Header("MAIN STUFF")]
	public Animator UIoptions;
	public Animator box;

	public bool playerTurn;

	public GameObject heart;
    public BoxCollider2D heartCollider;
	public playerTextManager playerTextManager;

	private float buttons = -1;

	public bool isfirstturn = true;
    public bool hasChangedState = false;
	public bool hasSelected = false;
	public bool isAttacking = false;
	public bool isRepeatTurn = false;
	private bool isDealing = false;
	private bool isWritting = false;
	private bool isWrittingCheck = false;
	private bool isEating = false;
	private bool skipWritting = false;
	

	private string ItemText1;
	private string ItemText2;
	private string ItemText3;

	[Header("SUBOPTIONS GAMEOBJECTS")]
	public GameObject fightText;
	public GameObject actText;
	public GameObject feeText;
	public TMP_Text checkText;
	public TMP_Text checkText2;
	public TMP_Text checkText3;
	public GameObject itemList;

    void Start()
    {
		isfirstturn = true;
        playerTurn = true;
        heartCollider.isTrigger = false;

		fightText.SetActive(false);
		feeText.SetActive(false);

		
    }

    void Update()
    {
    	//button animations

		if (!hasSelected)
		{
			switch (buttons)
			{
				case -1:
					UIoptions.SetTrigger("idleUI");
					break;
				case 1:
					UIoptions.SetTrigger("fightUI");
					heart.transform.position = new Vector3(-1.42f, -1.13f, -6);
					break;
				case 2:
					UIoptions.SetTrigger("dealUI");
					heart.transform.position = new Vector3(-0.61f, -1.13f, -6);
					break;
				case 3:
					UIoptions.SetTrigger("itemUI");
					heart.transform.position = new Vector3(0.19f, -1.13f, -6);
					break;
				case 4:
					UIoptions.SetTrigger("feeUI");
					heart.transform.position = new Vector3(1, -1.13f, -6);
					break;
			}
		}
    	

    	//ENEMY TURN

	        if (playerTurn)
	        {
	        	buttons = -1;
                heartCollider.isTrigger = false;

                if (!hasChangedState)
                {
                    heart.transform.position = new Vector3(0, -0.4f, -6);

					if (!isRepeatTurn)
					{
						float initialValue = box.GetFloat("Blend");
						LTDescr tween = LeanTween.value(gameObject, initialValue, 0, 0.9f)
							.setEase(LeanTweenType.easeInOutQuart);

						tween.setOnUpdate((float value) =>
						{
							// Update the float parameter value during the tween
							box.SetFloat("Blend", value);
						});

					}
					isRepeatTurn = false;

                    hasChangedState = true;
					playerTextManager.StopAllCoroutines();
					playerTextManager.DeleteText();
                }
                

	        	
	        } 

	    //PLAYER TURN

	        else
	        {
                if (!hasChangedState)
                {
					FindFirstObjectByType<soulMovement>().isblue = false;
					Vector2 newVelocity = FindFirstObjectByType<soulMovement>().rb.velocity;
					newVelocity.y = 0;
					newVelocity.x = 0;
					FindFirstObjectByType<soulMovement>().rb.velocity = newVelocity;
					isAttacking = false;
                    
					float initialValue = box.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 1, 0.9f)
						.setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						box.SetFloat("Blend", value);
					});

					FindFirstObjectByType<soulMovement>().movementislocked = true;
                    hasChangedState = true;
					playerTextManager.StartCoroutine("WriteText");
					
                }
	        	
                heartCollider.isTrigger = true;

				if (!isAttacking && !isfirstturn)
				{
					if (Input.GetKeyDown(KeyCode.LeftArrow) && !hasSelected)
					{
						buttons--;
						FindFirstObjectByType<SAudioManager>().Play("Select");
					}

					else if (Input.GetKeyDown(KeyCode.RightArrow) && !hasSelected)
					{
						buttons++;
						FindFirstObjectByType<SAudioManager>().Play("Select");
					}


					else if (Input.GetKeyDown(KeyCode.Z) && !hasSelected)
					{
						StopAllCoroutines();
						StartCoroutine("selecting");
						
					}

					else if (Input.GetKeyDown(KeyCode.X) && hasSelected && !isEating)
					{
						hasSelected = false;
						playerTextManager.StopAllCoroutines();
						playerTextManager.StartCoroutine("WriteTextNoDelay");

						switch (buttons)
						{
							case 1:
								heart.transform.position = new Vector3(-1.42f, -1.13f, -6);
								fightText.SetActive(false);
								break;
							case 2:
								heart.transform.position = new Vector3(-0.61f, -1.13f, -6);
								fightText.SetActive(false);
								break;
							case 4:
								heart.transform.position = new Vector3(1, -1.13f, -6);
								feeText.SetActive(false);
								break;
							case 3:
								heart.transform.position = new Vector3(0.19f, -1.13f, -6);
								itemList.SetActive(false);
								break;
						}
					}

					else if (Input.GetKeyDown(KeyCode.Z) && hasSelected)
					{
						switch (buttons)
						{
							case 1:
								heart.transform.position = new Vector3(-3f, -1.13f, -6);
								fightText.SetActive(false);
								UIoptions.SetTrigger("idleUI");
								isAttacking = true;
								FindFirstObjectByType<SAudioManager>().Play("Accept");
								FindFirstObjectByType<attackBarManager>().StartCoroutine("Attack");
								break;
							case 2:
								StopAllCoroutines();
								StartCoroutine("selectingCheck");
								break;
							case 4:
								heart.transform.position = new Vector3(-3f, -1.13f, -6);
								feeText.SetActive(false);
								UIoptions.SetTrigger("idleUI");
								isAttacking = true;
								FindFirstObjectByType<SAudioManager>().Play("Accept");
								FindFirstObjectByType<turnManager>().FeeDialogue();
								break;
							case 3:
								//heart.transform.position = new Vector3(1, -1.13f, -6);
								break;
						}
					}

					
				}

				if (Input.GetKeyDown(KeyCode.Z) && isDealing && !isWrittingCheck && !isWritting)
				{
					FindFirstObjectByType<SAudioManager>().Play("Accept");
					actText.SetActive(false);
					heart.transform.position = new Vector3(-3f, -1.13f, -6);
					StartCoroutine("Check");
				}

				else if (Input.GetKeyDown(KeyCode.X) && isDealing && !isWrittingCheck && !isWritting)
				{
					isDealing = false;
					isAttacking = false;
					fightText.SetActive(true);
					actText.SetActive(false);

				}

				else if (Input.GetKeyDown(KeyCode.Z) && isDealing && isWrittingCheck && !isWritting)
				{
					checkText.text = "";
					checkText2.text = "";
					checkText3.text = "";
					UIoptions.SetTrigger("idleUI");
					FindFirstObjectByType<turnManager>().RepeatTurn();
					isDealing = false;
					isWrittingCheck = false;
				}

				else if (Input.GetKeyDown(KeyCode.Z) && isEating && !isWritting)
				{
					checkText.text = "";
					checkText2.text = "";
					checkText3.text = "";
					FindFirstObjectByType<turnManager>().RepeatTurn();
					isEating = false;
				}

				else if (Input.GetKeyDown(KeyCode.X) && isEating && isWritting && !skipWritting)
					skipWritting = true;


	        	


	        	if (buttons > 4)
	        	{
	        		buttons = 1;
	        	}

	        	if (buttons == 0)
	        	{
	        		buttons = 4;
	        	}

	        	if (buttons == -1)
	        	{
	        		buttons = 1;
	        	}

	        }
    }

	IEnumerator selecting()
	{
		yield return new WaitForSeconds(0.01f);
		hasSelected = true;
		playerTextManager.StopAllCoroutines();
		playerTextManager.DeleteText();
		FindFirstObjectByType<SAudioManager>().Play("Accept");

		switch (buttons)
			{
				case 1:
					heart.transform.position = new Vector3(-1.35f, -0.215f, -6);
					fightText.SetActive(true);
					break;
				case 2:
					heart.transform.position = new Vector3(-1.35f, -0.215f, -6);
					fightText.SetActive(true);
					break;
				case 4:
					heart.transform.position = new Vector3(-1.35f, -0.215f, -6);
					feeText.SetActive(true);
					break;
				case 3:
					heart.transform.position = new Vector3(-1.35f, -0.215f, -6);
					itemList.SetActive(true);
					FindFirstObjectByType<itemList>().StopAllCoroutines();
            		FindFirstObjectByType<itemList>().StartCoroutine("ResetSelectedItemText");
					break;
			}
	}

	IEnumerator selectingCheck()
	{
		yield return new WaitForSeconds(0.01f);
		FindFirstObjectByType<SAudioManager>().Play("Accept");
		fightText.SetActive(false);
		actText.SetActive(true);
		isAttacking = true;
		isDealing = true;
	}

	IEnumerator Check()
	{
		isWritting = true;
		isWrittingCheck = true;

		checkText.text = "";
		checkText2.text = "";
		checkText3.text = "";
        foreach (char letter in "* PAPYRUS 20 ATK 10 DEF".ToCharArray())
			{
				
				checkText.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.04f);
				
			}
		foreach (char letter in "* Hateful.".ToCharArray())
			{
				
				checkText2.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.04f);
				
			}
		foreach (char letter in "".ToCharArray())
			{
				
				checkText3.text += letter;
				FindFirstObjectByType<SAudioManager>().Play("Default Text2");
				yield return new WaitForSeconds(0.04f);
				
			}

		isWritting = false;
	}

	IEnumerator ConsumeItem(string selectedName)
	{
		heart.transform.position = new Vector3(-3f, -1.13f, -6);

		isEating = true;
		isWritting = true;

		checkText.text = "";
		checkText2.text = "";
		checkText3.text = "";


		switch (selectedName)
		{
			case "* Hot cocoa":
                ItemText1 = "* You drink the hot cocoa.";
				ItemText2 = "* Tastes sweet, like home.";
				ItemText3 = "* You restored 90 HP.";

            break;

            case "* Hip-Pop Candy Bar":
                ItemText1 = "* You eat the candy bar.";
				ItemText2 = "* A rave in a package.";
				ItemText3 = "* You restored 60 HP.";

            break;

            case "* Leftovers":
                ItemText1 = "* You eat the leftovers.";
				ItemText2 = "* Slightly expired, but not bad.";
				ItemText3 = "* You restored 40 HP.";

            break;

            case "* Night glowing crunch":
                ItemText1 = "* You eat the glowing crunch.";
				ItemText2 = "* Your stomach glows a little.";
				ItemText3 = "* You restored 15 HP.";

            break;

            case "* 10 in 1 War Pack":
                ItemText1 = "* You eat the 10 in 1 War Pack.";
				ItemText2 = "* Tasted like the 20s.";
				ItemText3 = "* You restored a random HP.";

            break;
		}
			

        foreach (char letter in ItemText1.ToCharArray())
			{
				if (skipWritting)
				{
					checkText.text = ItemText1;
				}
				else
				{
					checkText.text += letter;
					FindFirstObjectByType<SAudioManager>().Play("Default Text2");
					yield return new WaitForSeconds(0.04f);
				}
				
			}
		foreach (char letter in ItemText2.ToCharArray())
			{
				if (skipWritting)
				{
					checkText2.text = ItemText2;
				}
				else
				{
					checkText2.text += letter;
					FindFirstObjectByType<SAudioManager>().Play("Default Text2");
					yield return new WaitForSeconds(0.04f);
				}
				
			}

		if (FindFirstObjectByType<soulMovement>().currentHealth == FindFirstObjectByType<soulMovement>().maxHealth)
		{
			ItemText3 = "* Your HP was maxed out.";
			print("isfull");
		}

		foreach (char letter in ItemText3.ToCharArray())
			{
				if (skipWritting)
				{
					checkText3.text = ItemText3;
				}
				else
				{
					checkText3.text += letter;
					FindFirstObjectByType<SAudioManager>().Play("Default Text2");
					yield return new WaitForSeconds(0.04f);
				}
				
			}

		isWritting = false;
		skipWritting = false;
		
	}
    	
    
}
