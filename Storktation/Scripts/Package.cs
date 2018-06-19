using UnityEngine;

public class Package : MonoBehaviour {

    // This script handles the interaction with packages.

    [SerializeField]
    private float maxDimention;
    [SerializeField]
    private float minDimention;
    [SerializeField]
    private float holdDistance;
    [SerializeField]
    private GameObject labelPrefab;

    private bool isHeld = false;
    private Camera cam;
    private Rigidbody rb;
    public bool sorted = false;


    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        // Generates a random scale from new boxes to a max dimention.
        Vector3 newScale = transform.localScale;
        newScale.y += Random.Range(minDimention, maxDimention);
        newScale.x += Random.Range(minDimention, maxDimention);
        newScale.z += Random.Range(minDimention, maxDimention);
        transform.localScale = newScale;

        // Generates new label in siblings as to prevent a scaling issue due to random package scale.
        // Moves label as a child of the package.
        var _labelObj = Instantiate(labelPrefab);
        _labelObj.transform.parent = transform;

    }


    private void LateUpdate()
    {
        if (isHeld == true) { HoldPackage(); }
    }

    // Called when a package is clicked on. 
    public void PickUp()
    {
        isHeld = true;
        rb.freezeRotation = true;
        rb.detectCollisions = true;
    }


    public void Drop()
    {
        isHeld = false;
        rb.freezeRotation = false;
        rb.detectCollisions = true;
    }


    private void HoldPackage()
    {
        // Lerps the rotation between the current rotation to the rotation allowing you to see the label.
        var _newRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-cam.transform.rotation.eulerAngles.x + 90f, cam.transform.rotation.eulerAngles.y + 180f, -cam.transform.rotation.eulerAngles.z), .9f);
        rb.MoveRotation(_newRotation);

        // Lerps between current position and a distance in front of the camera.
        Vector3 newPos = Vector3.Lerp (transform.position, cam.transform.position +  cam.transform.forward * holdDistance, .1f);
        rb.MovePosition(newPos);

        // Prevents the package from causing major force transfer to other packages on collision while holding the package.
        rb.velocity = Vector3.zero;
    }
}
