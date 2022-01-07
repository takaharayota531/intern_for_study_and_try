using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace FancyScrollView.Takahara
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MyScrollView scrollView = default;
        [SerializeField] private CountNode countNode;


        private void Start()
        {
            var items = Enumerable.Range(0, 20)
                .Select(i => new MyItemData($"Cell {i}"))
                .ToArray();
            scrollView.UpdateData(items);
        }
    }
}