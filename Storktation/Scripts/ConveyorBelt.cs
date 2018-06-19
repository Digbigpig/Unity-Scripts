using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    [SerializeField]
    private Transform endPoint;
    // The Transform that the belt will move objects toward.

    public float speed;
    public bool power;

    // When an object enters the collider attached to this GameObject the object will be moved towards the endpoint.
    private void OnTriggerStay(Collider other)
    {
        if (power == true) { other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime); } 
    }
}
