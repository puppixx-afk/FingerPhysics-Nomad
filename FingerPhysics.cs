using System;
using UnityEngine;
using ThunderRoad;

namespace FingerPhysicsNomad
{
    public class FingerPhysics : ThunderScript
    {
        public static float FingerSpeed = 18f;
        public static float RelaxSpeed = 7f;

        public override void ScriptLoaded(ModManager.ModData modData)
        {
            base.ScriptLoaded(modData);

            Debug.Log("[FingerPhysics-Nomad] Loaded!");
        }

        public override void ScriptUpdate()
        {
            base.ScriptUpdate();

            // Finger physics will be connected to the player's
            // RagdollHand/finger bones here.
            UpdateFingerPhysics();
        }

        private void UpdateFingerPhysics()
        {
            // Hand and finger-bone implementation goes here.
        }
    }
}
