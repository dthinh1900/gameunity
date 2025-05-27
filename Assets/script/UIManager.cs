using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
    public GameObject gameoverpanel;
        public void showgameoverpanel(bool isshow)
    {
        if (gameoverpanel)
        {
            gameoverpanel.SetActive(isshow);
        }
    }
}
