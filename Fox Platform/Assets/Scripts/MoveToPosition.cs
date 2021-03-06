using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public Vector3 offSet;

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + offSet);
    }


    private void Start()
    {
        transform
            .DOMove(transform.position + offSet, 3, false)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(UpdateType.Fixed);
    }
    
}
