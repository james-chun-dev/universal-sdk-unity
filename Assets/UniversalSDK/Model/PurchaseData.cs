using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class PurchaseData
    {
        [SerializeField]
        private string orderId = "";
        [SerializeField]
        private string packageName = "";
        [SerializeField]
        private string productId = "";
        [SerializeField]
        private string purchaseToken = "";
        [SerializeField]
        private int     purchaseState = 0;
        [SerializeField]
        private long    purchaseTime = 0;        

        public string OrderId { get { return orderId; } }

        public string PackageName { get { return packageName; } }

        public string ProductId { get { return productId; } }

        public string PurchaseToken { get { return purchaseToken; } }

        public int  PurchaseState { get { return purchaseState; } }
        public long PurchaseTime { get { return purchaseTime; } }
    }
}