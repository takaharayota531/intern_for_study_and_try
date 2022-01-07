/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine.UI;

namespace FancyScrollView
{
    public enum MovementType
    {
        Unrestricted = ScrollRect.MovementType.Unrestricted,
        Elastic = ScrollRect.MovementType.Elastic,//弾性
        Clamped = ScrollRect.MovementType.Clamped//クランプ
    }
    /*スクロールを範囲外まで引っ張った時の挙動*/
}
