using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Turn Card")]

public class TurnCard : Card {

    public float yDegree = 45;
    public override void use(Player player)
    {
        base.use(player);
        Vector3 turnVec = new Vector3(0, yDegree, 0);
        player.car.GetComponent<Car>().useTrun(turnVec);
    }
}
