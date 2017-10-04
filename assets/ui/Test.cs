using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Health health;

	void OnGUI () {
		if(GUI.Button(new Rect(Screen.width/1.5f,Screen.height / 4 + Screen.width / 10 * 0,100,25),"Add Heart")){
            health.AddHearts(1);
        }
        if (GUI.Button (new Rect(Screen.width / 1.5f, Screen.height / 4 + Screen.width / 10 * 1, 100, 25), "Take Damage")){
            health.ModifyHealth(-1);
        }
        if (GUI.Button (new Rect(Screen.width / 1.5f, Screen.height / 4 + Screen.width / 10 * 2, 100, 25), "Heal")){
            health.ModifyHealth(1);
        }
    }

}
