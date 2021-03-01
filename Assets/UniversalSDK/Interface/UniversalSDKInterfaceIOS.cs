
#if UNITY_IOS

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using AOT;
using System.Reflection;

namespace GamePub.PubSDK
{
    public class NativeInterface
    {
        static NativeInterface()
        {
            var _ = GamePubSDK.Ins;
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_setup(string identifier);
        public static void SetupSDK(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_setup(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_login(string identifier,
                                                 int loginType,
                                                 int serviceType);
        public static void Login(string identifier,
                                 PubLoginType loginType,
                                 PubAccountServiceType serviceType)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_login(identifier, (int)loginType, (int)serviceType);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_logout(string identifier, int loginType);
        public static void Logout(string identifier, PubLoginType loginType)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_logout(identifier, (int)loginType);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_inAppPurchase(string identifier,
                                                         string pid,
                                                         string serverId,
                                                         string playerId,
                                                         string etc);
        public static void InAppPurchase(string identifier,
                                         string pid,
                                         string serverId,
                                         string playerId,
                                         string etc)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_inAppPurchase(identifier, pid, serverId, playerId, etc);
        }
        

        [DllImport("__Internal")]
        private static extern void pub_sdk_imageBanner(string identifier,
                                                       string ratioWidth,
                                                       string ratioHeight);
        public static void ImageBanner(string identifier, string ratioWidth, string ratioHeight)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_imageBanner(identifier, ratioWidth, ratioHeight);
        }

        

        
        [DllImport("__Internal")]
        private static extern void pub_sdk_openHelpURL(string identifier);
        public static void OpenHelpURL(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_openHelpURL(identifier);
        }

        

        private static bool IsInvalidRuntime(string identifier)
        {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.IPhonePlayer);
        }
    }
}
#endif