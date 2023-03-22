using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows us to create datalists of generation parameters so that we can easily open/load a preset of settings
[CreateAssetMenu(fileName = "RandomWalkParameters_" ,menuName = "PCG/RandomWalkData")]
public class RWSO : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
