using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;


namespace FancyScrollView.Takahara
{
    public class CountNode : MonoBehaviour
    {
        [SerializeField] int index = 0;

        public void PlusIndex()
        {
            index += 1;
        }
    }
}