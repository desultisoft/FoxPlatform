using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TWGFramework;
using UnityEngine;
using UnityEngine.Events;

public class CountdownController : Singleton<CountdownController>
{
    public GameEvent countdownComplete;
    
    private int index;
    public List<Countdown> countdowns;
    /// <summary>
    /// Triggers all countdowns to animate.
    /// </summary>
    [ContextMenu("Animate")]
    public void Animate()
    {
        StartCoroutine(AnimateCoroutine());
    }

    IEnumerator AnimateCoroutine()
    {
        foreach (var countdown in countdowns)
            countdown.Animate();
        
        yield return new WaitUntil(()=>countdowns.All(x=>x.finished));
        
        countdownComplete.Raise();
    }
}