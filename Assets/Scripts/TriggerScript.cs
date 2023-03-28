using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;


namespace _Course_Library.Scripts
{
    [ExecuteInEditMode]
    public class TriggerScript : MonoBehaviour
    {
        ParticleSystem water;
        public TMP_Text uiTooltip;
        public string text;

        //these lists are used to contain the particles
        //which match the trigger conditions each frame.

        private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        void OnEnable()
        {
            water = GetComponent<ParticleSystem>();
        }

        private void OnParticleTrigger()
        {
            //get the particles which matched trigger conditions this frame
            int numEnter = water.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

            //iterate through through the particles which entered the trigger
            //and change the UI tooltip text
            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle water;
                water = enter[i];
                uiTooltip.text = text;
            }

            //re-assign the modified particles back into particle system
            water.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        }
    }
}
