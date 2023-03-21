using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    //attributes
    [Header("Properties")]
    public float damage = 1f;
    public float projectileSpeed = 1f;
    public float cooldown = 1f;
    public float accuracy = 1f;
    public int projectiles = 1;
    public float projectileSize = .1f;
    public float projectileGravity = 0;

    [Header("Prefabs")]
    public GameObject projectile;

    [Header("Transforms")]
    public Transform spawnPoint;

    [Header("Generation Config")]
    public bool randomizeAttributes = false;
    public bool randomizeSeed = false;
    public int seed = 0;

    [Header("Damage")]
    public float worstDamage = -10f;
    public float bestDamage = 10f;

    [Header("Speed")]
    public float worstSpeed = .1f;
    public float bestSpeed = 10f;

    [Header("Cooldown")]
    public float worstCooldown = 1f;
    public float bestCooldown = .1f;

    [Header("Accuracy")]
    public float worstAccuracy = -90f;
    public float bestAccuracy = 0f;

    [Header("Projectiles")]
    public int worstProjectiles = 1;
    public int bestProjectiles = 10;

    [Header("Size")]
    public float worstProjectileSize = .01f;
    public float bestProjectileSize = 2f;

    [Header("Gravity")]
    public float worstGravity = 1;
    public float bestGravity = 0;

    //Components
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(randomizeAttributes){
            Generate();
        }
    }


    public void Generate(){
        //code for today! 
        //Random.InitState(seed);
        if(randomizeSeed){
            
            seed = Random.Range(int.MinValue,int.MaxValue);
            Random.InitState(seed);
        }else{
            Random.InitState(seed);
        }
        


        //randomizeAttributes attributes
        damage =  Random.Range(worstDamage,bestDamage);
        projectileSpeed = Random.Range(worstSpeed,bestSpeed);
        cooldown = Random.Range(worstCooldown,bestCooldown);
        accuracy = Random.Range(worstAccuracy,bestAccuracy);

        if(Random.Range(0f,1f) < .25f){
            projectiles = (int)Random.Range(worstProjectiles,bestProjectiles);
        }else{
            projectiles = 1;
        }
        


        projectileSize = Random.Range(worstProjectileSize,bestProjectileSize);

        projectileGravity = Random.Range(worstGravity,bestGravity);

        //let's randomizeAttributes our color too!
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    }

    void Update(){
        Shoot();
    }


    bool onCooldown = false;
    public void Shoot(){
        if(onCooldown){
            return;
        }
        //begin cooldown
        ShootCooldown();

        //projectile count
        for(int i = 0; i<projectiles; i++){
            //create projectile, apply the damage and speed
            GameObject newProjectile = Instantiate(projectile,spawnPoint.position,Quaternion.identity);

            //apply the size
            newProjectile.transform.localScale = Vector3.one * projectileSize;

            //accuracy
            float angleOffset = Random.Range(-accuracy,accuracy);

            //launch the projectile!
            newProjectile.GetComponent<Projectile>().Launch(transform.rotation * Quaternion.Euler(0,0,angleOffset),projectileSpeed,damage);
            newProjectile.GetComponent<SpriteRenderer>().color = spriteRenderer.color;
            
            newProjectile.GetComponent<Rigidbody2D>().gravityScale = projectileGravity;
            //so we don't add up projectiles forever, destroy after 10 seconds
            Destroy(newProjectile,10f);
        }  
    }

    void ShootCooldown(){
        //prevent weird duplicate cooldown behaviors
       if(onCooldown){
        return;
       }
       //set on cooldown to true so we can't shoot
       onCooldown = true;

       //wait for cooldown seconds until we can shoot again
       StartCoroutine(ShootCooldownRoutine());
       IEnumerator ShootCooldownRoutine(){
            yield return new WaitForSeconds(cooldown);
            onCooldown = false;
        }      
    }



    // public void Generate(){
    //     //set our seed
    //     if(randomizeSeed){
    //        seed = Random.Range(int.MinValue,int.MaxValue); 
    //     }

    //     Random.InitState(seed);
        
    //     //randomizeAttributes attributes
    //     damage =  Random.Range(worstDamage,bestDamage);
    //     projectileSpeed = Random.Range(worstSpeed,bestSpeed);
    //     cooldown = Random.Range(worstCooldown,bestCooldown);
    //     accuracy = Random.Range(worstAccuracy,bestAccuracy);
    //     projectiles = (int)Random.Range(worstProjectiles,bestProjectiles);
    //     projectileSize = Random.Range(worstProjectileSize,bestProjectileSize);

    //     //let's randomizeAttributes our color too!
    //     GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    
    // }


}
        
