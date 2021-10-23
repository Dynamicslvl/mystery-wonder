using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Controller
{
    Up,
    Down,
    Left,
    Right,
    NoKey
}

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;
    public Controller controller;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        controller = Controller.NoKey;
    }
    void LateUpdate()
    {
        if(!Input.GetMouseButton(0))
        controller = Controller.NoKey;
    }
}
