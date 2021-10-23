using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public Controller controller;
    private void OnMouseDown()
    {
        ButtonController.instance.controller = controller;
    }
}
