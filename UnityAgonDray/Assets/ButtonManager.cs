using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject door;

    public void Door()
    {
        Destroy(door.gameObject);
    }
}
