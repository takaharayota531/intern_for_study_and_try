using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatNode : MonoBehaviour
{
    private ChatData chatData;

    [SerializeField] private LayoutGroup layoutGroup;
    [SerializeField] private Image chatBoard;
    [SerializeField] private Text chatText;
    [SerializeField] private Image chatIcon;
    [SerializeField] private Sprite mineSprite;
    [SerializeField] private Sprite othersSprite;


    public void Init(ChatData data)
    {
        chatData = data;
        Debug.Log("chatdata");
        chatText.text = data.body;


        if (chatData.roll == ChatRoll.MINE)
        {
            chatIcon.sprite = mineSprite;
            layoutGroup.childAlignment = TextAnchor.MiddleRight;
            chatBoard.color = new Color(0, 2f, 0.1f);
            chatIcon.transform.SetSiblingIndex(1);
        }
        else if (chatData.roll == ChatRoll.OTHERS)
        {
            chatIcon.sprite = othersSprite;
            layoutGroup.childAlignment = TextAnchor.MiddleLeft;
            chatBoard.color = new Color(1, 1, 1);
            chatIcon.transform.SetSiblingIndex(0);
        }
    }

    private IEnumerator CheckTextSize()
    {
        yield return new WaitForEndOfFrame();
        if (chatBoard.rectTransform.sizeDelta.x > this.GetComponent<RectTransform>().sizeDelta.x * 0.5f)
        {
            chatBoard.GetComponent<LayoutElement>().preferredWidth =
                this.GetComponent<RectTransform>().sizeDelta.x * 0.5f;
        }
    }
}