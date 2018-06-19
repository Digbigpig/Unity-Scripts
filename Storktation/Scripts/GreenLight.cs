using UnityEngine;

public class GreenLight : MonoBehaviour {

    // This script controls a set of lights to signal the status of the belt they corrispond to.

    [SerializeField]
    private Computer computer;

    [SerializeField]
    private Light mylight;

    [SerializeField]
    private Light redLight;


    void Start()
    {
        if (computer == null) { computer = GetComponentInParent<Computer>(); }
        mylight = GetComponentInChildren<Light>();
    }
	

	void Update ()
    {
        Green();
        Red();
	}


    private void Green()
    {
        if (computer.OpenLanes == true) { mylight.enabled = true; }
        else mylight.enabled = false;
    }


    private void Red()
    {
        if (computer.OpenLanes == false) { redLight.enabled = true; }
        else redLight.enabled = false;
    }
}
