using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {
	public GameObject Crown;

    void OnEnable() {
        Crown.SetActive(!GameManager.EzMode);
    }
}
