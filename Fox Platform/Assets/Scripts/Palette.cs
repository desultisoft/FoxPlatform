using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public float scaleAmount = 3f;
    public float shakeStrength = 10f;
    public int shakeVibrato = 20;
    public float shakeRandomness = 0;
    public float duration;
    private Sequence _sequence;
    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    [ContextMenu("MovePalette")]
    public void MovePalette()
    {
        collider.enabled = true;
        _sequence = DOTween.Sequence();
        _sequence.Append(Rise());
        _sequence.Join(Shake());
        
    }

    public Tween Rise()
    {
        return transform.DOScaleX(scaleAmount, duration).SetEase(Ease.Linear);
    }

    public Tween Shake()
    {
        return transform.DOShakePosition(duration, new Vector3(shakeStrength,0,0), shakeVibrato, shakeRandomness).SetEase(Ease.InQuart);
    }
}
