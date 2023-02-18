using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 3f;
    public float forceMultiplier = 10;

    [Header("Outside Objects")]
    public GameObject myBoxGamePrefab;
    Rigidbody2D rb2d;

    [Header("Temp Objects")]
    public MyBox myBox;

    [Header("Text Elements")]
    int points = 0;


    [Header("Events")]
    public UnityEvent<int> pointEvent;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        //myBox = GameObject.Find("Box").GetComponent<MyBox>(); //find the box by name, pretty slow!
        //myBox = GameObject.FindObjectOfType<MyBox>(); //find the box by type,  VERY SLOW
        //myBox = GameObject.FindGameObjectWithTag("Box").GetComponent<MyBox>(); //find the box with tag, only do this if you have one box, or don't care about the one you get
       
    }

    // Update is called once per frame
    void Update()
    {
        //====easy way of moving, wonky physics interactions though
        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0) * speed * Time.deltaTime; 

        if(Input.GetKeyDown(KeyCode.K)){
            //spawn a box when we press K
            GameObject newBox = Instantiate(myBoxGamePrefab,transform.position,Quaternion.identity);
            
        }

        if(Input.GetKeyDown(KeyCode.E)){
            if(myBox != null){
                myBox.ChangeColor(Color.black);
            }
        }
       // floatScore += Time.deltaTime * multiplier;
    }

    void FixedUpdate()
    {
        //====standard rigidbody2d movement method, you should probably use something like this!
        rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed));

        //====floaty astronaut method, be sure to mess with rigidbody2d's drag value in inspector!
        //rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * forceMultiplier * Time.fixedDeltaTime);

        //====brute force physics method, exact control of velocity
        //rb2d.velocity = (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))) * speed;

        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("We collided with the box!");

        if(other.tag == "Box"){
            myBox = other.GetComponent<MyBox>();
        }
        if(other.tag == "Food"){
            HandleFood(other);
        }
        if(other.tag == "Shrink"){
            Destroy(other.gameObject);
            transform.localScale *= .9f;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<MyBox>() != null){
            myBox = null;
        }
    }

    void HandleFood(Collider2D other){
        //update the point text element
        points+=1;
        other.GetComponent<FoodPellet>().Eat(this.gameObject);
        pointEvent.Invoke(points);
    }



    float floatScore = 0;
    float multiplier = 1f;
    
    IEnumerator ScoreIncreaseRoutine(){
        while(true){
            yield return null;
        }
    }











    

}
