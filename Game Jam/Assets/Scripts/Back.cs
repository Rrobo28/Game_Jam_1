using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public PanelHandler panelHandler;
    public bool isRight;
    private void OnMouseDown()
    {
        BackPressed();
    }

    public void BackPressed()
    {
        panelHandler.MainMenu.SetActive(true);
        panelHandler.CatagoryMenu.SetActive(false);
        if (isRight)
        {
            foreach (Transform icon in GameObject.Find("UI").GetComponent<IconManager>().flowerContentRight.transform.GetComponentInChildren<Transform>())
            {
                Destroy(icon.gameObject);
            }
        }
        else
        {
            foreach (Transform icon in GameObject.Find("UI").GetComponent<IconManager>().flowerContentLeft.transform.GetComponentInChildren<Transform>())
            {
                Destroy(icon.gameObject);
            }
        }
    }
}
