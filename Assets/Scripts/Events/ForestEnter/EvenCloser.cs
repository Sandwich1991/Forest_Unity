using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCloser : MonoBehaviour
{
    public void EventClose()
    {
        Managers.Event.CameraEventOff();
    }
}
