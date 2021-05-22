using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTracker : MonoBehaviour
{
    private List<PlayerAndHandle> handles = new List<PlayerAndHandle>();
    
    private float _startX => -(width / 2);
    public float width=>sliderRect.rect.width;
    public float maxX = 5f;
    public float minX => LevelManager.Instance.respawnPoint.position.x;
    public RectTransform playerHandle;
    public RectTransform playerHandleParent;
    public RectTransform sliderRect;
    
    private float percentDone;
    private float handleOffset;

    public void Start()
    {
        maxX = WinZone.Instance.transform.position.x;
    }

    public void CreatePlayerTracker(Player newPlayer)
    {
        RectTransform rectTransform = Instantiate(playerHandle, playerHandleParent.transform);
        rectTransform.GetComponent<Image>().color = newPlayer.color;
        rectTransform.localPosition = new Vector2(_startX, 0);
        handles.Add(new PlayerAndHandle(rectTransform,newPlayer));
    }

    public void Update()
    {
        foreach (PlayerAndHandle handle in handles)
        {

            percentDone = handle.player.transform.position.x / (maxX-minX);
            handleOffset = Mathf.Clamp(_startX + (percentDone * width), _startX, -_startX);
            
            handle.rectTransform.localPosition = new Vector2(handleOffset, handle.rectTransform.localPosition.y);
        }
    }
}