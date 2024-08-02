using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    public enum limits
    {

        noLimit = 0,
        limits30 = 30,
        limits60 = 60,
        limit120 = 120,
        limit240 = 240,
    }

    public limits limit;
    void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }


}
