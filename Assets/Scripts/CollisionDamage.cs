using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDamage : MonoBehaviour
{
    [SerializeField] int _damageAmount;
    [SerializeField] float _knockbackAmount;

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damageAmount);
        }

        if (rb != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            //Only push horizontally
            direction.y = 0;

            rb.AddForce(direction.normalized * _knockbackAmount, ForceMode.Impulse);
        }
    }
}
