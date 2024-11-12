using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopJobSelectButton : MonoBehaviour
{
    

    public void SelectTanker()
    {
        ShopManager.Instance.job = Job.Tanker;
        ShopManager.Instance.UIUpdate();
    }

    public void SelectDealer()
    {
        ShopManager.Instance.job = Job.Dealer;
        ShopManager.Instance.UIUpdate();
    }
    public void SelectHealer()
    {
        ShopManager.Instance.job = Job.Healer;
        ShopManager.Instance.UIUpdate();
    }
}
