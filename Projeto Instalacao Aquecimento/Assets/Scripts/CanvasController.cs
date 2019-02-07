using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using System;
using System.Reflection;

public class CanvasController : MonoBehaviour {

    public Button btn_start;
    public Button btn_scene1;
    public Button btn_scene2;
    public Button btn_scene3;
    public Button btn_scene4;
    public Camera cam;
    
	void Start () {

        if (cam.enabled) { 
            if (cam.GetComponent<VuforiaBehaviour>() != null)
                cam.GetComponent<VuforiaBehaviour>().enabled = false;
        }

        if (SceneManager.GetSceneByName("scene-start").isLoaded)
        {
            Button start = btn_start.GetComponent<Button>();
            start.onClick.AddListener(StartAr);
        }

        if (SceneManager.GetSceneByName("SceneMenu-0").isLoaded)
        {
            Button btn_anim1 = btn_scene1.GetComponent<Button>();
            btn_anim1.onClick.AddListener(FirstScene);

            Button btn_anim2 = btn_scene2.GetComponent<Button>();
            btn_anim2.onClick.AddListener(SecondScene);

            Button btn_anim3 = btn_scene3.GetComponent<Button>();
            btn_anim3.onClick.AddListener(ThirdScene);

            Button btn_anim4 = btn_scene4.GetComponent<Button>();
            btn_anim4.onClick.AddListener(FourthScene);

        }
        
    }

    void StartAr()
    {
        SceneManager.LoadScene("SceneMenu-0");
    }

    void FirstScene()
    {
        cam.GetComponent<VuforiaBehaviour>().enabled = true;
        SceneManager.LoadScene("SceneMarkerAdesivo-1");
    }

    void SecondScene()
    {
        cam.GetComponent<VuforiaBehaviour>().enabled = true;
        SceneManager.LoadScene("SceneAnimHololens-2");
    }

    void ThirdScene()
    {
        cam.GetComponent<VuforiaBehaviour>().enabled = true;
        SceneManager.LoadScene("SceneVirtualButton-3");
    }


    void FourthScene()
    {
        cam.GetComponent<VuforiaBehaviour>().enabled = true;
        SceneManager.LoadScene("SceneInstalacao-4");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
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
