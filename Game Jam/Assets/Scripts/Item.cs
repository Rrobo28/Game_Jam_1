using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Item")]
public class Item : ScriptableObject
{ 
    public string name;
    public Sprite icon;
    public enum catagory { flower,animal,gem,potion}
    public catagory itemCatagory;
}
