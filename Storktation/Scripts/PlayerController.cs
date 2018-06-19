using UnityEngine;

public class PlayerController : MonoBehaviour {

    // This script controls the player input besides the movement.

    private Package package;


    void Update ()
    {
        // Left click will pick up packages
        LeftClick();

        // Right click will drop packages.
        RightClick();
	}


    void LeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Generates a ray from the center of the screen to the world.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                // If the ray hits a Package.
                if (hit.collider.GetComponent<Package>())
                {

                    // Removes current package.
                    if (package != null)
                    {
                        package.Drop();
                        package = null;
                    }
                    
                    // Picks up new package.
                    package = hit.collider.GetComponent<Package>();
                    package.PickUp();

                }
            }
        }
    }


    void RightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            package.Drop();
        }
    }
}
