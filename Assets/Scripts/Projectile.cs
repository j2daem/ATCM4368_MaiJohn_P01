using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject _projectile = null;
    [SerializeField] ParticleSystem _projectileImpactVFX = null;
    [SerializeField] AudioClip _projectileSFX = null;

    private void OnTriggerEnter(Collider other)
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
