using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityEvent OnLoss = new UnityEvent();

    public static int BallCount;

    [SerializeField] private int initialBallCount = 25;

    private void Awake()
    {
        BallCount = initialBallCount;
    }
    public static void TakeDamage(int damage = 10)
    {
        BallCount -= damage;

        if (BallCount <= 0)
        {
            BallCount = 0;
            OnLoss.Invoke();
        }
    }

    public static void TakeBalls(int quantity = 3)
    {
        BallCount += quantity;
    }
}
