using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Catagory")]
public class Catagory : ScriptableObject
{
    public enum CatagoryType { Flower,Animal,Gem,Potion}
    public CatagoryType type;
    public Sprite icon;
}
