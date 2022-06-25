using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{

    private bool OnAndOff = false;
    [SerializeField] private Transform panel;
    public void OnClickButton(){
        if(!OnAndOff){
            panel.gameObject.SetActive(true);
            OnAndOff = true;
        }
        else if(OnAndOff){
            panel.gameObject.SetActive(false);
            OnAndOff = false;
        }

    }
}
