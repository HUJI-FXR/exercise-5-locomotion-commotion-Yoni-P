using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportLimiter : MonoBehaviour
{
    private static int _maxTeleports = 3;
    private static int _teleportsUsed = 0;
    
    private TeleportationArea _teleportArea;

    private void OnEnable()
    {
        if (_teleportArea == null)
        {
            _teleportArea = GetComponent<TeleportationArea>();
        }
        _teleportArea.selectExited.AddListener(OnTeleportExit);
    }
    
    private void OnDisable()
    {
        _teleportArea.selectExited.RemoveListener(OnTeleportExit);
    }
    
    private void OnTeleportExit(SelectExitEventArgs args)
    {
        if (_teleportsUsed >= _maxTeleports)
        {
            _teleportArea.enabled = false;
        }
        else
        {
            _teleportsUsed++;
        }
        Debug.Log("Teleports used: " + _teleportsUsed);
    }

    private void OnDestroy()
    {
        _teleportsUsed = 0;
    }
}
