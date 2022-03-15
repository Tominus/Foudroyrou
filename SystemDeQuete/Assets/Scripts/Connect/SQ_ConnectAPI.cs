using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SQ_ConnectAPI
{
    const string QUEST_ID_NAME = "questID",
                 POSITION_NAME = "position", //?
                 LANGUAGE_ID_NAME = "languageID";

    public static IEnumerator GetQuest<T>(int _questID, SQ_LanguageID _languageID, Action<T> _validCallBack, Action _errorCallBack)
    {
        WWWForm _form = new WWWForm();
        _form.AddField(QUEST_ID_NAME, _questID);
        _form.AddField(LANGUAGE_ID_NAME, (int)_languageID);

        UnityWebRequest _request = UnityWebRequest.Get(SQ_BaseURL.QUEST_LINK);
        yield return _request.SendWebRequest();

        if (!string.IsNullOrEmpty(_request.error))
            Debug.LogError("SQ_ConnectAPI::GetQuest<T>() -> An error occur");

        string _text = _request.downloadHandler.text;
        if (_text.ToLower().Contains("error"))
        {
            Debug.LogError(_text);
            _errorCallBack?.Invoke();
        }
        else
        {
            T _item = JsonUtility.FromJson<T>(_text);
            _validCallBack?.Invoke(_item);
        }
    }
    public static IEnumerator AskForEndQuest(int _questID, SQ_LanguageID _languageID, Action<bool> _callBack, Action _errorCallBack)
    {
        WWWForm _form = new WWWForm();
        _form.AddField(QUEST_ID_NAME, _questID);
        _form.AddField(LANGUAGE_ID_NAME, (int)_languageID);

        UnityWebRequest _request = UnityWebRequest.Get(SQ_BaseURL.QUEST_LINK);
        yield return _request.SendWebRequest();

        if (!string.IsNullOrEmpty(_request.error))
            Debug.LogError("SQ_ConnectAPI::AskForEndQuest() -> An error occur");

        string _text = _request.downloadHandler.text;
        if (_text.ToLower().Contains("error"))
        {
            Debug.LogError(_text);
            _errorCallBack?.Invoke();
        }
        else
        {
            _callBack?.Invoke(JsonUtility.FromJson<bool>(_text));
        }
    }
}