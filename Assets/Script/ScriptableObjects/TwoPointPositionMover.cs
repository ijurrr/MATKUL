using UnityEngine;

public class TwoPointPositionMover : MonoBehaviour
{
    public Route2PointPosSO route;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        transform.position = route.pointA;
        target = route.pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, target,
            speed * Time.deltaTime
        );

        if (transform.position == target)
        {
            target = (target == route.pointA) ? route.pointB : route.pointA;
        }
    }
}
