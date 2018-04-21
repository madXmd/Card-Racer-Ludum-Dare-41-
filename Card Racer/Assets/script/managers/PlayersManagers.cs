using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManagers : MonoBehaviour {
    public static PlayersManagers instance { get; private set; }

    public List<Player> players;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

}
