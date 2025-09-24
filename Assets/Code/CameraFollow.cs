
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform car;
    [SerializeField] float speed;
    [SerializeField] float followBehindAmount;

    [SerializeField] ContinuosCarController controller;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(0, -followBehindAmount + car.position.y, -10), 
            speed * Time.deltaTime + controller.velocity.magnitude / 2f
        );
    }
}
