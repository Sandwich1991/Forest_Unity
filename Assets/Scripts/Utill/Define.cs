using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MouseEvent
    {
        Click,
        Press,
    }
    
    public enum State
    {
        Idle,
        Move,
    }
    
    public enum CameraMode
    {
        OnEvent,
        QuarterView,
        TopView,
    }
    
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    
    public enum Layer
    {
        Ground = 3,
        NPC = 6,
        Block = 7,
    }
    
    public enum Scene
    {
        Unknown,
        Login,
        Game,
    }
    
    public enum CameraSubject
    {
        Player,
        NPC,
    }
    
    public enum AnimationEvent
    {
        Null,
        EnterForest,
        BearAppear,
    }
    
}
