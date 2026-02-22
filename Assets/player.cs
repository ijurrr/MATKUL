using UnityEngine;

[RequireComponent(typeof(Collider))]
public class player : MonoBehaviour
{
    [Tooltip("Movement speed in units/second.")]
    public float moveSpeed = 5f;

    [Tooltip("Rotate character to face movement direction.")]
    public float rotationSpeed = 720f;

    [Tooltip("If true, movement is relative to camera forward/right. If false, uses world axes.")]
    public bool cameraRelative = true;

    [Tooltip("Optional camera transform. If null, uses Camera.main.")]
    public Transform cameraTransform;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v);
        if (input.sqrMagnitude < 0.0001f)
        {
            return;
        }

        Vector3 moveDir;
        if (cameraRelative && cameraTransform != null)
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = cameraTransform.right;
            right.y = 0f;
            right.Normalize();
            moveDir = forward * v + right * h;
        }
        else
        {
            moveDir = new Vector3(h, 0f, v);
        }

        moveDir = moveDir.normalized * moveSpeed;

        if (rb != null && !rb.isKinematic)
        {
            Vector3 newPos = rb.position + moveDir * Time.deltaTime;
            rb.MovePosition(newPos);
        }
        else
        {
            transform.Translate(moveDir * Time.deltaTime, Space.World);
        }

        // Rotate to face movement direction
        Vector3 lookDir = moveDir;
        lookDir.y = 0f;
        if (lookDir.sqrMagnitude > 0.0001f)
        {
            Quaternion target = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
        }
    }
}
