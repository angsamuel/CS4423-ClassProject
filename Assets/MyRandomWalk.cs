using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRandomWalk : MonoBehaviour
{
    [Header("Config")]
    public int steps = 100;
    public int seed = 50;
    public List<Vector2Int> directions;
    public int turnAfter = 1;

    [Header("Objects")]
    public Transform walkTransform; //just for debugging;
    public GameObject randomWalkRoomBase;
    public SpriteRenderer background;

    //trackers
    Vector2Int walkPos;
    Dictionary<Vector2Int,RandomWalkRoom> roomDict;
   


    void Start(){
        walkPos = Vector2Int.zero;
        roomDict = new Dictionary<Vector2Int, RandomWalkRoom>();
        Random.InitState(seed);
        RandomizeColors();
        Walk(steps);
    }

    void RandomizeColors(){
        float hue = Random.Range(0f,1f);
        background.color = Color.HSVToRGB(hue,.5f,.1f);
        randomWalkRoomBase.GetComponent<RandomWalkRoom>().floor.color = Color.HSVToRGB(hue,.5f,.2f);
        Color wallColor = Color.HSVToRGB(hue,.5f,1f);
        foreach(SpriteRenderer sr in randomWalkRoomBase.GetComponent<RandomWalkRoom>().walls){
            sr.color = wallColor;
        }
    }

    public void Walk(int steps){
        
        PlaceRoom(); //place a starter room
        Vector2Int directionChoice = directions[Random.Range(0,directions.Count)];
        StartCoroutine(WalkRoutine());
        
        IEnumerator WalkRoutine(){
            for(int i = 0; i<steps; i++){
                
                //fancy stuff you didn't need to do
                if(i % turnAfter == 0){ //only turn after so many moves
                    List<Vector2Int> possibleDirections = new List<Vector2Int>();

                    foreach(Vector2Int d in directions){
                        if(!HasRoom(walkPos+d)){
                            possibleDirections.Add(d);
                        }
                    }

                    if(possibleDirections.Count == 0){
                        possibleDirections=directions;
                    }
                    

                    directionChoice = possibleDirections[Random.Range(0,possibleDirections.Count)];
                }
                
                //open up previous door step 1
                OpenDoor(roomDict[walkPos],directionChoice);

                //move step 2
                walkPos += directionChoice;

                //place new room step 3
                PlaceRoom();

                //open up room to previous step 4
                OpenDoor(roomDict[walkPos],-directionChoice);

                //wait
                yield return new WaitForSeconds(.1f);
            }
            yield return null;
        }

    }

    void PlaceRoom(){
        walkTransform.position = new Vector3(walkPos.x,walkPos.y); //visual helper
        if(roomDict.ContainsKey(walkPos)){
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
