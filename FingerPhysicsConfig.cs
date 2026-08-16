using UnityEngine;

namespace NomadFingerPhysics
{
    public static class FingerPhysicsConfig
    {
        // How quickly fingers follow their target pose.
        public const float FollowSpeed = 18f;

        // How quickly fingers relax when released.
        public const float RelaxSpeed = 7f;

        // Maximum amount of finger bend.
        public const float MaxBend = 75f;

        // Extra smoothing to prevent jitter.
        public const float Smoothing = 0.15f;
    }
}
