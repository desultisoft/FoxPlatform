using UnityEngine;
using Items;

public class Player : MonoBehaviour
{
    public CameraController cameraController { private set; get; }
    public ItemManager itemManager;
    public PlayerMovement movement;
    public bool isRight => movement.controller.m_FacingRight;
    public Color color { get; set; }
    public GameObject respawn;

    public float minHeightForDeath = -6f;

    public int ID;

    // Update is called once per frame
    private void Awake()
    {
        itemManager.Init(this);
        
        movement = GetComponent<PlayerMovement>();
        cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        if(gameObject.transform.position.y < minHeightForDeath)
            PlayerManager.Instance.Respawn(this);
    }

    public void Action()
    {
        itemManager.InteractButton();
    }
}