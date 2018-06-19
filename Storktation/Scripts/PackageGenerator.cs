using UnityEngine;

public class PackageGenerator : MonoBehaviour {

    // Generates packages to spawn on the conveyor belt.

    public GameObject package; //Prefab of a package.

    public float rate;
    public float cooldownTime;
    public bool turnedOn;


	void Update () {

        if (turnedOn == true)
        {
            if (cooldownTime >= rate)
            {
                Instantiate(package, transform);
                cooldownTime = 0f;
            }

            cooldownTime += Time.deltaTime;
        }
		
	}
}
