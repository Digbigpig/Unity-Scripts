using UnityEngine;
using UnityEngine.UI;

public class HudPanelController : MonoBehaviour {

    // This script manages the HUD using the SceneManager.

    [SerializeField]
    private Text timeleftUI;

    [SerializeField]
    private Text sortedPackages;

    [SerializeField]
    private Text missortedPackages;

    [SerializeField]
    private SceneHandler manager;


	void Start () {
        timeleftUI.text = "";
        sortedPackages.text = "";
        missortedPackages.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        var _time = (int)manager.timeRemaining;
        
        timeleftUI.text = _time.ToString();
        sortedPackages.text = manager.CorrectlySortedPackages.ToString() + " / " + manager.levelSettings.targetPackages;
        missortedPackages.text = manager.IncorrectlySortedPackages.ToString();
    }
}
