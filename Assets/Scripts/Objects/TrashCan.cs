using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    

public class TrashCan : MonoBehaviour
{
    public InformationSystem informationSystem;
    void OnMouseDown(){
        if(PlayerController.Instance.IsUsingTrashCan){

            informationSystem.TrashCanUsed();
        }
            

    }
}
}