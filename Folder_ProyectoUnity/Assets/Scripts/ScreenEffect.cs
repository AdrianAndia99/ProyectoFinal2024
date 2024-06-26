using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    private float moveSpeed = 10f;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*moveSpeed);
    }
}
