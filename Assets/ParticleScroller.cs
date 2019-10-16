using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScroller : MonoBehaviour
{
    public float ScrollRate;

    ParticleSystem ParticleSystem;
    Transform Transform;

    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        Transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var scrollDistance = ScrollRate * Time.deltaTime;

        var shapeModule = ParticleSystem.shape;
        var shapePosition = shapeModule.position;
        shapePosition.y += scrollDistance;
        shapeModule.position = shapePosition;

        var transformPosition = Transform.position;
        transformPosition.z += scrollDistance;
        Transform.position = transformPosition;
    }
}
