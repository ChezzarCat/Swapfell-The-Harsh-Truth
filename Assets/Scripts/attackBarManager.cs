using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBarManager : MonoBehaviour
{
    public string currWeapon = "";
    public Animator attackBar;
    public GameObject noweapon;
    public GameObject attackBarObject;


    void Start()
    {
        noweapon.SetActive(false);
        attackBarObject.SetActive(false);
    }

    public IEnumerator Attack()
    {
        attackBarObject.SetActive(true);

        switch(currWeapon)
        {
            case "":
                yield return new WaitForSeconds(1);
                noweapon.SetActive(true);
                yield return new WaitForSeconds(2);
                FindFirstObjectByType<turnManager>().NextTurn();
                noweapon.SetActive(false);
            break;
        }

        attackBar.SetTrigger("barLeave");
        yield return new WaitForSeconds(2);
        attackBarObject.SetActive(false);
    }
}
