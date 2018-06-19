using UnityEngine;

public class Computer : MonoBehaviour {

    // This script works to control all the feed arms and belts using the sensors.
    
    [SerializeField]
    private int waitBuffer = 5;

    private int blockedSensors;
    private bool openLanes;

    [SerializeField]
    private Sensor[] sensors;

    [SerializeField]
    private ConveyorBelt[] belts;

    [SerializeField]
    private PackageGenerator[] packageGenerators;

    public bool OpenLanes
    {
        get
        {
            return openLanes;
        }
    }


    private void Start()
    {
        //belts = FindObjectsOfType<ConveyorBelt>();
        //sensors = FindObjectsOfType<Sensor>();
        //packageGenerators = FindObjectsOfType<PackageGenerator>();
    }


    void Update () {

        // Starts/Stops feedarms.
        ManageFeedarm();

        // Searches for open lanes.
        CheckForOpenLanes();

        // Turns all belts and package generators off/on if all lanes are full.
        if(openLanes == false) { ShutDown(); }
        if(openLanes == true) { Startup(); }
    }


    void ManageFeedarm()
    {
        // Iterate through the sensors in the sensors array. 
        foreach (var sensor in sensors)
        {
            // Turns the the feed arm off if the sensor has been blocked.
            if (sensor.blockedTime > waitBuffer && sensor.linkedArm.Feeding == true)
            {
                sensor.linkedArm.Feeding = false;
            }

            // Turns arm back on if sensor has been cleared.
            else if (sensor.blocked == false && sensor.linkedArm.Feeding == false)
            {
                openLanes = true;
                sensor.linkedArm.Feeding = true;
            }
        }
    }


    void CheckForOpenLanes()
    {
        openLanes = false;
        foreach (var sensor in sensors)
        {
            if (sensor.linkedArm.Feeding == true) { openLanes = true; }
        }
    }


    void ShutDown()
    {
        foreach (var belt in belts) { if (belt != null) { belt.power = false; } }

        foreach (var gen in packageGenerators) { gen.turnedOn = false; } 
    }


    void Startup()
    {
        foreach (var belt in belts) { if (belt != null) { belt.power = true; } }
        foreach (var gen in packageGenerators) { gen.turnedOn = true; } 
    }
}
