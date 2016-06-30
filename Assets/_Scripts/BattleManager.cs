using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Mages;
using Abilities;

public class BattleManager : MonoBehaviour {

    public Mage player;

    public GameObject[] allMages;
    public List<Mage> mageList = new List<Mage>();

    void Start () {

        Debug.Log("yo");

        PopulateMageList();

        foreach(Mage mage in mageList) {
            mage.BattleStart();
        }

        player = mageList[0];


    } //End Start()
	
	
	void Update () {

        foreach (Mage mage in mageList) {
            if ((mage.isCharging) && (mage.currentAbility.CheckCharge())) {
                mage.currentAbility.AbilityMap();
            }
        }

        CheckForInput();

    } //End Update()


    void CheckForInput() {

        Ability abilityToApply = null;

        if ((Input.GetMouseButtonDown(0)) && (IsAbilityUsable(player, player.abilityOne))) {
            abilityToApply = player.abilityOne;
        }

        else if ((Input.GetMouseButtonDown(1)) && (IsAbilityUsable(player, player.abilityOne))) {
            abilityToApply = player.abilityTwo;
        }

        else if ((Input.GetKeyDown(KeyCode.LeftShift)) && (IsAbilityUsable(player, player.abilityOne))) {
            abilityToApply = player.abilityTwo;
        }

        if (abilityToApply != null) {

            player.currentAbility = abilityToApply;

            if (abilityToApply.instantCast) {
                abilityToApply.AbilityMap();
            }
            else {
                abilityToApply.InitCharge();
            }
        }

    } //End CheckForInput()


    private bool IsAbilityUsable (Mage player, Ability ability) {

        if ((ability.cooldownEndTimer < Time.time) && (ability.manaCost < player.currentMana)) {
            return true;
        }
        else {
            return false;
        }

    } //End IsAbilityUsable(2)




    //Initializing functions

    void PopulateMageList () {

        allMages = GameObject.FindGameObjectsWithTag("Mage");
        foreach (GameObject mageObject in allMages) {
            if (mageObject.activeInHierarchy) {
                mageList.Add(mageObject.GetComponent<Mage>());
            } //End if active in hierarchy
        } //End foreach
        
    } //End PopulateMageList()

} //End BattleManager class
