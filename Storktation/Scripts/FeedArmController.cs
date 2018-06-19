using UnityEngine;

public class FeedArmController : MonoBehaviour {

    // This script controls the rotation behavior of the feedarms.

    private float startY;
    private bool feeding = true;

    [SerializeField]
    private float targetRotation;

    [SerializeField]
    private float speed;

    [SerializeField]
    float lerpSpeed;


    public bool Feeding
    {
        get
        {
            return feeding;
        }

        set
        {
            feeding = value;
        }
    }


    void Start()
    {
        startY = transform.rotation.eulerAngles.y;
    }


    void Update () {

        ManageFeedarm();
	}


    void ManageFeedarm()
    {
        // Current y rotation of the feedarm.
        var _currentY = transform.rotation.eulerAngles.y;

        // Once the current y rotation passes the max rotation the rotation will stop.
        if (feeding == true && _currentY != targetRotation)
        {
            Quaternion newDir = Quaternion.Euler(0f,targetRotation,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, newDir, lerpSpeed);
        }

        // Retracts the feedarm's rotation to before the start rotation.
        if (feeding == false && _currentY != startY)
        {
            Quaternion newDir = Quaternion.Euler(0f, startY, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, newDir, lerpSpeed);
        }
    }
}
