using UnityEngine;
using System.Collections;

using Abilities;

public class FireBlink : Ability {

    public FireBlink() {

        abilityType = AbilityType.Mobility;

        instantCast = true;

        cooldownDuration = 5;

        manaCost = 30;
        mobilityDistance = 5;



    } //End Constructor ()


    public override void AbilityMap() {
        ActivateBlink(abilityOwner.transform);
        ExitAbility();
    }


} //End FireRing class
