using UnityEngine;
using UnityAtoms.BaseAtoms;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private FloatVariable traveledDistance;
    [SerializeField] private TMP_Text distanceText;
    public void UpdateDistanceText(float value)
    {
        distanceText.text = value.ToString("00.0") + "m";
    }
}
