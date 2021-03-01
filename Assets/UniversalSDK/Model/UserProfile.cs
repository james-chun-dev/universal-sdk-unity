using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class UserProfile
    {
        [SerializeField]
        private string uniqueId = "";
        [SerializeField]
        private string displayName = "";
        [SerializeField]
        private string channelId = "";
        [SerializeField]
        private string email = "";

        public string UniqueId { get { return uniqueId; } }

        public string DisplayName { get { return displayName; } }

        public string ChannelId { get { return channelId; } }

        public string Email { get { return email; } }
    }
}