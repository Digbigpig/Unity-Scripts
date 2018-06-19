using UnityEngine;

public class Sensor : MonoBehaviour {

    // This script attaches to a "Sensor" that detects if there are packages between it and the "Reciever" object.
    // This works similar to an automatic garage door sensor.

    [SerializeField]
    private Transform receiver;
    public bool blocked;
    public float blockedTime;
    public FeedArmController linkedArm;

    void Start()
    {
        if (!receiver) { receiver = GetComponentInChildren<Receiver>().transform; }
    }


    void Update () {

        // The direction of the receiver linked to this sensor.
        var heading = receiver.position - transform.position;

        // The distance between the sensor and receiver plus 1f to prevent false negatives from scaling differences.
        var distance = heading.sqrMagnitude + 1f;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, heading, out hit, distance))
        {
            // If the raycast hits an object with a receiver component.
            if (hit.collider.GetComponent<Receiver>())
            {
                blockedTime = 0f;
                blocked = false;
                Debug.DrawRay(transform.position, heading , Color.green);
            }

            else
            {
                blocked = true;
                blockedTime += Time.deltaTime;
                Debug.DrawRay(transform.position, heading , Color.red);
            }
        } 
    }
}
