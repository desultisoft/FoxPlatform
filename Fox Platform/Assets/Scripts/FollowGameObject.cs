using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public GameObject toFollow;
    public bool followX;
    public bool followY;
    
    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            if (followX)
            {
                gameObject.transform.position = new Vector3(
                    toFollow.transform.position.x,
                    gameObject.transform.position.y, 
                    gameObject.transform.position.z);
            }
        }
        
    }
}
