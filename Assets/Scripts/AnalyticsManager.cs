using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public void LevelAnalytics(float currentHeight)
    {
        if (currentHeight % 1000 != 0)
            return;

        float level = currentHeight / 1000;

        Analytics.CustomEvent("LevelReached", new Dictionary<string, object>
        {
            {"Level", level}
        });
    }
}
