using UnityEngine;

public class Label : MonoBehaviour {

    // This script handles the creation and lifecycle of the package's label.

    public string lane;
    public string destination;

    private Texture2D destinationTexture;
    private Texture2D laneTexture;
    private Texture2D labelTexture;
    [SerializeField]
    private MeshRenderer labelRenderer;
    public LabelTextureGenerator labelTextGen;
    public PackageGenerator packageGen;
    [SerializeField]
    private string[] lanes;

    
    // TODO: Import a large collection of city names to use for destination city.
	
	void Start () {

        // Generate a random lane and modify the labels text to reflect.
        int laneChoice = Random.Range(0, lanes.Length);
        lane = lanes[laneChoice];
        destination = "DENVER";

        // Moves the label away from the package slightly. 
        transform.localPosition = new Vector3(0f, .51f, 0f);

        // Generate the label, lane, and destination texture.
        labelTexture = labelTextGen.GenLabelTexture();  
        destinationTexture = labelTextGen.getTexture(destination);
        laneTexture = labelTextGen.getTexture(lane);

        // Merges labels into one texture.
        var finishedLabel = labelTextGen.MergeTextures(labelTexture, destinationTexture, laneTexture);

        // Applies the texture to the label.
        labelRenderer.material.mainTexture = finishedLabel;
    }
}
