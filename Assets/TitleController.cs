using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TitleController : Singleton<TitleController>
{
    private Sequence sequence;
    public TMP_Text titleText;
    public int titleVibrato = 3;
    public float titleDuration = 0.5f;
    public Vector3 titlePunchDir = new Vector3(0,5,0);
    
    public void Animate()
    {
        if (titleText.gameObject.activeInHierarchy)
        {
            sequence = DOTween.Sequence();
            DOTweenTMPAnimator animator = new DOTweenTMPAnimator(titleText);
        
            List<int> indexs = new List<int>();
            for (int i = 0; i < animator.textInfo.characterCount; i++) 
            {
                indexs.Add(i);
            }
            System.Random rand = new System.Random();
            rand.Next();
            List<int> randomOrder = indexs.OrderBy(c => rand.Next()).ToList();
            //Tween Fade = CountdownText.DOFade(0, 1f);
            foreach (var index in randomOrder)
            {
                Vector3 currCharOffset = animator.GetCharOffset(index);
                sequence.Join(animator.DOOffsetChar(index, currCharOffset + new Vector3(0, -315, 0), 0.1f)).AppendCallback(
                    () =>
                    {
                        animator.DOPunchCharOffset(index, titlePunchDir, titleDuration, titleVibrato, 0);
                    
                    }
                );
            }
        }
    }
}