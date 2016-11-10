using UnityEngine;
using System.Collections;

using Mages;
using Abilities;

public class RedMage : Mage {

    public RedMage() {

        maxHealth = 200;
        currentHealth = 0;
        healthRegenPerSecond = 2;

        maxMana = 200;
        currentMana = 0;
        manaRegenPerSecond = 5;

        moveSpeed = 10;

        abilityOne = new FireBall();
        abilityTwo = new FireRing();
        abilityThree = new FireBlink();

    } //End Constructor()
    

} //End RedMage class
