// Scriptable object to define the Successful/ Failed parameters of the current level.

using UnityEngine;
[CreateAssetMenu(fileName = "LevelSettings")]
public class LevelSettings : ScriptableObject {

    // What level is this setting for.
    public int levelID;

    // How long until the shift is over.
    public int timeLimitInSeconds;

    // How many packages must be sorted in that time.
    public int targetPackages;

    // How many times can you incorrectly sort a package and before you have failed the level.
    public int availableMissSorts;


}
