using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FillController : MonoBehaviour
{
    [HideInInspector] public float targetScale, scale;
    Light2D light;
    public float flicker = 0.1f;
    public float speed = 5;
    bool isInc = true;
    void Start()
    {
        scale = 1;
        targetScale = 1;
        transform.localScale = new Vector3(scale, scale, 1);
        light = GetComponent<Light2D>();
    }

    float e = 0.001f;
    void Update()
    {
        if (isInc)
        {
            scale += (targetScale + flicker - scale) * Time.deltaTime * speed;
            if (Mathf.Abs(targetScale + flicker - scale) < e) isInc = false;
        } else
        {
            scale += (targetScale - scale) * Time.deltaTime * speed;
            if (Mathf.Abs(targetScale - scale) < e) isInc = true;
        }
        transform.localScale = new Vector3(scale, scale, 1);
        light.pointLightInnerRadius = scale;
        light.pointLightOuterRadius = scale * 2.5f;
    }
}
