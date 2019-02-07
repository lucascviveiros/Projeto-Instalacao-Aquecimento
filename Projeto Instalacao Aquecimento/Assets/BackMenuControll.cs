using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BackMenuControll : MonoBehaviour {
    public Button btn_backmenu;
    // Use this for initialization
    void Start () {
        Button btn = btn_backmenu.GetComponent<Button>();
        btn.onClick.AddListener(BackMenu);
    }

    void BackMenu()
    {
        SceneManager.LoadScene("SceneMenu-0"); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
