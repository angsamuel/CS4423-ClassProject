using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 0;
    
    public void Launch(Quaternion rotation, float speed, float newDamage){
        damage = newDamage;
        transform.rotation = rotation;
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
