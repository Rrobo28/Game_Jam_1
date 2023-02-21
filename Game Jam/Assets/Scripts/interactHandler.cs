using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactHandler : MonoBehaviour
{
    public GameObject cameraPos;
    public GameObject myCameraPos;
    public bool pressed = false;
    Transform startPos;
   public void OnPressed()
    {
        pressed = !pressed;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (pressed && Vector3.Distance(Camera.main.transform.position, myCameraPos.transform.position) > 0.01)
        {
            
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, myCameraPos.transform.position, Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, myCameraPos.transform.rotation, Time.deltaTime);
        }
        else if (!pressed && Vector3.Distance(Camera.main.transform.position, cameraPos.transform.position) > 0.01)
        {
           
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraPos.transform.position, Time.deltaTime);
            Camera.main.transform.rotation= Quaternion.Lerp(Camera.main.transform.rotation, cameraPos.transform.rotation, Time.deltaTime);
        }
    }
}
