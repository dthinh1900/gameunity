using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityStandardAssets._2D;

public class gamecontrolle : MonoBehaviour
{
    Camera2D m_cmr;
    player m_pl;
    Vector3 toado = new Vector3(-9,-3,0);
    UIManager m_ui;
    bool gameover=false;
    Animator anim;
        // Start is called before the first frame update
    void Start()
    {
        m_pl = FindAnyObjectByType<player>();
        m_ui = FindAnyObjectByType<UIManager>();
        m_cmr = FindAnyObjectByType<Camera2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            m_ui.showgameoverpanel(true);
            return;
        }
       
    }
    public bool getGO()
    {
        return gameover;
    }
    public void setGO(bool value)
    {
        gameover = value;
    }
    
    public void replay()
    {
        gameover = false;
        m_ui.showgameoverpanel(false);
        m_pl.toadogoc();
    }
}
