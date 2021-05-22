using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public Canvas countdownCanvas;
    public CanvasGroup countdownGroup;
    public TMP_Text countdownText;
    
    [Header("Animation Variables")]
    public Vector3 punchVector = Vector3.right + Vector3.up;
    public float punchDuration = 1 ;
    public int punchVibrato = 1;
    public float punchElasticity = 0.3f;

    private Sequence sequence;

    public bool finished;

    public void SetupCanvas(Camera camera)
    {
        countdownCanvas.worldCamera = camera;
    }
    
    public void OnEnable()
    {
        CountdownController.Instance?.countdowns.Add(this);
    }
    public void OnDisable()
    {
        CountdownController.Instance?.countdowns.Remove(this);
    }

    public void Animate()
    {
        finished = false;
        sequence = DOTween.Sequence();
        sequence
            .OnStart(() => UpdateText("3"))
            .Append(FadeOutText()).Join(PunchText())
            .AppendCallback(() => UpdateText("2"))
            .Append(FadeOutText()).Join(PunchText())
            .AppendCallback(() => UpdateText("1"))
            .Append(FadeOutText()).Join(PunchText())
            .AppendCallback(() => UpdateText("START"))
            .Append(FadeOutText()).Join(PunchText())
            .OnComplete(() => finished = true);
    }
    
    private Tween SpinText()
    {
        return countdownText.transform.DORotate(new Vector3(0, 0, 360), punchDuration, RotateMode.LocalAxisAdd);
    }
    
    private Tween PunchText()
    {
        return countdownText.transform.DOPunchScale(punchVector, punchDuration, punchVibrato, punchElasticity);
    }
    
    private Tween FadeOutText()
    {
        return countdownGroup.DOFade(0, punchDuration);
    }
    
    private void UpdateText(string text)
    {
        countdownGroup.alpha = 1.0f;
        countdownText.text = text;
    }
}