/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollView.Example07
{
    class Cell : FancyScrollRectCell<ItemData, Context>
    {
        [SerializeField] Text message = default;
        [SerializeField] Image image = default;
        [SerializeField] Button button = default;

        private ItemData itemData;

        [SerializeField] private LayoutGroup layoutGroup;
        [SerializeField] private Image chatBoard;
        [SerializeField] private Text chatText;
        [SerializeField] private Image chatIcon;
        [SerializeField] private Sprite mineSprite;
        [SerializeField] private Sprite othersSprite;



        public override void Initialize()
        {
            button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
        }

        public override void UpdateContent(ItemData itemData)
        {
            Init(itemData);

            var selected = Context.SelectedIndex == Index;
            image.color = selected
                ? new Color32(0, 255, 255, 100)
                : new Color32(255, 255, 255, 77);
        }

        protected override void UpdatePosition(float normalizedPosition, float localPosition)
        {
            base.UpdatePosition(normalizedPosition, localPosition);

            // var wave = Mathf.Sin(normalizedPosition * Mathf.PI * 2) * 65;
            // transform.localPosition += Vector3.right * wave;
        }

        public void Init(ItemData data)
        {
            itemData = data;
            Debug.Log("chatdata");
            chatText.text = data.message;


            if (itemData.roll == ChatRoll.MINE)
            {
                chatIcon.sprite = mineSprite;
                layoutGroup.childAlignment = TextAnchor.MiddleRight;
                chatBoard.color = new Color(0, 2f, 0.1f);
                chatIcon.transform.SetSiblingIndex(1);
            }
            else if (itemData.roll == ChatRoll.OTHERS)
            {
                chatIcon.sprite = othersSprite;
                layoutGroup.childAlignment = TextAnchor.MiddleLeft;
                chatBoard.color = new Color(1, 1, 1);
                chatIcon.transform.SetSiblingIndex(0);
            }
        }

        // private IEnumerator CheckTextSize()
        // {
        //     yield return new WaitForEndOfFrame();
        //     if (chatBoard.rectTransform.sizeDelta.x > this.GetComponent<RectTransform>().sizeDelta.x * 0.5f)
        //     {
        //         chatBoard.GetComponent<LayoutElement>().preferredWidth =
        //             this.GetComponent<RectTransform>().sizeDelta.x * 0.5f;
        //     }
        // }
    }
}
