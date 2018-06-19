using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    // This script manages the status of the current shift.

    // A scriptable object with the settings for the scene.
    public LevelSettings levelSettings;

    public float timeRemaining;

    // TODO: Change this to a single bool with proper modification.
    public bool successfulShift = false;
    public bool unSuccessfulShift = false;

    private int correctlySortedPackages;
    public int CorrectlySortedPackages
    {
        get
        {
            return correctlySortedPackages;
        }

        set
        {
            correctlySortedPackages = value;
        }
    }

    private int incorrectlySortedPackages;
    public int IncorrectlySortedPackages
    {
        get
        {
            return incorrectlySortedPackages;
        }

        set
        {
            incorrectlySortedPackages = value;
        }
    }


    void Start ()
    {
        timeRemaining = levelSettings.timeLimitInSeconds;
	}
	

	void Update () {
        timeRemaining -= Time.deltaTime;
        CheckWinLoseConditions();
        
	}


    // Called when a package sensor collides with a correctly sorted package.
    public void CorrectSort()
    {
        correctlySortedPackages += 1;

        if (correctlySortedPackages >= levelSettings.targetPackages) { CompletedShift(); }
    }


    public void IncorrectSort()
    {
        incorrectlySortedPackages += 1;
    }

    void CheckWinLoseConditions()
    {
        // Sorts target amount of packages, Win.
        if (correctlySortedPackages >= levelSettings.targetPackages) { CompletedShift(); }

        // Miss-sorts too many packages, Lose.
        else if (incorrectlySortedPackages >= levelSettings.availableMissSorts) { FailedShift(); }

        //Runs out of time without enough sorted packages, Lose.
        else if (timeRemaining <= 0 && correctlySortedPackages <= levelSettings.targetPackages) { FailedShift(); }
    }

    void CompletedShift()
    {
        SceneManager.LoadScene(0);
    }

    void FailedShift()
    {
        SceneManager.LoadScene(1);
    }
}
