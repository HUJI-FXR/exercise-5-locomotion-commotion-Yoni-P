using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootyGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private InputActionReference shootAction;
    [SerializeField] private Transform gunBarrelOrigin;
     private void Update()
    {
        // HandleShooting();
    }

    private void OnEnable()
    {
        shootAction.action.canceled += Shoot;
    }
    
    private void OnDisable()
    {
        shootAction.action.canceled -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        var newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.LookRotation(spawnPoint.position - gunBarrelOrigin.position));
        // newBullet.transform.rotation *= Quaternion.FromToRotation(Vector3.forward, spawnPoint.position - gunBarrelOrigin.position);
        var newBulletRigidBody = newBullet.GetComponent<Rigidbody>();
        
        newBullet.SetActive(true);
        
        var velocityDir = spawnPoint.position - gunBarrelOrigin.position;
        newBulletRigidBody.velocity = velocityDir * bulletSpeed;
    }
}
