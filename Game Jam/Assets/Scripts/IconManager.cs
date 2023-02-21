using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct ItemPair
{
    public Item item1;
    public Item item2;

    public ItemPair(Item first,Item second)
    {
        item1 = first;
        item2 = second;
    }
    
}

public class IconManager : MonoBehaviour
{
    [Header("Known Items")]
    public List<Item> flowerItemsKnown = new List<Item>();
    public List<Item> animalItemsKnown = new List<Item>();
    public List<Item> potionItemsKnown = new List<Item>();
    public List<Item> gemItemsKnown = new List<Item>();
    public List<Item> createdItems = new List<Item>();
    public List<Catagory> catagorysKnown = new List<Catagory>();

    [Header("All Items")]
    public Item[] flowerItemsAll;
    public Item[] animalItemsAll;
    public Item[] gemItemsAll;
    public Catagory[] catagoryAll;

    public GameObject flowerContentLeft;
    public GameObject flowerContentRight;

    public GameObject catagoryContentLeft;
    public GameObject catagoryContentRight;

    public Image iconImage;
    public Image catagoryImage;
   
   

    private void Awake()
    {
        for(int i = 0; i < 1; i++)
        {
            flowerItemsKnown.Add(flowerItemsAll[i]);
            animalItemsKnown.Add(animalItemsAll[i]);
            gemItemsKnown.Add(gemItemsAll[i]);
            
        }
        for (int i = 0; i < 4; i++)
        {
            catagorysKnown.Add(catagoryAll[i]);

        }
        UpdateKnownCatagorys();
    }

    private void UpdateKnownCatagorys()
    {
        foreach (Catagory catagory in catagorysKnown)
        {
            Image newIcon = Instantiate(catagoryImage, catagoryContentLeft.transform.position, catagoryContentLeft.transform.rotation);

            newIcon.transform.parent = catagoryContentLeft.transform;

            newIcon.GetComponent<CatagoryImage>().thisCatagory = catagory;

            Image newIcon2 = Instantiate(catagoryImage, catagoryContentRight.transform.position, catagoryContentRight.transform.rotation);

            newIcon2.transform.parent = catagoryContentRight.transform;

            newIcon2.GetComponent<CatagoryImage>().thisCatagory = catagory;
        }
    }


    public void UpdateKnown(Catagory.CatagoryType type,bool side)
    {
        List<Item> currentList = new List<Item>();
        switch (type)
        { 
            case Catagory.CatagoryType.Flower:
                currentList = flowerItemsKnown;
                break;
            case Catagory.CatagoryType.Animal:
                currentList = animalItemsKnown;
                break;
            case Catagory.CatagoryType.Gem:
                currentList = gemItemsKnown;
                break;
            case Catagory.CatagoryType.Potion:
                currentList = potionItemsKnown;
                break;

        }

        foreach (Item item in currentList)
        {
            GameObject content;
            if (side)
                content = flowerContentLeft;
            else
                content = flowerContentRight;

            Image newIcon = Instantiate(iconImage, content.transform.position, content.transform.rotation);

            newIcon.transform.parent = content.transform;

            newIcon.GetComponent<IconImage>().thisItem = item;

            if (side)
                newIcon.GetComponent<ClickHandler>().currentSide = ClickHandler.side.Left;
            else
            {
                newIcon.GetComponent<ClickHandler>().currentSide = ClickHandler.side.Right;
            }
        }

    }

    public void ClearKnown()
    {
        for(int i =0; i< flowerContentLeft.transform.childCount; i++)
        {
            Destroy(flowerContentLeft.transform.GetChild(i).gameObject);
        }
    }
   
}
