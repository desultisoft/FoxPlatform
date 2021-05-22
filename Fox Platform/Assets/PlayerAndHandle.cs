using UnityEngine;

public class PlayerAndHandle
{
    public RectTransform rectTransform;
    public Player player;

    public PlayerAndHandle(RectTransform rectTransform, Player player)
    {
        this.rectTransform = rectTransform;
        this.player = player;
    }
}