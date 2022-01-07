using System;
using System.Collections.Generic;
using UnityEngine;
using EasingCore;
using FancyScrollView;

public class MyScrollView : FancyScrollRect<MyCellData, Context>
{
    [SerializeField] private float cellSize = 100f;
    [SerializeField] private GameObject cellPrefab = default;

    protected override float CellSize => cellSize;
    protected override GameObject CellPrefab => cellPrefab;
}