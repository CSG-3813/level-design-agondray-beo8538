using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGB;
    
    private void Show()
    {
        containerGB.SetActive(true); //show Ui
    }

    private void Hide()
    {
        containerGB.SetActive(false); //hide Ui
    }
}
