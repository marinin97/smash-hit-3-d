using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActivation : MonoBehaviour
{
    [SerializeField] private int _percent = 50;

    private void Awake()
    {
        int rnd = Random.Range(0, 100);

        if (rnd < _percent)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

}
