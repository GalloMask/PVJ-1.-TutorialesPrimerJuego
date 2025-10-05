using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offset;
    private PlayerMovement playerMovement;

    private void Start()
    {
        offset = new Vector3(0, 5, -10);
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void LateUpdate()
    {
        if (playerMovement != null)
        {
            transform.position = playerMovement.transform.position + offset;
        }
    }
}