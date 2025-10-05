using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offset;
    private PlayerMovement playerMovement;

    private void Start()
    {
        offset = new Vector3(0, 2, -8);
        playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
    }

    private void LateUpdate()
    {
        if (playerMovement != null)
        {
            transform.position = playerMovement.transform.position + offset;
        }
    }
}