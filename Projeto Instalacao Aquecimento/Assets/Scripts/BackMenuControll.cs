using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;


public class BackMenuControll : MonoBehaviour {
    public Button btn_backmenu;

	void Start () {
        Button btn = btn_backmenu.GetComponent<Button>();
        btn.onClick.AddListener(BackMenu);
    }

	void BackMenu()
	{
		SceneManager.LoadScene("SceneMenu-0");
	}


	private void Exit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
}
