using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static bool isWin;

    Collider2D thisCollider;

    [SerializeField] private GameObject winPanel;


    private void Start()
    {
       thisCollider = GetComponent<Collider2D>();
        isWin = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerObject")
        {
            if (gameObject.transform.position == collision.transform.position && thisCollider.bounds.size == collision.bounds.size)
            {
                Instantiate(winPanel);
                isWin = true;
                thisCollider.isTrigger = false;
                return;
            }
        }
    }
}
