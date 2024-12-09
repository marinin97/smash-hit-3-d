using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballCount;

    private void FixedUpdate()
    {
        _ballCount.text = $"{GameManager.BallCount}";
    }

}
