using UnityEngine;
using System.Collections;

public class PickPlayer : MonoBehaviour {

    private GameObject game, menu, settings;

    public void Start()
    {
        game = Resources.Load("GamePlay") as GameObject;
    }

    public void pickPlayerOptionMale()
    {
        Debug.Log("boy");
        PlayerPrefs.SetString("Player", "Male");
        settings = GameObject.Find("PickPlayer(Clone)");
         Instantiate(game);
         Destroy(settings);
    }

    public void pickPlayerOptionFemale()
    {
        Debug.Log("girl");
        PlayerPrefs.SetString("Player", "Female");
        settings = GameObject.Find("PickPlayer(Clone)");
            Instantiate(game);
            Destroy(settings);
    }

}
