using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickHandler : MonoBehaviour
{
    public bool isCategory = false;
    public static GameObject currentPanel;
    public GameObject panel;
    public GameObject mainPanel;
    public bool isSelected = false;

    public  bool isHovered = false;

    public static bool leftSelected;
    public static bool rightSelected;

    public GameObject image;

    public enum side { Right,Left}
    public side currentSide;
    private void Start()
    {
        if (!isCategory)
            return;

        image = GetComponentInParent<PanelHandler>().catagoryImage;
        panel = GetComponentInParent<PanelHandler>().CatagoryMenu;
        mainPanel = GetComponentInParent<PanelHandler>().MainMenu;
    }
    private void OnMouseEnter()
    {
        isHovered = true;
       
    }
    private void OnMouseExit()
    {
        isHovered = false;
        
    }

    private void OnMouseDown()
    {
        if (isHovered)
        {
            if (isCategory)
            {
                panel.SetActive(true);
                mainPanel.SetActive(false);
                image.GetComponent<Image>().sprite = GetComponent<CatagoryImage>().thisCatagory.icon;

                bool left;
                Debug.Log(transform.parent.parent.parent.parent.gameObject.name);
                if (transform.parent.parent.parent.parent.gameObject.name.Equals("Left Book"))
                    left = true;

                else
                {
                    left = false;
                }

                
                GameObject.Find("UI").GetComponent<IconManager>().UpdateKnown(GetComponent<CatagoryImage>().thisCatagory.type,left);
                
            }
            else
            {
                isSelected = !isSelected;
                if (isSelected)
                {
                    if (currentSide == side.Right)
                    {
                        GameObject.Find("UI").GetComponent<SelectedIcons>().rightSelection = this.gameObject;
                        foreach (GameObject icon in GameObject.FindGameObjectsWithTag("Icon"))
                        {
                            if (icon == this.gameObject || icon.GetComponent<ClickHandler>().currentSide == side.Left)
                                continue;

                            icon.GetComponent<ClickHandler>().isSelected = false;


                        }
                    }
                    if (currentSide == side.Left)
                    {
                        GameObject.Find("UI").GetComponent<SelectedIcons>().leftSelection = this.gameObject;
                        foreach (GameObject icon in GameObject.FindGameObjectsWithTag("Icon"))
                        {
                            if (icon == this.gameObject || icon.GetComponent<ClickHandler>().currentSide == side.Right)
                                continue;

                            icon.GetComponent<ClickHandler>().isSelected = false;


                        }
                    }
                }
                else
                {
                    if (currentSide == side.Left)
                    {
                        GameObject.Find("UI").GetComponent<SelectedIcons>().leftSelection = null;
                    }
                    if (currentSide == side.Right)
                    {
                        GameObject.Find("UI").GetComponent<SelectedIcons>().rightSelection = null;
                    }
                }
            }
        }
       
    }

    private void Update()
    {
        if (isCategory)
            return;

        if (isSelected && !GetComponent<Animation>().isPlaying)
        {
            GetComponent<Animation>().Play();
        }
        if (!isSelected && GetComponent<Animation>().isPlaying)
        {
            GetComponent<Animation>().Stop();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
