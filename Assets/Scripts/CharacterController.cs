using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 100f;
    [SerializeField] float _maxSpeed = 200f;

    [SerializeField] Transform _firePoint = null;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projectileForce = 100f;

    private Rigidbody _rb = null;
    private Ray _mouseRay;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        Shoot();
    }

    #region Movement
    public void Move()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }

        // Calculate the direction and desired velocity
        float moveAmountThisFrameVertical = Input.GetAxis("Vertical") * _moveSpeed;
        float moveAmountThisFrameHorizontal = Input.GetAxis("Horizontal") * _moveSpeed;

        // Create a vector from amount and direction
        Vector3 moveOffset = new Vector3(moveAmountThisFrameHorizontal, 0, moveAmountThisFrameVertical);

        // Apply vector the rigid body; consider adjusting vector
        _rb.AddForce(moveOffset);
    }
    #endregion

    #region Turning
    public void Turn()
    {
        _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_mouseRay, out RaycastHit hitInfo))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
    #endregion

    #region Shooting
    public void Shoot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Shooting");
            GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody rbProjectile = projectile.GetComponent<Rigidbody>();
            rbProjectile.AddForce(_firePoint.forward * _projectileForce, ForceMode.Impulse);
        }
    }
    #endregion
}