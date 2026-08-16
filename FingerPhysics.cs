using UnityEngine;
using ThunderRoad;

namespace NomadFingerPhysics
{
    public class FingerPhysics : MonoBehaviour
    {
        private PlayerHand? hand;

        private float thumb;
        private float index;
        private float middle;
        private float ring;
        private float pinky;

        private void Awake()
        {
            hand = GetComponent<PlayerHand>();

            if (hand == null)
            {
                Debug.LogWarning("[FingerPhysics] PlayerHand not found.");
                return;
            }

            Debug.Log("[FingerPhysics] Hand connected!");
        }

        private void Update()
        {
            if (hand == null || hand.controlHand == null)
                return;

            thumb = hand.controlHand.GetFingerCurl(Finger.Thumb);
            index = hand.controlHand.GetFingerCurl(Finger.Index);
            middle = hand.controlHand.GetFingerCurl(Finger.Middle);
            ring = hand.controlHand.GetFingerCurl(Finger.Ring);
            pinky = hand.controlHand.GetFingerCurl(Finger.Pinky);

            UpdateFingerPhysics();
        }

        private void UpdateFingerPhysics()
        {
            // Finger values:
            // 0 = completely open
            // 1 = completely curled

            // We'll use these values to drive the actual finger
            // bones once the correct Nomad hand transforms are mapped.
        }
    }
}
