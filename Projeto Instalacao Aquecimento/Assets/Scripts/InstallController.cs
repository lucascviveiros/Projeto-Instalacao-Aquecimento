using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstallController : MonoBehaviour {

    private Animator anim;
    private AnimatorClipInfo[] m_AnimatorClipInfo;
    public GameObject mRoscas;
    public GameObject mAdaptadores;
    public Button btn_next;
    public Button btn_back;
    public Text mText;

	void Start () {
        mText.text = "Place the adapters";

        mAdaptadores.GetComponent<Renderer>().enabled = true;
        mAdaptadores.SetActive(true);

       mRoscas.GetComponent<Renderer>().enabled = false;
       mRoscas.SetActive(false);

        Button btn = btn_next.GetComponent<Button>();
        btn.onClick.AddListener(NextAnimation);

        Button btn2 = btn_back.GetComponent<Button>();
        btn2.onClick.AddListener(BackAnimation);

        m_AnimatorClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log("Starting clip : " + m_AnimatorClipInfo[0].clip);

        GetComponent<Animator>().Play("anim_all_install");

    }

    private void NextAnimation()
    {
        mText.text = "Fit the screws and turn";
        mRoscas.GetComponent<Renderer>().enabled = true;
        mRoscas.SetActive(true);
        GetComponent<Animator>().Play("mAnim_rosca");

    }

    private void BackAnimation()
    {
        mText.text = "Place the adapters";
        mRoscas.GetComponent<Renderer>().enabled = false;
        mRoscas.SetActive(false);
        GetComponent<Animator>().Play("mAnim_adap");
    }
	
	void Update () {
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
