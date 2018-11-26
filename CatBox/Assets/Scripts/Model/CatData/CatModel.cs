using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "CreateCatData/NewCatData", order = 1)]
public class CatModel : ScriptableObject
{
    public int ID;
    public string imageTargetID;
    public string catName;
    public string scoreMultiplier;
}
