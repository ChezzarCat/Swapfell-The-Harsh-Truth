using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacksManager : MonoBehaviour
{

    [Header("MAIN")]
    public turnManager turnManager;
    public Animator papyrusAnims;
    public soulMovement soulMovement;
    public Animator boxAnim;

    [Header("SMOKE RINGS")]
    public GameObject[] smokeRings;
    //0 --> left
    //1 --> middle
    //2 --> both sides
    //3 --> right
    //4 --> middle 2

    [Header("ATTACK 1")]
    public GameObject warningsmokewallAttack1;
    public GameObject smokewallAttack1;
    public GameObject smokewallAttack1UpPart;
    public GameObject smokewallAttack1DownPart;
    public Animator warningArrack1PositionAnim;
    public GameObject smokewall2Attack1;
    public GameObject smokewall2Attack1UpPart;
    public GameObject smokewall2Attack1DownPart;

    [Header("ATTACK 2")]
    public GameObject pileOfBonesAttack2Right;
    public GameObject pileOfBonesAttack2Left;

    [Header("ATTACK 3")]
    public GameObject[] bonesAttack3Right;
    public GameObject[] bonesAttack3Left;
    public GameObject bonesAttack3Last;

    [Header("ATTACK 4")]
    public GameObject pileOfBonesAttack4;

    public IEnumerator StartAttackTest()
    {
        soulMovement.ToggleBlueSoul();
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.5f, 0.9f)
						.setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return null;
    }

    public IEnumerator StartAttack1()
    {
        //smoke rings part

        papyrusAnims.SetTrigger("smokeAttack");
        yield return new WaitForSeconds(1.5f);
        smokeRings[0].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        smokeRings[1].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        smokeRings[2].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        smokeRings[4].SetActive(true);
        yield return new WaitForSeconds(1.3f);
        
        //jump part

        soulMovement.ToggleBlueSoul();
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < smokeRings.Length; i++)
        {
            smokeRings[i].SetActive(false);
        }

        warningArrack1PositionAnim.SetTrigger("Below");
        warningsmokewallAttack1.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        warningsmokewallAttack1.SetActive(false);
        smokewallAttack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");
        
            LeanTween.moveY(smokewallAttack1UpPart, -0.1f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.05f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);

            LeanTween.moveY(smokewallAttack1UpPart, 0.11f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.46f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        warningArrack1PositionAnim.SetTrigger("Right");
        warningsmokewallAttack1.SetActive(true);
                yield return new WaitForSeconds(0.3f);
        warningsmokewallAttack1.SetActive(false);
        smokewallAttack1.SetActive(false);


        smokewall2Attack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");

            LeanTween.moveX(smokewall2Attack1UpPart, 0.43f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
            LeanTween.moveX(smokewall2Attack1DownPart, 0.474f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);

            LeanTween.moveX(smokewall2Attack1UpPart, 0.6f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveX(smokewall2Attack1DownPart, -0.177f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        warningArrack1PositionAnim.SetTrigger("Below");
        warningsmokewallAttack1.SetActive(true);
                yield return new WaitForSeconds(0.3f);
        warningsmokewallAttack1.SetActive(false);
        smokewall2Attack1.SetActive(false);


        smokewallAttack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");

            LeanTween.moveY(smokewallAttack1UpPart, -0.1f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.05f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);

            LeanTween.moveY(smokewallAttack1UpPart, 0.11f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.46f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        warningArrack1PositionAnim.SetTrigger("Left");
        warningsmokewallAttack1.SetActive(true);
                yield return new WaitForSeconds(0.3f);
        warningsmokewallAttack1.SetActive(false);
        smokewallAttack1.SetActive(false);


        smokewall2Attack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");

            LeanTween.moveX(smokewall2Attack1UpPart, 0.0322f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
            LeanTween.moveX(smokewall2Attack1DownPart, 0.0902f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);

            LeanTween.moveX(smokewall2Attack1UpPart, 0.6f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveX(smokewall2Attack1DownPart, -0.177f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        warningArrack1PositionAnim.SetTrigger("Below");
                yield return new WaitForSeconds(0.3f);
        smokewall2Attack1.SetActive(false);


        //LAST PART
    
        soulMovement.ToggleBlueSoul();
        yield return new WaitForSeconds(0.2f);

        int randomNumberlastPartAttack = Random.Range(1, 5);
        warningArrack1PositionAnim.SetTrigger("Random" + randomNumberlastPartAttack);
        warningsmokewallAttack1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        warningsmokewallAttack1.SetActive(false);

        smokewallAttack1.SetActive(true);
        smokewall2Attack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");

        switch (randomNumberlastPartAttack)
        {
            case 1:
                LeanTween.moveY(smokewallAttack1UpPart, -0.395f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveY(smokewallAttack1DownPart, -0.288f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1UpPart, 0.0489f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1DownPart, 0.125f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
            break;

            case 2:
                LeanTween.moveY(smokewallAttack1UpPart, -0.338f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveY(smokewallAttack1DownPart, -0.238f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1UpPart, 0.368f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1DownPart, 0.45f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
            break;

            case 3:
                LeanTween.moveY(smokewallAttack1UpPart, 0.018f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveY(smokewallAttack1DownPart, 0.128f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1UpPart, -0.0337f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1DownPart, 0.0387f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
            break;

            case 4:
                LeanTween.moveY(smokewallAttack1UpPart, -0.0624f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveY(smokewallAttack1DownPart, 0.0389f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1UpPart, 0.408f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1DownPart, 0.487f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
            break;

            //extra in case something fails

            case 5:
                LeanTween.moveY(smokewallAttack1UpPart, -0.395f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveY(smokewallAttack1DownPart, -0.288f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1UpPart, 0.0489f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
                LeanTween.moveX(smokewall2Attack1DownPart, 0.125f, 1f)
                .setEase(LeanTweenType.easeOutQuad);
            break;

        }

        yield return new WaitForSeconds(2.5f);

            LeanTween.moveY(smokewallAttack1UpPart, 0.11f, 1f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.46f, 1f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveX(smokewall2Attack1UpPart, 0.6f, 1f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveX(smokewall2Attack1DownPart, -0.177f, 1f)
            .setEase(LeanTweenType.easeInQuad);

        yield return new WaitForSeconds(2f);
        smokewallAttack1.SetActive(false);
        smokewall2Attack1.SetActive(false);
        turnManager.AfterAttackDialogue();
    }

    public IEnumerator StartAttack2()
    {
        soulMovement.ToggleBlueSoul();
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.5f, 0.9f)
						.setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);
        
        for (int i = 0; i < 6; i++)
        {
            Instantiate(pileOfBonesAttack2Right, new Vector3(1.5f, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(pileOfBonesAttack2Left, new Vector3(-1.85f, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(1f);

        turnManager.ChooseAction();
    }

    public IEnumerator StartAttack3()
    {
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.4f, 0.9f)
						.setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);
        
        for (int i = 0; i < 8; i++)
        {
            int randNum = Random.Range(0, 6);
            if (randNum <= 3)
                Instantiate(bonesAttack3Left[randNum], new Vector3(-1.35f, 0, 0), Quaternion.identity);
            else
                Instantiate(bonesAttack3Left[randNum], new Vector3(-1.35f, 0.015f, 0), Quaternion.identity);

            yield return new WaitForSeconds(1f);
            
            int randNum2 = Random.Range(0, 6);
            if (randNum2 <= 3)
                Instantiate(bonesAttack3Right[randNum2], new Vector3(1, 0, 0), Quaternion.identity);
            else
                Instantiate(bonesAttack3Right[randNum2], new Vector3(1, 0.02f, 0), Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }

        Instantiate(bonesAttack3Last, new Vector3(-1.35f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2f);

        turnManager.ChooseAction();
    }

    public IEnumerator StartAttack4()
    {
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0f, 0.9f)
						.setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);

        warningArrack1PositionAnim.SetTrigger("UpAndDown");
        warningsmokewallAttack1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        warningsmokewallAttack1.SetActive(false);
        smokewallAttack1.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");
        
            LeanTween.moveY(smokewallAttack1UpPart, -0.1f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.25f, 0.6f)
            .setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);
        
        Instantiate(pileOfBonesAttack4, new Vector3(0.5f, 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(13f);
        LeanTween.moveY(smokewallAttack1UpPart, 0.11f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
            LeanTween.moveY(smokewallAttack1DownPart, -0.46f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        yield return new WaitForSeconds(0.3f);
        smokewallAttack1.SetActive(false);

        turnManager.ChooseAction();
    }
    

}
