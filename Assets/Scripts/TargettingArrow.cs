using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargettingArrow : MonoBehaviour
{
    [SerializeField] Transform arrowHead;
    [SerializeField] Transform line;

    Vector2 mousePos;
    Vector2 cardToMouseVector;

    private void OnEnable()
    {
        transform.position = ReferenceManager.Instance.SelectedCardPos;
    }

    private void LateUpdate()
    {
        mousePos = InputManager.Instance.MousePos;
        cardToMouseVector = mousePos - (Vector2)ReferenceManager.Instance.SelectedCardPos;


        arrowHead.position = mousePos;
        arrowHead.up = cardToMouseVector.normalized;

        line.up = arrowHead.up;
        line.localScale = new Vector3(line.localScale.x, cardToMouseVector.magnitude, line.localScale.z);
    }
}
