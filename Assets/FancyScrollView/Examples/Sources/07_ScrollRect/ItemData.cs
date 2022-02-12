// /*
//  * FancyScrollView (https://github.com/setchi/FancyScrollView)
//  * Copyright (c) 2020 setchi
//  * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
//  */





class ItemData
{
    public string message { get; }
    public ChatRoll roll{ get; }

    public int id;

    public ItemData(ChatData chatData)
    {
        this.message = chatData.body;
        this.roll = chatData.roll;
        this.id = chatData.id;

    }
}












// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// namespace FancyScrollView.Example07
// {

    
    
//     public class ItemData : MonoBehaviour {
//         private ChatData chatData;

//         [SerializeField] private LayoutGroup layoutGroup;
//         [SerializeField] private Image chatBoard;
//         [SerializeField] private Text chatText;
//         [SerializeField] private Image chatIcon;
//         [SerializeField] private Sprite mineSprite;
//         [SerializeField] private Sprite othersSprite;
//         public string Message;


//         public void Init(ChatData data)
//         {
//             chatData = data;
//             Debug.Log("chatdata"+chatData);
//             Debug.Log("data.body" + data.body);
//             Debug.Log("data.id" + data.roll);
//             Message = data.body;
//             Debug.Log("chatText.text" + Message);
//             chatText.text = data.body;
           


//             if (chatData.roll == ChatRoll.MINE)
//             {
//                 chatIcon.sprite = mineSprite;
//                 layoutGroup.childAlignment = TextAnchor.MiddleRight;
//                 chatBoard.color = new Color(0, 2f, 0.1f);
//                 chatIcon.transform.SetSiblingIndex(1);
//             }
//             else if (chatData.roll == ChatRoll.OTHERS)
//             {
//                 chatIcon.sprite = othersSprite;
//                 layoutGroup.childAlignment = TextAnchor.MiddleLeft;
//                 chatBoard.color = new Color(1, 1, 1);
//                 chatIcon.transform.SetSiblingIndex(0);
//             }
//         }

//         private IEnumerator CheckTextSize()
//         {
//             yield return new WaitForEndOfFrame();
//             if (chatBoard.rectTransform.sizeDelta.x > this.GetComponent<RectTransform>().sizeDelta.x * 0.5f)
//             {
//                 chatBoard.GetComponent<LayoutElement>().preferredWidth =
//                     this.GetComponent<RectTransform>().sizeDelta.x * 0.5f;
//             }
//         }
        
//     }
   
   
    
// }
