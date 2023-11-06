using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private GameObject alarmLosePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObject")
        {
            MoveObject.isPause = true;
            Instantiate(alarmLosePanel);
        }
    }
}
