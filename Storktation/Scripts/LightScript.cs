
using UnityEngine;

public class LightScript : MonoBehaviour {

    [Range(0, 1)] public float BackgroundLightIntensity = 0.25f;

    // Use this for initialization
    void Start () {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(BackgroundLightIntensity, BackgroundLightIntensity, BackgroundLightIntensity);
    }
	
	// Update is called once per frame
	void Update () {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(BackgroundLightIntensity, BackgroundLightIntensity, BackgroundLightIntensity);
    }
}
