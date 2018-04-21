using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Gas Card")]
public class GasCard : Card {

    public override void use(Player Player)
    {
        Car car = Player.car.GetComponent<Car>();
        base.use(Player);
        car.useGas();
    }
}
