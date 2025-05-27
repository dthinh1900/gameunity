using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    public float m_speed=10;
    float huong;
    float m_jump = 300;
    bool m_cham =true;
    bool m_nhay=false;
    bool faceright = true;
    bool m_tancong;
    Rigidbody2D m_rg;
    public Animator anim;
    gamecontrolle m_gc;
    UIManager m_ui;
    AnimatorStateInfo stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        m_gc=FindAnyObjectByType<gamecontrolle>();
        m_ui = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // di chuyen
        huong = Input.GetAxisRaw("Horizontal");
        float buoc = huong * m_speed * Time.deltaTime;
        transform.position = transform.position + new Vector3(buoc, 0, 0);
        anim.SetFloat("dichuyen",Mathf.Abs(huong));
        //nhay
        bool m_space = Input.GetKeyDown(KeyCode.Space);
        if (m_space && m_cham)
        {
            m_rg.AddForce(Vector2.up * m_jump);
            m_space = false;
            m_nhay = true;
        }
        anim.SetBool("nhay", m_nhay);
        //tancong
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.J) && !stateInfo.IsName("Attack"))
        {
            m_tancong = true;
        }
        else
        {
            m_tancong = false;
        }
        anim.SetBool("tancong", m_tancong);









        //quay dau
        if(faceright==true&& huong == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            faceright = false;
        }
        else if(faceright==false&& huong == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceright = true;
        }
    }
    public void toadogoc()
    {

        anim.SetBool("gameover", false);
        transform.position = new Vector3(-9, -3, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bg"))
        {
            m_cham = true;
            m_nhay = false;
        }
        if (collision.gameObject.CompareTag("deathzone"))
        {
            anim.SetBool("gameover", true);
            m_gc.setGO(true);
            return;
        }
    }
    
}
