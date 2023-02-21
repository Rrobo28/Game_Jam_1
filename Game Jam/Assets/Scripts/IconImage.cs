using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IconImage : MonoBehaviour
{
   public Item thisItem;

    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        GetComponent<Image>().sprite = thisItem.icon;
        textMeshProUGUI.text = thisItem.name;
    }
}
