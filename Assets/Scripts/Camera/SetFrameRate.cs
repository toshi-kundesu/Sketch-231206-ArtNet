using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    public enum FrameRate
    {
        Film_24 = 24,
        PAL_25 = 25,
        HD_30 = 30,
        InterlacedPAL_50 = 50,
        Game_60 = 60,
        Show_72 = 72,
        Show_96 = 96,
        Show_100 = 100,
        Show_120 = 120,
    }

    [SerializeField] private FrameRate frameRate = FrameRate.HD_30; // フレームレート

    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)frameRate;
    }
}