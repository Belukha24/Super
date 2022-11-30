using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform; //player 태그를 따라 이동
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        transform.position = cameraPosition;
    }
}
