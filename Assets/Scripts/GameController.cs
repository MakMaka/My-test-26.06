using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject panel_win;
    [SerializeField] TextMeshProUGUI myText;

    private void Start()
    {
        GlobalVariables.isEnd = false;
    }

    private void Update()
    {
        if (!GlobalVariables.isEnd & GameObject.FindGameObjectsWithTag("endP").Length == 0)
        {
            panel_win.SetActive(true);
            myText.text = "Mistakes made: " + GlobalVariables.myVariable;
            GlobalVariables.isEnd = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("HostScene");
        }
    }
}
