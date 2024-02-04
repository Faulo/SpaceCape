using UnityEngine;

namespace SpaceCape {
    public enum TimeScale {
        Normal,
        Faster,
        Slower,
        Reverse
    }

    public static class TimeScaleExtensions {
        public static void ApplyTimeScale(this TimeScale timeScale) {
            switch (timeScale) {
                case TimeScale.Faster:
                    Time.timeScale = 2.0f;
                    break;
                case TimeScale.Slower:
                    Time.timeScale = 0.5f;
                    break;
                case TimeScale.Reverse:
                case TimeScale.Normal:
                    Time.timeScale = 1.0f;
                    break;
            }

            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        public static void RestoreTimeScale(this TimeScale timeScale) {
            TimeScale.Normal.ApplyTimeScale();
        }
    }
}