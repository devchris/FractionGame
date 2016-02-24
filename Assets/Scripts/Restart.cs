using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
