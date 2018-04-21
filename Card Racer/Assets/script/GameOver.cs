using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text text;
    public Button button;


    private void OnTriggerEnter(Collider other)
    {
        Player player=    other.GetComponentInParent<Player>();

        if(player != null)
        {
            if (player.isPc)
            {
                text.text = "You Lost";
            }
            else
            {
                text.text = "You Win";
            }
            text.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(0);
    }


}
