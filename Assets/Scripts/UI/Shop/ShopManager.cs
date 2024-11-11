using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public event Action OnUIUpdateEvent;
    private void Awake()
    {
        Instance = this;
    }
    public void UIUpdate()
    {
        OnUIUpdateEvent?.Invoke();
    }
   

}
