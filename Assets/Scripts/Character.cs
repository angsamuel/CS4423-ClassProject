using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 3f;
    public float forceMultiplier = 10;

    [Header("Outside Objects")]
    public GameObject myBoxGamePrefab;
    //public SpriteRenderer sr;
    //public MyBox myBox;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //easy way of moving
        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0) * speed * Time.deltaTime; 


        

        
        if(Input.GetKeyDown(KeyCode.K)){
            //sr.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
            //myBox.ChangeColor(Color.black);
            GameObject newBox = Instantiate(myBoxGamePrefab,transform.position,Quaternion.identity);
            
        }
        
    }

    void FixedUpdate()
    {
        //standard rigidbody2d movement method, you should probably use something like this!
        rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed));
        
        //floaty astronaut method, be sure to mess with rigidbody2d drag!
        //rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * forceMultiplier * Time.fixedDeltaTime);

        //brute force physics method, exact control of velocity
        //rb2d.velocity = (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("We collided with the box!");
    }

    

}
