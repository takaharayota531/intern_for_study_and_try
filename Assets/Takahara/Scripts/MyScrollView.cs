using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FancyScrollView.Takahara
{
    public class MyScrollView : FancyScrollView<MyItemData>
    {
        [SerializeField] Scroller scroller = default;
        [SerializeField] private GameObject cellPrefab = default;


        protected override GameObject CellPrefab => cellPrefab;

        protected override void Initialize()
        {
            base.Initialize();
            scroller.OnValueChanged(UpdatePosition);
        }

        public void UpdateData(IList<MyItemData> items)
        {
            UpdateContents(items);
            scroller.SetTotalCount(items.Count);
        }
    }
}