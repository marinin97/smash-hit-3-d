using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{
    public UnityEvent OnMoveBreak;
    public float MoveSpeed;

    private void Awake()
    {
        GameManager.OnLoss.AddListener(BreakMovement);
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.forward * MoveSpeed * Time.fixedDeltaTime;
    }

    public void BreakMovement()
    {
        MoveSpeed = 0;
        OnMoveBreak.Invoke();
    }
}
