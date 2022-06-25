using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private Image target;
    [SerializeField] private Color color;

    public void OnClickButtonColor(){
        target.color = Color.red;
        Debug.Log("色変化が起きました");
    }
}
