using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;

    [SerializeField]
    private float minX = -2.35f;

    [SerializeField]
    private float maxX = 2.35f;

    [SerializeField]
    private PlayerVisuals playerVisuals;

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;

        playerVisuals.UpdateDirection(input);
    }
}
