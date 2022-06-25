using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FancyScrollView.Takahara;
using EasingCore;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example07;





public class ChatSystem : MonoBehaviour
{





    private int id = 0;
    [SerializeField] private InputField chatInputField;
    [SerializeField] private GameObject chatNodePrefab;
    [SerializeField] private GameObject content;
    [SerializeField] private Example07 example07;
    [SerializeField] ScrollView scrollView = default;

    [SerializeField] private List<ChatData> chatNodeDataList = new List<ChatData>();
    // [SerializeField] private CountNode countNode;



    [SerializeField] private float paddingTop=10f;
    [SerializeField] private float paddingBottom=10f;
    [SerializeField] private VerticalLayoutGroup contentVertical;
    [SerializeField] private int dataCount;



    public void OnClickMineButton()
    {
        CreateChatNode(ChatRoll.MINE);
    }

    public void OnClickOthersButton()
    {
        CreateChatNode(ChatRoll.OTHERS);
    }
    
    void Start(){
        RayoutControl();


    }

    void CreateChatNode(ChatRoll roll)
    {
        id++;
        string str = chatInputField.text;
        chatInputField.text = "";

        ChatData data = new ChatData(id, roll, str);
        chatNodeDataList.Add(data);

    //     var chatNode = (GameObject)Instantiate<GameObject>(chatNodePrefab, content.transform, false);
      
    //    chatNode.GetComponent<ChatNode>().Init(data);
        GenerateCells(id);


        // Debug.Log(("id:" + id + " roll:" + roll.ToString() + " body:" + str));
    }



    public void GenerateCells(int dataCount)
    {
        // var items = Enumerable.Range(0, dataCount)
        //     .Select(i => new ItemData($"Cell {i}"))
        //     .ToArray();
        List<ItemData> items = new List<ItemData>();
        // for (int i = 0; i < dataCount;i++){
        //     ItemData tmp = new ItemData();
        //     tmp.Init(chatNodeDataList[i]);
        //     Debug.Log("tmp.init.message" + tmp.Message);
        //     items.Add(tmp);

        // }
        for (int i = 0; i < dataCount; i++)
        {
            ItemData tmp = new ItemData(chatNodeDataList[i]);
            items.Add(tmp);

        }
       

        scrollView.UpdateData(items.ToArray());
        //  SelectCell();
    }



    public void RayoutControl(){
        scrollView.PaddingTop = paddingTop;
        scrollView.PaddingBottom = paddingBottom;
        scrollView.Spacing = 30f;

    }
}

public enum ChatRoll
    {
        MINE,
        OTHERS
    }

    public class ChatData
    {
        public int id{ get; set; }
        public ChatRoll roll;
        public string body;

        public ChatData(int id, ChatRoll roll, string body)
        {
            this.id = id;
            this.roll = roll;
            this.body = body;
        }
    }
