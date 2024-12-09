using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    public Transform Ending;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Camera>())
        {
            GameObject.FindObjectOfType<HallwayBuilder>().BuildContinue();
        }
    }
}
