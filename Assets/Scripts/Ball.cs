using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _timeToDestroy = 5f;
    private void FixedUpdate()
    {
        _timeToDestroy -= Time.fixedDeltaTime;
        if (_timeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConnectedGlass"))
        {
            other.transform.parent = other.transform.root;

            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
            }
        }
    }

}
