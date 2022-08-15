using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public void Greetings()
    {
        GameObject greetings = Managers.UI.Says(gameObject,"Greetings!");
        Destroy(greetings,3f);
    }

    private void Update()
    {
        
    }
}
