using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] int _damageAmount = 1;

    [Header("Projectile References")]
    [SerializeField] ParticleSystem _projectileImpactVFX = null;
    [SerializeField] AudioClip _projectileSFX = null;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damageAmount);
        }

        #region Visual/Audio Feedback
        if (_projectileImpactVFX != null)
        {
            Instantiate(_projectileImpactVFX, transform.position, Quaternion.identity);
        }

        if (_projectileSFX != null)
        {
            AudioHelper.PlayClip2D(_projectileSFX, 1f);
        }
        #endregion

        Destroy(this.gameObject);
    }
}
