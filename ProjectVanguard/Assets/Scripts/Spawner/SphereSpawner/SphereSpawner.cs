using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class SphereSpawner : Spawner
{
    protected override void SpawnObject()
    {
        poolTag = "Sphere";
        base.SpawnObject();
    }
}
