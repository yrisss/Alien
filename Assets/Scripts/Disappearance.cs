using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearance : MonoBehaviour
{
    Collider2D thisCollider;


    private void Start()
    {
        thisCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "PlayerObject")
        {
            if (gameObject.transform.position == collision.transform.position && thisCollider.bounds.size == collision.bounds.size)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
