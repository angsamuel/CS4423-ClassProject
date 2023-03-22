using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Creature creature;
    // Update is called once per frame
    void Update()
    {
        creature.Move(new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0));

        if(Input.GetKeyDown(KeyCode.Space)){
            creature.Jump();
        }
    }
}
