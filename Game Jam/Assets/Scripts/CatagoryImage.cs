using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatagoryImage : MonoBehaviour
{
    public Catagory thisCatagory;


    private void Start()
    {
        GetComponent<Image>().sprite = thisCatagory.icon;
    }
}
