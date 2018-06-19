using UnityEngine;

public class SortingSensor : MonoBehaviour {

    // This is the sensor that determines if a package was correctly sorted.

    public SceneHandler manager;
    public string laneLetter;
    Label label;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Package>() == true & other.GetComponent<Package>().sorted == false)
        {
            other.GetComponent<Package>().sorted = true;
            label = other.GetComponentInChildren<Label>();

            if (label.lane == laneLetter)
            {
                Debug.Log("Correct Lane!");
                manager.CorrectSort();
            }

            else
            {
                Debug.Log("Incorrect Lane!");
                manager.IncorrectSort();
            }
        }
    }
}
