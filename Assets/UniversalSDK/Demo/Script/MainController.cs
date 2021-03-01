using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Universal.UniversalSDK;

public class MainController : MonoBehaviour
{
    public Image userImage;
    public Text displayNameText;
    public Text uniqueIdText;
    public Text channelIdText;
    public Text emailText;

    public Text rawJsonText;

    string imgUrl = "https://user-images.githubusercontent.com/20632507/108068287-3c637d80-70a5-11eb-94f6-4aa605df1f76.jpeg";
    string helpUrl = "https://support.google.com/?hl=ko";

    void Start()
    {
        var scopes = new string[] { "boxer_unity1000", "boxer_unity2000" };

        UniversalSDK.Ins.SetupSDK(scopes, result =>
        {
            result.Match(
                value =>
                {
                    //Debug.Log("code = " + value.Code + ", msg = " + value.Msg);
                    UpdateRawSection(value);
                },
                error =>
                {
                    //Debug.LogError("code = " + error.Code + ", msg = " + error.Message);
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickGoogleLogin()
    {
        UniversalSDK.Ins.Login(LoginType.GOOGLE,
            AccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateRawSection(value);
                        displayNameText.text = value.UserProfile.DisplayName;
                        uniqueIdText.text = value.UserProfile.UniqueId;
                        channelIdText.text = value.UserProfile.ChannelId;
                        emailText.text = value.UserProfile.Email;
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }
    public void OnClickFacebookLogin()
    {
        UniversalSDK.Ins.Login(LoginType.FACEBOOK,
            AccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateRawSection(value);
                        displayNameText.text = value.UserProfile.DisplayName;
                        uniqueIdText.text = value.UserProfile.UniqueId;
                        channelIdText.text = value.UserProfile.ChannelId;
                        emailText.text = value.UserProfile.Email;
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }
    public void OnClickGuestLogin()
    {
        UniversalSDK.Ins.Login(LoginType.GUEST,
            AccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateRawSection(value);
                        displayNameText.text = value.UserProfile.DisplayName;
                        uniqueIdText.text = value.UserProfile.UniqueId;
                        channelIdText.text = value.UserProfile.ChannelId;
                        emailText.text = value.UserProfile.Email;
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }
    public void OnClickAppleLogin()
    {
        UniversalSDK.Ins.Login(LoginType.APPLE,
            AccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateRawSection(value);
                        displayNameText.text = value.UserProfile.DisplayName;
                        uniqueIdText.text = value.UserProfile.UniqueId;
                        channelIdText.text = value.UserProfile.ChannelId;
                        emailText.text = value.UserProfile.Email;
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }
    public void OnClickLogout()
    {
        UniversalSDK.Ins.Logout(LoginType.GOOGLE, result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }
    public void OnClickInPurchase1200()
    {
        UniversalSDK.Ins.InAppPurchase("boxer_unity1000", result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }
    public void OnClickInPurchase2500()
    {
        UniversalSDK.Ins.InAppPurchase("boxer_unity2000", result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }
    public void OnClickImageBanner()
    {
        UniversalSDK.Ins.ImageBanner("9", "16", imgUrl, result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickOpenCustomTabView()
    {
        UniversalSDK.Ins.OpenCustomTabView(helpUrl, result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void UpdateRawSection(object obj)
    {
        if (obj == null)
        {
            rawJsonText.text = "null";
            return;
        }
        var text = JsonUtility.ToJson(obj);
        if (text == null)
        {
            rawJsonText.text = "Invalid Object";
            return;
        }
        rawJsonText.text = text + "\n\n" + rawJsonText.text;
        var scrollContentTransform = (RectTransform)rawJsonText.gameObject.transform.parent;
        scrollContentTransform.localPosition = Vector3.zero;
    }
}
