using Eidetic.URack.Base;
using UnityEngine;
using Eidetic.URack.Utility;

namespace Eidetic.URack.Math
{
    public class EOCSetter : Module
    {

        bool Trigger1;
        bool Trigger2;
        bool Trigger3;
        bool Trigger4;
        bool Trigger5;
        bool Trigger6;
        bool Trigger7;
        bool Trigger8;
        bool Trigger9;

        [Input, Knob]
        public float Val1A;
        [Input, Knob]
        public float Val1B;
        [Input, Knob]
        public float Val1C;
        [Input, Knob]
        public float Val1D;

        [Input, Knob]
        public float Val2A;
        [Input, Knob]
        public float Val2B;
        [Input, Knob]
        public float Val2C;
        [Input, Knob]
        public float Val2D;

        [Input, Knob]
        public float Val3A;
        [Input, Knob]
        public float Val3B;
        [Input, Knob]
        public float Val3C;
        [Input, Knob]
        public float Val3D;

        [Input, Knob]
        public float Val4A;
        [Input, Knob]
        public float Val4B;
        [Input, Knob]
        public float Val4C;
        [Input, Knob]
        public float Val4D;

        [Input, Knob]
        public float Val5A;
        [Input, Knob]
        public float Val5B;
        [Input, Knob]
        public float Val5C;
        [Input, Knob]
        public float Val5D;

        [Input, Knob]
        public float Val6A;
        [Input, Knob]
        public float Val6B;
        [Input, Knob]
        public float Val6C;
        [Input, Knob]
        public float Val6D;

        [Input, Knob]
        public float Val7A;
        [Input, Knob]
        public float Val7B;
        [Input, Knob]
        public float Val7C;
        [Input, Knob]
        public float Val7D;

        [Input, Knob]
        public float Val8A;
        [Input, Knob]
        public float Val8B;
        [Input, Knob]
        public float Val8C;
        [Input, Knob]
        public float Val8D;

        [Input, Knob]
        public float Val9A;
        [Input, Knob]
        public float Val9B;
        [Input, Knob]
        public float Val9C;
        [Input, Knob]
        public float Val9D;

        [Input(.35f, 5), Knob]
        public float ScaleA;

        [Input(1.35f, 5), Knob]
        public float ScaleB;

        [Input(.35f, 5), Knob]
        public float ScaleC;

        [Input(.35f, 5), Knob]
        public float ScaleD;


        [Input(0, 9), Knob]
        public float Override;

        int Selected = 0;

        public void EarlyUpdate()
        {
            var overrideIndex = Mathf.FloorToInt(Override);
            if (overrideIndex > 0)
            {
                Trigger1 = overrideIndex == 1;
                Trigger2 = overrideIndex == 2;
                Trigger3 = overrideIndex == 3;
                Trigger4 = overrideIndex == 4;
                Trigger5 = overrideIndex == 5;
                Trigger6 = overrideIndex == 6;
                Trigger7 = overrideIndex == 7;
                Trigger8 = overrideIndex == 8;
                Trigger9 = overrideIndex == 9;
            }
            else
            {
                Trigger1 = SendTriggers.Triggers.ContainsKey("Onset1") ? SendTriggers.Triggers["Onset1"] : false;
                Trigger2 = SendTriggers.Triggers.ContainsKey("Onset2") ? SendTriggers.Triggers["Onset2"] : false;
                Trigger3 = SendTriggers.Triggers.ContainsKey("Onset3") ? SendTriggers.Triggers["Onset3"] : false;
                Trigger4 = SendTriggers.Triggers.ContainsKey("Onset4") ? SendTriggers.Triggers["Onset4"] : false;
                Trigger5 = SendTriggers.Triggers.ContainsKey("Onset5") ? SendTriggers.Triggers["Onset5"] : false;
                Trigger6 = SendTriggers.Triggers.ContainsKey("Onset6") ? SendTriggers.Triggers["Onset6"] : false;
                Trigger7 = SendTriggers.Triggers.ContainsKey("Onset7") ? SendTriggers.Triggers["Onset7"] : false;
                Trigger8 = SendTriggers.Triggers.ContainsKey("Onset8") ? SendTriggers.Triggers["Onset8"] : false;
                Trigger9 = SendTriggers.Triggers.ContainsKey("Onset9") ? SendTriggers.Triggers["Onset9"] : false;
            }

            if (Trigger1) Selected = 1;
            if (Trigger2) Selected = 2;
            if (Trigger3) Selected = 3;
            if (Trigger4) Selected = 4;
            if (Trigger5) Selected = 5;
            if (Trigger6) Selected = 6;
            if (Trigger7) Selected = 7;
            if (Trigger8) Selected = 8;
            if (Trigger9) Selected = 9;

            if (Selected == 1)
            {
                OutputA = Val1A * ScaleA;
                OutputB = Val1B * ScaleB;
                OutputC = Val1C * ScaleC;
                OutputD = Val1D * ScaleD;
            }
            else if (Selected == 2)
            {
                OutputA = Val2A * ScaleA;
                OutputB = Val2B * ScaleB;
                OutputC = Val2C * ScaleC;
                OutputD = Val2D * ScaleD;
            }
            else if (Selected == 3)
            {
                OutputA = Val3A * ScaleA;
                OutputB = Val3B * ScaleB;
                OutputC = Val3C * ScaleC;
                OutputD = Val3D * ScaleD;
            }
            else if (Selected == 4)
            {
                OutputA = Val4A * ScaleA;
                OutputB = Val4B * ScaleB;
                OutputC = Val4C * ScaleC;
                OutputD = Val4D * ScaleD;
            }
            else if (Selected == 5)
            {
                OutputA = Val5A * ScaleA;
                OutputB = Val5B * ScaleB;
                OutputC = Val5C * ScaleC;
                OutputD = Val5D * ScaleD;
            }
            else if (Selected == 6)
            {
                OutputA = Val6A * ScaleA;
                OutputB = Val6B * ScaleB;
                OutputC = Val6C * ScaleC;
                OutputD = Val6D * ScaleD;
            }
            else if (Selected == 7)
            {
                OutputA = Val7A * ScaleA;
                OutputB = Val7B * ScaleB;
                OutputC = Val7C * ScaleC;
                OutputD = Val7D * ScaleD;
            }
            else if (Selected == 8)
            {
                OutputA = Val8A * ScaleA;
                OutputB = Val8B * ScaleB;
                OutputC = Val8C * ScaleC;
                OutputD = Val8D * ScaleD;
            }
            else if (Selected == 9)
            {
                OutputA = Val9A * ScaleA;
                OutputB = Val9B * ScaleB;
                OutputC = Val9C * ScaleC;
                OutputD = Val9D * ScaleD;
            }

        }

        [Output] public float OutputA;
        [Output] public float OutputB;
        [Output] public float OutputC;
        [Output] public float OutputD;
    }
}