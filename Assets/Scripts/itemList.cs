using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemList : MonoBehaviour
{
    public List<string> currItemName = new List<string>
    {
        "* Pie", "* Pie", "* Pie", "* Pie", "* Pie",
        "* Pie", "* Pie", "* Pie"
    };
    public TMP_Text[] currTextItem;
    public List<int> itemNumber = new List<int> {0, 1, 2, 3, 4, 5, 6, 7};
    public int currItem = 0;
    public string selectedName = "";
    public TMP_Text TMPselectedNameDescription;
    public string selectedNameDescription = "";
    public GameObject scroller;
    public Animator itemIcon;

    public int itemsInTotal = 8;

    private bool hasFinishedscrolling = false;
    private float initialYpositionScroller;

    void Start()
    {
        itemIcon.SetTrigger(selectedName);
        initialYpositionScroller = scroller.transform.position.y;

        currTextItem[0].color = new Color(39 / 255f, 47 / 255f, 168 / 255f, 255 / 255f);

        for (int i = 0; i <= (itemsInTotal - 1); i++) 
        {
            currTextItem[itemNumber[i]].text = currItemName[i].ToString();
        }

        selectedName = currItemName[0];
    }

    void Update()
    {
        if (itemsInTotal >= 0)
        {
            itemIcon.SetTrigger(selectedName);
        }
        else
        {
            itemIcon.SetTrigger("none");
        }
    
        if (Input.GetKeyDown(KeyCode.UpArrow) && currItem > 0 && !hasFinishedscrolling)
        {
            MoveSelection(-1);
            StopAllCoroutines();
            StartCoroutine("ResetSelectedItemText");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currItem < (itemsInTotal - 1) && !hasFinishedscrolling)
        {
            MoveSelection(1);
            StopAllCoroutines();
            StartCoroutine("ResetSelectedItemText");
        }

        else if (Input.GetKeyDown(KeyCode.Z) && itemsInTotal >= 0 && currItemName.Count != 0)
        {
            switch (selectedName)
            {
                case "* Hot cocoa":
                    FindFirstObjectByType<soulMovement>().RestoreHealth(90);

                break;

                case "* Hip-Pop Candy Bar":
                    FindFirstObjectByType<soulMovement>().RestoreHealth(60);

                break;

                case "* Leftovers":
                    FindFirstObjectByType<soulMovement>().RestoreHealth(40);

                break;

                case "* Night glowing crunch":
                    FindFirstObjectByType<soulMovement>().RestoreHealth(15);

                break;

                case "* 10 in 1 War Pack":
                    int randomNumber = Random.Range(10, 91);
                    FindFirstObjectByType<soulMovement>().RestoreHealth(randomNumber);

                break;
            }

            FindFirstObjectByType<SAudioManager>().Play("Accept");

            FindFirstObjectByType<stateManager>().UIoptions.SetTrigger("idleUI");
            FindFirstObjectByType<stateManager>().StartCoroutine("ConsumeItem", selectedName);
            RemoveSelectedItem();

            FindFirstObjectByType<stateManager>().itemList.SetActive(false);
            
        }

        if (currItem > itemsInTotal)
        {
            ResetSelectionToStart();
        }

    }

    void RemoveSelectedItem()
        {
            currItemName.RemoveAt(currItem);
            if (itemsInTotal > 0)
                itemsInTotal--;

            if (currItem >= currItemName.Count)
                currItem = currItemName.Count - 1;

            for (int i = 0; i < currItemName.Count; i++)
            {
                currTextItem[i].text = currItemName[itemNumber[i]];
            }

            currTextItem[currItemName.Count].text = "";

            UpdateSelectedName();

            if (itemsInTotal > 0)
            {
                ResetSelectionToStart();
            }
        }


        void MoveSelection(int direction)
        {
            UpdateTextColors();

            currItem += direction;
            currTextItem[currItem].color = new Color(39 / 255f, 47 / 255f, 168 / 255f, 255 / 255f);

            hasFinishedscrolling = true;
            FindFirstObjectByType<SAudioManager>().Play("Select");

            float initialY = scroller.transform.position.y;
            float targetY = initialY + (0.163f * direction);
            LeanTween.moveY(scroller, targetY, 0.1f)
                .setEase(LeanTweenType.easeInOutQuad)
                .setOnComplete(() =>
                {
                    hasFinishedscrolling = false;
                });

            UpdateSelectedName();
        }

        void UpdateTextColors()
        {
            foreach (TMP_Text item in currTextItem)
            {
                item.color = new Color(74 / 255f, 70 / 255f, 94 / 255f, 255 / 255f);
            }
        }

        void UpdateSelectedName()
        {
            if (itemsInTotal > 1)
            {
                selectedName = currItemName[itemNumber[currItem]];
                StopAllCoroutines();
                StartCoroutine("ResetSelectedItemText");
            }
            else
            {
                selectedName = "";
                TMPselectedNameDescription.text = "";
            }
        }

        public void ResetSelectionToStart()
        {
            if (itemsInTotal > 0)
            {
                currItem = 0;
                UpdateTextColors();
                UpdateSelectedName();

                LeanTween.moveY(scroller, initialYpositionScroller, 0.1f)
                    .setEase(LeanTweenType.easeInOutQuad);

                currTextItem[currItem].color = new Color(39 / 255f, 47 / 255f, 168 / 255f, 255 / 255f);
            }
            else
            {
                currItem = -1; // No items left
                UpdateSelectedName();
            }

        }

        public IEnumerator ResetSelectedItemText()
        {
            TMPselectedNameDescription.text = "";

            switch (selectedName)
            {
                case "* Hot cocoa":
                    selectedNameDescription = "+90HP";

                break;

                case "* Hip-Pop Candy Bar":
                    selectedNameDescription = "+60HP";

                break;

                case "* Leftovers":
                    selectedNameDescription = "+40HP";

                break;

                case "* Night glowing crunch":
                    selectedNameDescription = "+15HP / 4 TURNS";

                break;

                case "* 10 in 1 War Pack":
                    selectedNameDescription = "+10HP / +90HP";

                break;

                case "":
                    selectedNameDescription = "";

                break;
            }

            foreach (char letter in selectedNameDescription.ToCharArray())
			{
				
				TMPselectedNameDescription.text += letter;
				yield return new WaitForSeconds(0.04f);
				
			}
        }

        
}
