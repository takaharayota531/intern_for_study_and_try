// using UnityEngine.UI;
// using EasingCore;
// using System;
// using UnityEngine;
// using UnityEngine.EventSystems;



// namespace FancyScrollView
// {
//     public class Shakyo2 : UIBehaviour, IPointerUpHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,
//             IDragHandler, IScrollHandler
//     {

//         [SerializeField] RectTransform viewport = default;

//         public float ViewportSize => scrollDirection == ScrollDirection.Horizontal
//                 ? viewport.rect.size.x
//                 : viewport.rect.size.y;

//         [SerializeField] ScrollDirection scrollDirection = ScrollDirection.Vertical;

//         public ScrollDirection ScrollDirection => scrollDirection;

//         [SerializeField] MovementType movementType = MovementType.Elastic;

//         /// <summary>
//         /// コンテンツがスクロール範囲を越えて移動するときに使用する挙動.
//         /// →これは一体どういう役目？
//         /// </summary>
//         public MovementType MovementType
//         {
//             get => movementType;
//             set => movementType = value;
//         }
//         [SerializeField] float elasticity = 0.1f;

//         /// <summary>
//         /// コンテンツがスクロール範囲を越えて移動するときに使用する弾力性の量.
//         /// これもいったいどういう役目なんだろうか
//         /// </summary>
//         public float Elasticity
//         {
//             get => elasticity;
//             set => elasticity = value;
//         }
//         [SerializeField] float scrollSensitivity = 1f;

//         /// <summary>
//         /// <see cref="ViewportSize"/> の端から端まで Drag したときのスクロール位置の変化量.
//         /// </summary>
//         public float ScrollSensitivity
//         {
//             get => scrollSensitivity;
//             set => scrollSensitivity = value;
//         }
//         [SerializeField] bool inertia = true;

//         /// <summary>
//         /// 慣性を使用するかどうか. <c>true</c> を指定すると慣性が有効に, <c>false</c> を指定すると慣性が無効になります.
//         /// これ結構大事そう
//         /// </summary>
//         public bool Inertia
//         {
//             //この記法早くできるようになろう
//             get => inertia;
//             set => inertia = value;
//         }
//          [SerializeField] float decelerationRate = 0.03f;

//          /// <summary>
//         /// スクロールの減速率. <see cref="Inertia"/> が <c>true</c> の場合のみ有効です.
//         /// </summary>
//         public float DecelerationRate
//         {
//             get => decelerationRate;
//             set => decelerationRate = value;
//         }

//         [SerializeField]
//         Snap snap = new Snap
//         {
//             Enable = true,
//             VelocityThreshold = 0.5f,
//             Duration = 0.3f,
//             Easing = Ease.InOutCubic
//         };

//         /// <summary>
//         /// <c>true</c> ならスナップし, <c>false</c>ならスナップしません.
//         /// </summary>
//         /// <remarks>
//         /// スナップを有効にすると, 慣性でスクロールが止まる直前に最寄りのセルへ移動します.
//         /// </remarks>
//         public bool SnapEnabled
//         {
//             get => snap.Enable;
//             set => snap.Enable = value;
//         }
//         [SerializeField] bool draggable = true;

//         /// <summary>
//         /// Drag 入力を受付けるかどうか.
//         /// </summary>
//         public bool Draggable
//         {
//             get => draggable;
//             set => draggable = value;
//         }

//         [SerializeField] Scrollbar scrollbar = default;

//         /// <summary>
//         /// スクロールバーのオブジェクト.
//         /// </summary>
//         public Scrollbar Scrollbar => scrollbar;

//          /// <summary>
//         /// 現在のスクロール位置.
//         /// </summary>
//         /// <value></value>
//         public float Position
//         {
//             get => currentPosition;
//             set
//             {
//                 autoScrollState.Reset();
//                 velocity = 0f;
//                 dragging = false;

//                 UpdatePosition(value);
//             }
//         }
//         readonly AutoScrollState autoScrollState = new AutoScrollState();

//         Action<float> onValueChanged;
//         Action<int> onSelectionChanged;

//         Vector2 beginDragPointerPosition;
//         float scrollStartPosition;
//         float prevPosition;
//         float currentPosition;

//         int totalCount;

//         bool hold;
//         bool scrolling;
//         bool dragging;
//         float velocity;

//         [Serializable]
//         class Snap
//         {
//             public bool Enable;
//             public float VelocityThreshold;
//             public float Duration;
//             public Ease Easing;
//         }

//         static readonly EasingFunction DefaultEasingFunction = Easing.Get(Ease.OutCubic);

//         class AutoScrollState
//         {
//             public bool Enable;
//             public bool Elastic;
//             public float Duration;
//             public EasingFunction EasingFunction;
//             public float StartTime;
//             public float EndPosition;

//             public Action OnComplete;

//             public void Reset()
//             {
//                 Enable = false;
//                 Elastic = false;
//                 Duration = 0f;
//                 StartTime = 0f;
//                 EasingFunction = DefaultEasingFunction;
//                 EndPosition = 0f;
//                 OnComplete = null;
//             }

//             public void Complete()
//             {
//                 OnComplete?.Invoke();
//                 Reset();
//             }
//         }
//         protected override void Start()
//         {
//             base.Start();

//             if (scrollbar)
//             {
//                 scrollbar.onValueChanged.AddListener(x => UpdatePosition(x * (totalCount - 1f), false));
//             }
//         }
//         /// <summary>
//         /// スクロール位置が変化したときのコールバックを設定します.
//         /// </summary>
//         /// <param name="callback">スクロール位置が変化したときのコールバック.</param>
//         public void OnValueChanged(Action<float> callback) => onValueChanged = callback;

//         /// <summary>
//         /// 選択位置が変化したときのコールバックを設定します.
//         /// </summary>
//         /// <param name="callback">選択位置が変化したときのコールバック.</param>
//         public void OnSelectionChanged(Action<int> callback) => onSelectionChanged = callback;

//         /// <summary>
//         /// アイテムの総数を設定します.
//         /// </summary>
//         /// <remarks>
//         /// <paramref name="totalCount"/> を元に最大スクロール位置を計算します.
//         /// </remarks>
//         /// <param name="totalCount">アイテムの総数.</param>
//         public void SetTotalCount(int totalCount) => this.totalCount = totalCount;










//     }
// }
