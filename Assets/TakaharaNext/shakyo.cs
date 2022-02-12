// using System.Collections.Generic;
// using UnityEngine;


// namespace pra{


//     public abstract class shakyo<TItemData,TContext>:MonoBehaviour where TContext : class, new ()
//    {
//        [SerializeField, Range(1e-2f, 1f)] protected float cellInterval = 0.2f;

//         /// <summary>
//         /// スクロール位置の基準
//         /// 
//         /// </summary>
//         /// <returns></returns>
//         [SerializeField, Range(0f, 1f)] protected float scrollOffset = 0.5f;

//         [SerializeField] protected bool loop = false;
//         /// <summary>
//         /// cellの親要素
//         /// </summary>
//         /// <returns></returns>
//         [SerializeField] protected Transform cellContainer = default;
//         readonly IList<FancyCell<TItemData, TContext>> pool = new List<FancyCell<TItemData, TContext>>();
//         protected bool initialized;
//         /// <summary>
//         /// 現在のスクロール位置
//         /// </summary>
//         protected float currentPosition;
//         protected abstract GameObject CellPrefab { get; }
//         /// <summary>
//         /// Item一覧のデータ
//         /// </summary>
//         /// <typeparam name="TItemData"></typeparam>
//         /// <returns></returns>
//         protected IList<TItemData> ItemsSource { get; set; } = new List<TItemData>();

//         protected TContext Context { get; } = new TContext();

//         protected virtual void Initialize() { }
//         /// <summary>
//         /// 渡されたアイテム一覧に基づいて表示内容を更新する
//         /// </summary>
//         /// <param name="itemsSource"></param>
//         protected virtual void UpdateContents(IList<TItemData> itemsSource)
//         {
//             ItemsSource = itemsSource;
//             Refresh();
//         }
//         /// <summary>
//         /// cellのレイアウトを強制的に更新する
//         /// </summary>
//         protected virtual void Relayout() => UpdatePosition(currentPosition, false);
//         /// <summary>
//         /// cellのレイアウトと表示内容を強制的に更新する
//         /// </summary>
//         protected virtual void Refresh() => UpdatePosition(currentPosition, true);

//         /// <summary>
//         /// スクロール位置の更新
//         /// </summary>
//         /// <param name="position"></param>
//         protected virtual void UpdatePosition(float position) => UpdatePosition(position, false);

//         void UpdatePosition(float position,bool forceRefresh){

//             if(!initialized){
//                 Initialize();
//                 initialized = true;
//             }
//             currentPosition = position;

//             var p = position - scrollOffset / cellInterval;
//             var firstIndex = Mathf.CeilToInt(p);
//             var firstPosition = (Mathf.Ceil(p) - p) * cellInterval;

//             if(firstPosition+pool.Count*cellInterval<1f){
//                 ResizePool(firstPosition);
//             }
//             UpdateCells(firstPosition, firstIndex, forceRefresh);

//         }
//         void ResizePool(float firstPosition){
//             Debug.Assert(CellPrefab != null);
//             Debug.Assert(cellContainer != null);

//             var addCount = Mathf.CeilToInt((1 - firstPosition) / cellInterval) - pool.Count;
//             for (var i = 0; i < addCount;i++){
//                 var cell=Instantiate(CellPrefab,cellContainer).GetComponent<FancyCell<TItemData, TContext>>();
//                 if (cell == null)
//                 {
//                     throw new MissingComponentException(string.Format(
//                         "FancyCell<{0}, {1}> component not found in {2}.",
//                         typeof(TItemData).FullName, typeof(TContext).FullName, CellPrefab.name));
//                 }
//                 cell.SetContext(Context);
//                 cell.Initialize();
//                 cell.SetVisible(false);
//                 pool.Add(cell);

//             }

//         }

//         void UpdateCells(float firstPosition, int firstIndex, bool forceRefresh)
//         {
//             for (var i = 0; i < pool.Count; i++)
//             {
//                 var index = firstIndex + i;
//                 var position = firstPosition + i * cellInterval;
//                 var cell = pool[CircularIndex(index, pool.Count)];

//                 if (loop)
//                 {
//                     index = CircularIndex(index, ItemsSource.Count);
//                 }
//                 if (index < 0 || index >= ItemsSource.Count || position > 1f)
//                 {
//                     cell.SetVisible(false);
//                     continue;
//                 }
//                 if (forceRefresh || cell.Index != index || !cell.IsVisible)
//                 {
//                     cell.Index = index;
//                     cell.SetVisible(true);
//                     cell.UpdateContent(ItemsSource[index]);

//                     //ここまで
//                 }

//                 cell.UpdatePosition(position);
//             }

//             int CircularIndex(int i, int size) => size < 1 ? 0 : i < 0 ? size - 1 + (i + 1) % size : i % size;

// #if UNITY_EDITOR
//     bool cachedLoop;
//     float cachedCellInterval,cachedScrollOffset;

//     void LateUpdate() {
//         if(cachedLoop!=loop||
//         cachedCellInterval != cellInterval ||
//         cachedScrollOffset !=ScrollOffset){
//             cachedLoop=loop;
//             cachedCellInterval=cellInterval;
//             cachedScrollOffset=scrollOffset;
//             UpdatePosition(currentPosition);
//         }
        
//     }

// #endif
//         }




//     }
//     public sealed class NullContext { }

//     /// <summary>
//     /// TContextが不要なことに対応している
//     /// </summary>
//     /// <typeparam name="TItemData"></typeparam>
//     public abstract class FancyScrollView<TItemData> : FancyScrollView<TItemData, NullContext> { }
// }