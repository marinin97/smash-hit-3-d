using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestructionEffect : MonoBehaviour
{
    public UnityEvent OnDestruction = new UnityEvent();
    [SerializeField] private GameObject[] fragments;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            if (fragments != null)
            {
                for (int i = 0; i < fragments.Length; i++)
                {
                    fragments[i].SetActive(true);
                    fragments[i].GetComponent<MeshRenderer>().enabled = true;
                    if (fragments[i].GetComponent<Rigidbody>())
                    {
                        fragments[i].GetComponent<Rigidbody>().useGravity = true;
                        fragments[i].GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }
            OnDestruction.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
