using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private PostProcessLayer _blindLayer;
    public void Init(Camera playerCamera)
    {
        cam = playerCamera;
        _blindLayer = cam.GetComponent<PostProcessLayer>();
    }

    public void ToggleBlind(bool isOn)
    {
        _blindLayer.enabled = isOn;
    }
}