using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public static Soundtrack instance;
    // Start is called before the first frame update
    
    private void Awake(){

        DontDestroyOnLoad(this.gameObject);

        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
        }
    }
}
