using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public void ToggleOff()
    {
        gameObject.SetActive(false);
    }

    public void ToggleOn()
    {
        gameObject.SetActive(true);
    }
}
