using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FancyScrollView.Takahara
{
    public class MyItemData : MonoBehaviour
    {
        public string Message { get; set; }


        public MyItemData(string message)
        {
            Message = message;
        }
    }
}