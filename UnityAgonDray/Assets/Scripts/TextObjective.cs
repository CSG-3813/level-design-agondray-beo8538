using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextObjective : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }

}
