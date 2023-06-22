using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public gameController gameCont;
    // Start is called before the first frame update
    public int rodNumber;
    public void OnButtonPress(){
        gameCont.HandleClick(rodNumber);
    }
    
    public void OnButtonPressAutosolve(){
        gameCont.Autosolve();
    }

}
