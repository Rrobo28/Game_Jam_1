using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interact : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (text.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<interactHandler>().OnPressed();
        }
    }
}
