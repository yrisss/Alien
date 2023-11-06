using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWindow : MonoBehaviour
{

    public void Destroyer(GameObject destroyObject)
    {
        Destroy(destroyObject);
    }
}
