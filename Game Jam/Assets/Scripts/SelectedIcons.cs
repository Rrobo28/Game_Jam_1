using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectedIcons : MonoBehaviour
{
    public GameObject rightSelection;
    public GameObject leftSelection;

    public GameObject combinationPanel,panel1,panel2,panel3,panel4;
    public Image image1,image2,image3; 

    Dictionary<ItemPair, Item> combinations = new Dictionary<ItemPair, Item>();

    public ItemPair[] AllItemPairs;
    public Item[] AllCombinations;

    public Vector3 pos1, pos2;

    public TextMeshProUGUI textMeshProUGUI;

    bool animStarted = false;

    private void Start()
    {
        for (int i = 0; i < AllItemPairs.Length; i++)
        {
            combinations[AllItemPairs[i]] = AllCombinations[i];
        }

        pos1 = image1.transform.position;
        pos2 = image2.transform.position;
    }

    private void Update()
    {
        if(rightSelection != null && leftSelection != null)
        {
            if(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem) != null && !GetComponent<IconManager>().createdItems.Contains( ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem)))
            {
                combinationPanel.SetActive(true);
                panel2.SetActive(false);
                panel1.SetActive(false);
                image1.sprite = rightSelection.GetComponent<IconImage>().thisItem.icon;
                image2.sprite = leftSelection.GetComponent<IconImage>().thisItem.icon;
                image3.sprite = ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem).icon;

               
               
                textMeshProUGUI.text = ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem).name;
                foreach (GameObject button in GameObject.FindGameObjectsWithTag("Back"))
                {
                    button.GetComponent<Back>().BackPressed();
                }
                if (!animStarted)
                {
                    StartCoroutine(Animation());
                   
                    image1.transform.position = Vector3.Lerp(image1.transform.position, new Vector3(image1.transform.position.x, image1.transform.position.y, image1.transform.position.z - 0.4f), Time.deltaTime);
                    image2.transform.position = Vector3.Lerp(image2.transform.position, new Vector3(image2.transform.position.x, image2.transform.position.y, image2.transform.position.z + 0.4f), Time.deltaTime);
                }
               
            }
            else
            {
                rightSelection.GetComponent<ClickHandler>().isSelected = false;
                leftSelection.GetComponent<ClickHandler>().isSelected = false;
                rightSelection = null;
                leftSelection = null;
                //Play Sound
            }
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.5f);

        animStarted = true;

        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);

        image3.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        if (rightSelection != null && leftSelection != null)
        {
            GetComponent<IconManager>().createdItems.Add(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem));
            switch (ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem).itemCatagory)
            {

                case Item.catagory.flower:
                    GetComponent<IconManager>().flowerItemsKnown.Add(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem));
                    break;
                case Item.catagory.animal:
                    GetComponent<IconManager>().animalItemsKnown.Add(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem));
                    break;
                case Item.catagory.gem:
                    GetComponent<IconManager>().gemItemsKnown.Add(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem));
                    break;
                case Item.catagory.potion:
                    GetComponent<IconManager>().potionItemsKnown.Add(ConbinationCheck(rightSelection.GetComponent<IconImage>().thisItem, leftSelection.GetComponent<IconImage>().thisItem));
                    break;
            }
        }

        ResetUI();

    }

    Item ConbinationCheck(Item i1,Item i2)
    {
        ItemPair pair = new ItemPair(i1, i2);

        if (combinations.ContainsKey(pair))
        {
            return combinations[pair];
        }
        else
        {
            pair = new ItemPair(i2, i1);
            if (combinations.ContainsKey(pair))
            {
                return combinations[pair];
            }
            else
            {
                return null;
            }
        }
    }

    void ResetUI()
    {
        rightSelection = null;
        leftSelection = null;

        panel1.SetActive(true);
        panel2.SetActive(true);

        panel3.GetComponent<Back>().BackPressed();
        panel4.GetComponent<Back>().BackPressed();

        image3.gameObject.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);

        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);

        animStarted = false;

        image1.transform.position = pos1;
        image2.transform.position = pos2;

        combinationPanel.SetActive(false);
    }
}
