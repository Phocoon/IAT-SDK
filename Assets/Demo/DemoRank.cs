using System.Collections;
using System.Collections.Generic;
using Phocoon.IAT;
using UnityEngine;

public class DemoRank : MonoBehaviour
{
    public DemoRankItem rankItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRank()
    {
        this.transform.DetachChildren();
        var rankList = PhocoonIAT.Instance.GetRankList();

        for (int i = 0; i < rankList.Count; i++)
        {
            var item = Instantiate(rankItemPrefab, transform);
            item.SetData(rankList[i].name, rankList[i].avatar, rankList[i].score);
        }
    }
}
