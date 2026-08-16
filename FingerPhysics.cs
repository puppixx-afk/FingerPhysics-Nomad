using UnityEngine;
using UnityEngine.XR;
using ThunderRoad;

namespace NomadFingerPhysics
{
    public class FingerPhysics : MonoBehaviour
    {
        private PlayerHand hand;

        private float thumb;
        private float index;
        private float middle;
        private float ring;
        private float pinky;

        private float smoothThumb;
        private float smoothIndex;
        private float smoothMiddle;
        private float smoothRing;
        private float smoothPinky;

        // Finger response speed.
        private const float FollowSpeed = 18f;

        private void Awake()
        {
            hand = GetComponent<PlayerHand>();

            if (hand == null)
            {
                Debug.LogWarning(
                    "[FingerPhysics] PlayerHand component not found."
                );

                enabled = false;
                return;
            }

            Debug.Log("[FingerPhysics] Hand connected!");
        }

        private void Update()
        {
            if (hand == null || hand.controlHand == null)
                return;

            // Read individual finger curl values.
            // 0 = open, 1 = fully curled.
            thumb = hand.controlHand.GetFingerCurl(Finger.Thumb);
            index = hand.controlHand.GetFingerCurl(Finger.Index);
            middle = hand.controlHand.GetFingerCurl(Finger.Middle);
            ring = hand.controlHand.GetFingerCurl(Finger.Ring);
            pinky = hand.controlHand.GetFingerCurl(Finger.Pinky);

            // Smooth the movement.
            smoothThumb = Smooth(smoothThumb, thumb);
            smoothIndex = Smooth(smoothIndex, index);
            smoothMiddle = Smooth(smoothMiddle, middle);
            smoothRing = Smooth(smoothRing, ring);
            smoothPinky = Smooth(smoothPinky, pinky);

            FingerPhysicsUpdate();
        }

        private float Smooth(float current, float target)
        {
            float speed =
                1f - Mathf.Exp(-FollowSpeed * Time.deltaTime);

            return Mathf.Lerp(current, target, speed);
        }

        private void FingerPhysicsUpdate()
        {
            // These are the five independent finger values.
            //
            // 0.0 = open
            // 1.0 = closed
            //
            // The next stage will use these values to rotate
            // the actual finger bones.

            ApplyFingerDebug(
                "Thumb",
                smoothThumb
            );

            ApplyFingerDebug(
                "Index",
                smoothIndex
            );

            ApplyFingerDebug(
                "Middle",
                smoothMiddle
            );

            ApplyFingerDebug(
                "Ring",
                smoothRing
            );

            ApplyFingerDebug(
                "Pinky",
                smoothPinky
            );
        }

        private void ApplyFingerDebug(
            string fingerName,
            float curl
        )
        {
            // Keep logging extremely low-frequency so Quest
            // performance isn't destroyed during testing.
            if (Time.frameCount % 120 != 0)
                return;

            Debug.Log(
                "[FingerPhysics] " +
                fingerName +
                " curl: " +
                curl.ToString("0.00")
            );
        }
    }
}
