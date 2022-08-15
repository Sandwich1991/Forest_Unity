using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCController : MonoBehaviour
{
    public void Greetings()
    {
        string[] lines = new string[]{"Hello!", "I'm Jason!", "Greetings!"};

        string[] line = new string[1];

        line[0] = lines[Random.Range(0, lines.Length)];
        
        StartCoroutine(MakeBubble(line, 3f));

    }
    public void Says()
    {
        string text = "Greetings!#I'm Jason!# HAHAHA!";

        string[] lines = text.Split('#');

        StartCoroutine(MakeBubble(lines, 3f));
    }

    IEnumerator MakeBubble(string[] lines, float time)
    {
        if (lines == null)
            yield break;

        foreach (string line in lines)
        {
            GameObject bubble = Managers.UI.Says(gameObject, line);
            yield return new WaitForSeconds(time);
            Destroy(bubble);
        }
    }
    
}
