using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : Spawner
{ 

    protected override void SpawnObject()
    {
        poolTag = "Capsule";
        base.SpawnObject();
    }
}
