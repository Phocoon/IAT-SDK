using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
 


public class DemoRankItem : MonoBehaviour
{
    public Text Name;
    public Text Score;
    public Image Avatar;

    public void SetData(string name, string url, int score)
    {
        Name.text = name;
        Score.text = score.ToString();
        GetImageByUnityWebRequest(Avatar, url);
    }



    public void GetImageByUnityWebRequest(Image _imageComp, string _url)
    {
        StartCoroutine(UnityWebRequestGetData(_imageComp, _url));
    }

     IEnumerator UnityWebRequestGetData(Image _imageComp, string _url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(_url)) 
        {
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.ConnectionError) Debug.Log(uwr.error);
            else
            {
                if (uwr.isDone)
                {
                    int width = 200;
                    int height = 200;
                    Texture2D texture2d = new Texture2D(width, height);
                    texture2d = DownloadHandlerTexture.GetContent(uwr);
                    Sprite tempSprite = Sprite.Create(texture2d, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
                    _imageComp.sprite = tempSprite;
                    Resources.UnloadUnusedAssets();
                }
            }
        }
    }
}
