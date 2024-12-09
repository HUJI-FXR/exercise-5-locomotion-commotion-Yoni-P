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
    private static Action _teleportLimitReached;

    private void OnEnable()
    {
        if (_teleportArea == null)
        {
            _teleportArea = GetComponent<TeleportationArea>();
        }
        _teleportArea.selectExited.AddListener(OnTeleportExit);
        _teleportLimitReached += OnTeleportLimitReached;
    }
    
    private void OnDisable()
    {
        _teleportArea.selectExited.RemoveListener(OnTeleportExit);
        _teleportLimitReached -= OnTeleportLimitReached;
    }
    
    private void OnTeleportExit(SelectExitEventArgs args)
    {
        _teleportsUsed++;
        
        if (_teleportsUsed >= _maxTeleports)
        {
            _teleportLimitReached?.Invoke();
        }
        
        Debug.Log("Teleports used: " + _teleportsUsed);
    }
    
    private void OnTeleportLimitReached()
    {
        _teleportArea.enabled = false;
    }

    private void OnDestroy()
    {
        _teleportsUsed = 0;
    }
}
