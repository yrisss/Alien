using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MoveObject : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public static GameObject selectedObject;

    public static bool isPause = false;

    [SerializeField] private Text textMovesCount;
    [SerializeField] private int movesCount; 

    [SerializeField] private GameObject losePanel;

    Transform transformObject;

    private void Start()
    {
        textMovesCount.text = "Осталось ходов: " + movesCount;
        isPause = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (selectedObject != null && isPause == false)
        {
            bool isClear = true;
            transformObject = selectedObject.GetComponent<Transform>();


            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0)
                {
                    isClear = CheckBlock(new Vector3(0.8f, 0, 0.8f));
                    if (!isClear) return;
                    transformObject.position += new Vector3(0.8f, 0, 0);
                    movesCount--;
                    CheckMoveCount();
                }
                else
                {
                    isClear = CheckBlock(new Vector3(-0.8f, 0, -0.8f));
                    if (!isClear) return;
                    transformObject.position += new Vector3(-0.8f, 0, 0);
                    movesCount--;
                    CheckMoveCount();
                }
            }

            else
            {

                if (eventData.delta.y > 0)
                {
                    isClear = CheckBlock(new Vector3(0, 0.8f, 0));
                    if (!isClear) return;
                    transformObject.position += new Vector3(0, 0.8f, 0);
                    movesCount--;
                    CheckMoveCount();
                }
                else
                {
                    isClear = CheckBlock(new Vector3(0, -0.8f, 0));
                    if (!isClear) return;
                    transformObject.position += new Vector3(0, -0.8f, 0);
                    movesCount--;
                    CheckMoveCount();
                }
            }
        }

    }

    public bool CheckBlock(Vector3 checkedPosition, Collider2D selectedCollider = null)
    {
        selectedCollider = selectedObject.GetComponent<Collider2D>();

        Collider2D[] colliders = Physics2D.OverlapBoxAll(selectedObject.transform.position + checkedPosition, selectedCollider.bounds.size / 2, 0);

        bool canMove = true;
        foreach (Collider2D otherCollider in colliders)
        {
            if (otherCollider.tag == "ExitLight" || otherCollider.tag == "DisappearingLight")
            {
                continue;
            }

            if (otherCollider.gameObject != gameObject)
            {
                if (otherCollider != selectedCollider && otherCollider.tag != "Alarm")
                {
                    canMove = false;
                    Debug.Log("Путь прегражден" + otherCollider.name);
                    break;
                }
            }
        }

        if (canMove) return true;
        else return false;
    }

    public void CheckMoveCount()
    {
        textMovesCount.text = "Осталось ходов: " + movesCount;
        if (movesCount == 0)
        {
            Invoke("LoseGame", 0.5f);
            isPause = true;
        }
    }

    public void LoseGame()
    {
        if (Exit.isWin == false)
        {
            Instantiate(losePanel);
        }
    }



    public void OnDrag(PointerEventData eventData)

    {

    }
}
