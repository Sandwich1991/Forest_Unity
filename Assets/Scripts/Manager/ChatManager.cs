using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager
{
    public void Says(GameObject who, Sprite img, float time)
    {
        GameObject worldSpaceCanvas = Managers.UI.SetWorldSpaceCanvas();

        GameObject Chatings = GameObject.Find("@Chatings");
        if (Chatings == null)
            Chatings = new GameObject { name = "@Chatings" };
        Chatings.transform.parent = worldSpaceCanvas.transform;
        
        
        GameObject bubble =
            Managers.Resource.Instantiate("UI/WorldSpace/ChatBubble/Bubble", Chatings.transform);

        Image imageComponent = Managers.Resource.Instantiate("UI/WorldSpace/ChatBubble/Image", bubble.transform)
            .GetComponent<Image>();
        imageComponent.sprite = img;
        
        bubble.transform.position = who.transform.position +
                                    Vector3.up * (who.transform.GetComponent<Collider>().bounds.size.y + 0.2f);
        bubble.transform.rotation = GameObject.Find("Main Camera").transform.rotation;

        Managers.Resource.Destroy(bubble.name, time);
    }
    
    public void Says(GameObject who, string text, float time)
    {
        GameObject worldSpaceCanvas = Managers.UI.SetWorldSpaceCanvas();

        GameObject Chatings = GameObject.Find("@Chatings");
        if (Chatings == null)
            Chatings = new GameObject { name = "@Chatings" };
        Chatings.transform.parent = worldSpaceCanvas.transform;
        
        
        GameObject bubble =
            Managers.Resource.Instantiate("UI/WorldSpace/ChatBubble/Bubble", Chatings.transform);

        Text textComponent = Managers.Resource.Instantiate("UI/WorldSpace/ChatBubble/Text", bubble.transform)
            .GetComponent<Text>();
        textComponent.text = text;
        
        bubble.transform.position = who.transform.position +
                                    Vector3.up * (who.transform.GetComponent<Collider>().bounds.size.y + 0.2f);
        bubble.transform.rotation = GameObject.Find("Main Camera").transform.rotation;

        Managers.Resource.Destroy(bubble.name, time);
    }

}
