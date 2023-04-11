using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Examples/Food Pellet SO" )]
public class FoodPelletSO : ScriptableObject
{
    public string foodType = "";
    public Color color;
    public int numberPickedUp = 0;
}
