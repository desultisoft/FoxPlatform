using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Use for games in which the screen must be split between multiple cameras.
/// </summary>
public class CameraSplitter : MonoBehaviour
{
    public Camera cam;
    private static List<CameraSplitter> Splitters = new List<CameraSplitter>();

    Rect Center = new Rect(0, 0, 1, 1);
    Rect TopMiddle = new Rect(0, 0.5f, 1, 0.5f);
    Rect BottomMiddle = new Rect(0, 0, 1, 0.5f);
    Rect TopLeft = new Rect(0, 0.5f, 0.5f, 0.5f);
    Rect TopRight = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
    Rect BottomLeft = new Rect(0, 0, 0.5f, 0.5f);
    Rect BottomRight = new Rect(0.5f, 0, 0.5f, 0.5f);

    public void OnEnable()
    {
        Splitters.Add(this);
        HandleSplit();
    }

    public void OnDisable()
    {
        Splitters.Remove(this);
        HandleSplit();
    }

    public void Update()
    {
        if(Splitters[0]==this && Input.GetKeyDown(KeyCode.Space))
        {
            CameraSplitter inactiveSplitter = FindObjectsOfType<CameraSplitter>().Where(x => !x.gameObject.activeInHierarchy).FirstOrDefault();
            inactiveSplitter?.gameObject.SetActive(true);
        }
    }
    private void HandleSplit()
    {
        if (Splitters.Count == 1)
        {
            Splitters[0].cam.rect = Center;
        }
        else if (Splitters.Count == 2)
        {
            Splitters[0].cam.rect = TopMiddle;
            Splitters[1].cam.rect = BottomMiddle;
        }
        else if (Splitters.Count == 3)
        {
            //Top is Unchanged
            Splitters[0].cam.rect = TopMiddle;
            //Old Bottom is BottomLeft
            Splitters[1].cam.rect = BottomLeft;
            //New Bottom is BottomRight
            Splitters[2].cam.rect = BottomRight;
        }
        else if(Splitters.Count == 4)
        {
            Splitters[0].cam.rect = TopLeft;
            Splitters[1].cam.rect = BottomLeft;
            Splitters[2].cam.rect = BottomRight;
            Splitters[3].cam.rect = TopRight;
        }
    }
}
