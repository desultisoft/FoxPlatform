using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float max;
    // Update is called once per frame
    void Update()
    {
        max -= Time.deltaTime;
        if (max <= 0)
        {
            Destroy(gameObject);
        }
    }
}
