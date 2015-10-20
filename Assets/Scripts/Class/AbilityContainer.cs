using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityContainer {

	public List<AbilitySystem> LTrigger;
	public List<AbilitySystem> RTrigger;
	public List<AbilitySystem> LBumper;
	public List<AbilitySystem> RBumper;

	public List<AbilitySystem> AButton;
	public List<AbilitySystem> BButton;
	public List<AbilitySystem> XButton;
	public List<AbilitySystem> YButton;

	public void StoreAbility(AbilitySystem ability){
		switch(ability._linkedButton){
			//
		}
	}

}
