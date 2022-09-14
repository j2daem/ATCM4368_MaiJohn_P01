using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDamageable
{
    [Header("Destructible References")]
    [SerializeField] ParticleSystem _projectileImpactVFX = null;
    [SerializeField] AudioClip _projectileSFX = null;

    public void TakeDamage(int amount)
    {
        if (_projectileImpactVFX != null)
        {
            Instantiate(_projectileImpactVFX, transform.position, Quaternion.identity);
        }

        if (_projectileSFX != null)
        {
            AudioHelper.PlayClip2D(_projectileSFX, 1f);
        }

        Destroy(this.gameObject);
    }
}
