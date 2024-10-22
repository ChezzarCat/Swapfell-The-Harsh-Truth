using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class attacksManager : MonoBehaviour
{

    [Header("MAIN")]
    public turnManager turnManager;
    public Animator papyrusAnims;
    public soulMovement soulMovement;
    public Animator boxAnim;
    public GameObject heart;

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

    [Header("ATTACK 5")]
    public GameObject bigPlatformerAttack5;
    public GameObject smokewallAttack5;

    [Header("ATTACK 6")]
    public GameObject cloudsAttack6;

    [Header("ATTACK 7")]
    public GameObject platformAttack7;
    public GameObject prefabCloudAttack7;
    public GameObject smokewallAttack7;

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
        papyrusAnims.SetTrigger("idleFrozen");
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
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.5f, 0.9f).setEase(LeanTweenType.easeInOutQuart);

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
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.4f, 0.9f).setEase(LeanTweenType.easeInOutQuart);

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
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0f, 0.9f).setEase(LeanTweenType.easeInOutQuart);

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

    public IEnumerator StartAttack5()
    {
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 1f, 0.9f).setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);

        soulMovement.ToggleBlueSoul();
        heart.transform.position = new Vector3(-1.313f, -0.223f, -6);
        CameraShaker.Instance.ShakeOnce(0.5f, 10f, 0f, 0.5f);
        bigPlatformerAttack5.SetActive(true);

        smokewallAttack5.transform.position = new Vector2(-1.181f, -0.528f);
            LeanTween.moveX(smokewallAttack5, 1.726f, 11f);

        yield return new WaitForSeconds(11f);
        bigPlatformerAttack5.SetActive(false);

        CameraShaker.Instance.ShakeOnce(0.5f, 10f, 0f, 0.5f);
        soulMovement.ToggleBlueSoul();
        turnManager.ChooseAction();
    }

    public IEnumerator StartAttack6()
    {
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0.2f, 0.9f).setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);

        cloudsAttack6.SetActive(true);

        cloudsAttack6.transform.position = new Vector2(2, 0);
            LeanTween.moveX(cloudsAttack6, -4.8f, 14f);

        yield return new WaitForSeconds(14f);
        cloudsAttack6.SetActive(false);
        turnManager.ChooseAction();
    }

    IEnumerator attack7PlatformMovement()
    {
        while (true)
        {
            LeanTween.moveX(platformAttack7, -0.2f, 2f)
            .setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(2f);
            LeanTween.moveX(platformAttack7, 0.2f, 2f)
            .setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(2f);
        }
        
    }

    public IEnumerator StartAttack7()
    {
        float initialValue = boxAnim.GetFloat("Blend");
					LTDescr tween = LeanTween.value(gameObject, initialValue, 0, 0.9f).setEase(LeanTweenType.easeInOutQuart);

					tween.setOnUpdate((float value) =>
					{
						// Update the float parameter value during the tween
						boxAnim.SetFloat("Blend", value);
					});
        yield return new WaitForSeconds(1f);
        soulMovement.ToggleBlueSoul();
        yield return new WaitForSeconds(0.2f);

        platformAttack7.SetActive(true);
        platformAttack7.transform.position = new Vector2(-1, -0.5f);
        LeanTween.moveX(platformAttack7, 0, 1f)
            .setEase(LeanTweenType.easeOutQuad);

        yield return new WaitForSeconds(0.5f);

        warningArrack1PositionAnim.SetTrigger("Down");
        warningsmokewallAttack1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        warningsmokewallAttack1.SetActive(false);
        smokewallAttack7.SetActive(true);

        FindFirstObjectByType<SAudioManager>().Play("SmokeWall");
        
            LeanTween.moveY(smokewallAttack7, -0.3f, 0.6f).setEase(LeanTweenType.easeOutQuad);
                yield return new WaitForSeconds(0.6f);

        yield return new WaitForSeconds(1f);

        StartCoroutine("attack7PlatformMovement");

        float startTime = Time.time;
        float lastGeneratedX = 0.0f; // Initialize the last X position

        while (Time.time - startTime < 15.0f)
        {
            float randomPosCloudAttack7;
            
            do
            {
                randomPosCloudAttack7 = Random.Range(-0.35f, 0.35f);
            } while (Mathf.Abs(randomPosCloudAttack7 - lastGeneratedX) < 0.1f); // Check the difference

            lastGeneratedX = randomPosCloudAttack7; // Update the last X position
            Instantiate(prefabCloudAttack7, new Vector3(randomPosCloudAttack7, -0.9f, 0), Quaternion.identity);
            
            yield return new WaitForSeconds(0.8f);
        }

        yield return new WaitForSeconds(2f);

        LeanTween.moveY(smokewallAttack7, -0.47f, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
        yield return new WaitForSeconds(0.3f);

        StopCoroutine("attack7PlatformMovement");
        smokewallAttack7.SetActive(false);
        platformAttack7.SetActive(false);
        turnManager.ChooseAction();
    }
    

}
