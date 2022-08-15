using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ForestTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Managers.Event.CameraEventOn("ForestEnter");
        Managers.Resource.Destroy(gameObject.name);
    }
}
