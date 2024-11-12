using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Job
{
    Tanker,
    Dealer,
    Healer
}
public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public event Action OnUIUpdateEvent;
    public Job job = Job.Tanker;

    private void Awake()
    {
        Instance = this;
    }
    public void UIUpdate()
    {
        OnUIUpdateEvent?.Invoke();
    }
   

}
