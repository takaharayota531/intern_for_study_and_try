using System.Collections;
using System.Collections.Generic;
using FancyScrollView;
using FancyScrollView.Example01;
using UnityEngine;
using UnityEngine.UI;


namespace FancyScrollView.Takahara
{
    class MyScrollViewCell : FancyCell<MyItemData>
    {
        [SerializeField] private Text message;


        public override void UpdateContent(MyItemData itemData)
        {
            message.text = itemData.Message;
        }

        private float currentPosition = 0;

        public override void UpdatePosition(float position)
        {
            currentPosition = position;
        }
    }
}