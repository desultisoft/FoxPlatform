using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownController : Singleton<CountdownController>
{

    
    
    public UnityEvent onEnd;
    private Sequence sequence;
    public TMP_Text countdownText;
    public CanvasGroup canvasGroup;
    
    public Vector3 punchVector;
    public float punchDuration;
    public int punchVibrato;
    public float punchElasticity;
    
    [ContextMenu("Animate")]
    public void Animate()
    {
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
            .OnComplete(() => onEnd.Invoke());
    }

    private Tween SpinText()
    {
        return countdownText.transform.DORotate(new Vector3(0, 0, 360), punchDuration, RotateMode.LocalAxisAdd);
        //return countdownText.transform.DORotateQuaternion(countdownText.transform.eulerAngles + new Vector3(0,0,360), punchDuration);
        //return countdownText.transform.DORotate(new Vector3(0,0,360), punchDuration, RotateMode.FastBeyond360);
    }
    
    private Tween PunchText()
    {
        return countdownText.transform.DOPunchScale(punchVector, punchDuration, punchVibrato, punchElasticity);
    }
    
    private Tween FadeOutText()
    {
        return canvasGroup.DOFade(0, punchDuration);
    }
    
    private void UpdateText(string text)
    {
        canvasGroup.alpha = 1.0f;
        countdownText.text = text;
    }
}