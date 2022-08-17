using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCController : BaseController
{
    public void Greetings()
    {
        Managers.Chat.Says(gameObject, "Greetings!", 3f);
    }
    protected override void init()
    {
        
    }
}
