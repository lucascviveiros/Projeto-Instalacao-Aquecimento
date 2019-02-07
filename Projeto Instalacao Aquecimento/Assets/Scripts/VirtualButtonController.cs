using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VirtualButtonController : MonoBehaviour, IVirtualButtonEventHandler
{

    private Animator anim;
    private AnimatorClipInfo[] m_AnimatorClipInfo;
    public GameObject mObj_tampa;
    public GameObject mObj_tampa_base;
    public GameObject mObj_adaptador;
    public GameObject mObj_pino;
    public GameObject mObj_seta;
    public GameObject vNextButton;
   public GameObject vBackButton;
    // public TextMesh vText;

    public Text m_texto;
    int caseSwitch = 1;

    void Start()
    {

        mObj_seta.GetComponent<Renderer>().enabled = false;
        mObj_seta.SetActive(false);

        mObj_pino.GetComponent<Renderer>().enabled = false;
        mObj_pino.SetActive(false);

        mObj_tampa_base.GetComponent<Renderer>().enabled = true;
        mObj_tampa_base.SetActive(true);

        mObj_adaptador.GetComponent<Renderer>().enabled = false;
        mObj_adaptador.SetActive(false);

        m_texto.text = "Retire a tampa";
        anim = this.GetComponent<Animator>();


        //vNextButton = GameObject.Find("vbNext");
        vNextButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vBackButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        m_AnimatorClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log("Starting clip : " + m_AnimatorClipInfo[0].clip);
        
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
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

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "vbNext":
                switch (caseSwitch)
                {
                    case 1:
                        m_texto.text = "Retire o Pino";

                        mObj_pino.GetComponent<Renderer>().enabled = true;
                        mObj_pino.SetActive(true);

                        mObj_seta.GetComponent<Renderer>().enabled = true;
                        mObj_seta.SetActive(true);

                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;

                        mObj_adaptador.SetActive(false);
                        mObj_adaptador.GetComponent<Renderer>().enabled = false;

                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;
                        caseSwitch++;
                        break;
                    case 2:
                        m_texto.text = "Rotacione para esquerda";

                        mObj_pino.GetComponent<Renderer>().enabled = false;
                        mObj_pino.SetActive(false);

                        mObj_seta.GetComponent<Renderer>().enabled = false;
                        mObj_seta.SetActive(false);

                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;

                        mObj_adaptador.SetActive(false);
                        mObj_adaptador.GetComponent<Renderer>().enabled = false;

                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;

                        GetComponent<Animator>().Play("animation_2_tampa");
                        caseSwitch++;
                        break;
                    case 3:
                        m_texto.text = "Retire";
                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;
                        GetComponent<Animator>().Play("animation_3_tampa");
                        caseSwitch++;
                        break;
                    case 4:
                        m_texto.text = "Pronto";
                        mObj_tampa_base.SetActive(false);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = false;

                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;
                        break;
                }
            break;

            case "vbBack":
                switch (caseSwitch)
                {
                    case 1:
                        m_texto.text = "Retire a tampa";
                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;

                        mObj_pino.GetComponent<Renderer>().enabled = false;
                        mObj_pino.SetActive(false);

                        mObj_tampa.SetActive(true);
                        mObj_tampa.GetComponent<Renderer>().enabled = true;

                        mObj_seta.GetComponent<Renderer>().enabled = false;
                        mObj_seta.SetActive(false);
                        anim.enabled = true;
                        GetComponent<Animator>().Play("animation_1_tampa");
                        break;

                    case 2:
                        m_texto.text = "Retire o Pino";

                        mObj_pino.GetComponent<Renderer>().enabled = true;
                        mObj_pino.SetActive(true);

                        mObj_seta.GetComponent<Renderer>().enabled = true;
                        mObj_seta.SetActive(true);

                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;

                        mObj_adaptador.SetActive(false);
                        mObj_adaptador.GetComponent<Renderer>().enabled = false;

                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;
                        //                        mObj_tampa_base.GetComponent<Animation>().enabled = false;
                        anim.enabled = false;


                        caseSwitch--;
                        break;
                    case 3:
                        m_texto.text = "Rotacione para esquerda";

                        mObj_pino.GetComponent<Renderer>().enabled = false;
                        mObj_pino.SetActive(false);

                        mObj_seta.GetComponent<Renderer>().enabled = false;
                        mObj_seta.SetActive(false);

                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;

                        mObj_adaptador.SetActive(false);
                        mObj_adaptador.GetComponent<Renderer>().enabled = false;

                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;

                        GetComponent<Animator>().Play("animation_2_tampa");
                        caseSwitch--;
                        break;
                    case 4:
                        m_texto.text = "Retire";
                        mObj_tampa.SetActive(false);
                        mObj_tampa.GetComponent<Renderer>().enabled = false;
                        mObj_tampa_base.SetActive(true);
                        mObj_tampa_base.GetComponent<Renderer>().enabled = true;
                        GetComponent<Animator>().Play("animation_3_tampa");
                        caseSwitch--;
                        break;
                }
            break;
        }
        

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
    }
}


