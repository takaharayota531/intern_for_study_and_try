using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FancyScrollView;
using UnityEngine.UI;

public class MyScrollCell : FancyCell<MyCellData>
{
    public Text message;

    public override void UpdateContent(MyCellData itemData)
    {
        message.text = itemData.Message;
    }

    public override void UpdatePosition(float position)
    {
        var pos = transform.localPosition;
        pos.y = Mathf.Lerp(288, -288, position);
        transform.localPosition = pos;
    }
}