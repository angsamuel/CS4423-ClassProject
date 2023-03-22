using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkGenerator : MonoBehaviour
{
     [Header("Config")]
    public int steps = 100;
    public int seed = 50;
    public List<Vector2Int> directions;

    [Header("Objects")]
    public Transform walkTransform; //just for showing us where the walker is located
    public GameObject randomWalkRoomBase; //base object we'll be using, you can find it in the scene
    public SpriteRenderer background;

    //trackers=====================================
    Vector2Int walkPos; //trakcs our position
    Dictionary<Vector2Int,RandomWalkRoom> roomDict; //stores the placement location of rooms
   

    void Start(){
        walkPos = Vector2Int.zero;
        roomDict = new Dictionary<Vector2Int, RandomWalkRoom>();
        
        Random.InitState(seed); //initialize the seed
        
        RandomizeColors(); //set the colors (optional)
        
        Walk(steps);
    }

    void RandomizeColors(){
        //optional: randomize the colors by changing the background, and colors of your base room

    }

    public void Walk(int steps){
        
        PlaceRoom(); //place a starter room
        
        StartCoroutine(WalkRoutine());
        
        IEnumerator WalkRoutine(){
            for(int i = 0; i<steps; i++){ //your code goes in here!
                

                //step 1: choose a direction to move

                
                //step 2: open door to previous room using the OpenDoor method
                

                //step 3: move (change the value of walkPos)


                //step 4: place new room using PlaceRoom method

                
                //step 5: open the door of our new room to the previous room using OpenDoor method


                //wait
                yield return new WaitForSeconds(.1f);
            }
            yield return null;

            //delete the base room
            Destroy(randomWalkRoomBase);
        }

    }

    RandomWalkRoom GetRoom(Vector2Int pos){
        if(roomDict.ContainsKey(pos)){
            return roomDict[pos];
        }
        return null;
    }

    void PlaceRoom(){
        walkTransform.position = new Vector3(walkPos.x,walkPos.y); //visual helper
        if(HasRoom(walkPos)){
            return; //room already placed
        }
        roomDict[walkPos] = Instantiate(randomWalkRoomBase,new Vector3Int(walkPos.x,walkPos.y),Quaternion.identity).GetComponent<RandomWalkRoom>();
    }

    bool HasRoom(Vector2Int position){
        return roomDict.ContainsKey(position);
    }

    public void OpenDoor(RandomWalkRoom room, Vector2Int direction){
        if(direction.y == 1){
            room.upDoor.SetActive(false);
        }else if(direction.y == -1){
            room.downDoor.SetActive(false);
        }else if(direction.x == 1){
            room.rightDoor.SetActive(false);
        }else if(direction.x == -1){
            room.leftDoor.SetActive(false);
        }
    }
}
