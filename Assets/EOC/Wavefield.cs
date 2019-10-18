using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Eidetic.URack.Base
{
    public class Wavefield : Module
    {
        public GameObject Target;
        public GameObject CameraGroup;

        public VisualEffect Projection;

        [Input(0, 10, 4, 0), Knob] public float ScrollRate;

        [Input(-25, 25), Knob] public float CameraX;
        [Input(-25, 25), Knob] public float CameraY;
        [Input(-25, 25), Knob] public float CameraZ;

        [Input(-10, 10), Knob] public float LookAtX;
        [Input(-10, 10), Knob] public float LookAtY;
        [Input(-10, 10), Knob] public float LookAtZ;

        [Input(0, 5000, 5, 30), Knob]
        public float Lux
        {
            set => CameraGroup.GetComponentInChildren<Light>().intensity = value;
        }
        [Input(1000, 20000, 1, 6000), Knob]
        public float Temperature
        {
            set => CameraGroup.GetComponentInChildren<Light>().colorTemperature = value;
        }
        [Input(0, 1, 1, .75f), Knob]
        public float Value
        {
            set {
                var trailsModule = Target.GetComponentInChildren<ParticleSystem>().trails;
                trailsModule.colorOverLifetime = Color.white * value;
            }
        }


        [Input(10, 200, 2, 30), Knob]
        public float Strands
        {
            set
            {
                var emissionModule = Target.GetComponentInChildren<ParticleSystem>().emission;
                emissionModule.rateOverTime = value;
            }
        }

        [Input(0.01f, 5, 7, 0.05f), Knob]
        public float Thickness
        {
            set
            {
                var trailModule = Target.GetComponentInChildren<ParticleSystem>().trails;
                trailModule.widthOverTrail = value;
            }
        }

        [Input(0.01f, 5, 2, 1f), Knob]
        public float SimulationSpeed
        {
            set
            {
                var mainModule = Target.GetComponentInChildren<ParticleSystem>().main;
                mainModule.simulationSpeed = value;
            }
        }

        [Input(10, 60, 2, 1f), Knob]
        public float ProjectionFOV
        {
            set => GameObject.Find("Group 1 Camera").GetComponent<Camera>().fieldOfView = value;
        }

        [Input(10, 60, 2, 1f), Knob]
        public float SceneFOV
        {
            set => GameObject.Find("Scene Camera").GetComponent<Camera>().fieldOfView = value;
        }

        Vector3 CameraPosition = new Vector3(0, 0, 0);

        Vector3 LookAtPosition = new Vector3(0, 0, 0);

        [Input(1, 30, 3, 3), Knob] public float Lag = 3;



        ParticleSystem ParticleSystem;
        Transform Transform;

        GameObject Anchor;

        public void Start()
        {
            CameraGroup = GameObject.Find("Cameras");
            Target = GameObject.Find("Group 1");
            ParticleSystem = GameObject.Find("Wavefield-System").GetComponent<ParticleSystem>();
            Transform = GameObject.Find("Wavefield-System").transform;
            Projection = GameObject.Find("Group 1 Projection").GetComponent<VisualEffect>();
            Anchor = GameObject.Find("Anchor");
        }

        public void Update()
        {
            CameraPosition.x = Utility.Damp(CameraPosition.x, CameraX, Lag);
            CameraPosition.y = Utility.Damp(CameraPosition.y, CameraY, Lag);
            CameraPosition.z = Utility.Damp(CameraPosition.z, CameraZ, Lag);

            CameraGroup.transform.position = CameraPosition;
            
            LookAtPosition.x = Utility.Damp(LookAtPosition.x, LookAtX, Lag);
            LookAtPosition.y = Utility.Damp(LookAtPosition.y, LookAtY, Lag);
            LookAtPosition.z = Utility.Damp(LookAtPosition.z, LookAtZ, Lag);

            Anchor.transform.position = Target.transform.position + LookAtPosition;

            CameraGroup.transform.LookAt(Anchor.transform);

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
}
