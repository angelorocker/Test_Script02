using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private int damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Shoot(Transform origin, float force, int damage=1)
    {
        this.damage = damage;
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(origin.position, origin.rotation);
        rb.velocity = Vector3.zero;
        rb.AddForce(origin.forward * force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.TryGetComponent(out Damageable damageable))
        {
            //
        }
        
    }



}

