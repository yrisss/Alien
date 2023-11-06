using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    GameObject thisObject;

    private void Start()
    {
        thisObject = gameObject;
    }

    void OnMouseDown()

    {
        MoveObject.selectedObject = thisObject;
    }
}
