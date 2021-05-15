using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTitle : MonoBehaviour {
	[SerializeField] List<GameObject> TitleList;

    void Awake() {
        bool visited = PlayerPrefs.GetInt("VisitedTitle", 0) != 0;
        
        if(!visited) {
            SetVisited();
            return;
        }
        SetRandomTitle();
    }

    public void SetRandomTitle() {
        foreach(GameObject o in TitleList) {
            o.SetActive(false);
        }

        TitleList[Random.Range(0, TitleList.Count)].SetActive(true);
    }

    void SetVisited() {
        PlayerPrefs.SetInt("VisitedTitle", 1);
    }
}
