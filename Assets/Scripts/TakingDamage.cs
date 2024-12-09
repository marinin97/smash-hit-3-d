using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakingDamage : MonoBehaviour
{
    public UnityEvent OnDamage;
    [SerializeField] int damage = 10;
    [SerializeField] private string[] dangerousTags;

    private ThrowObject _throwObj;

    private void Awake()
    {
        _throwObj = GameObject.FindObjectOfType<ThrowObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < dangerousTags.Length; i++)
        {
            if (other.CompareTag(dangerousTags[i]))
            {
                GameManager.TakeDamage(damage);
                _throwObj.ThrowAway(damage);
                OnDamage.Invoke();
            }
        }
    }   
}
