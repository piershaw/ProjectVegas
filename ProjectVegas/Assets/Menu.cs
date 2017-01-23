using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

private GameObject game, menu, settings;

#if UNITY_STANDALONE
    public MovieTexture movie; // desktop
   
    public void Start () {
 
        Handheld.
        movie.loop = true;

        if (movie.isPlaying)
        {
            movie.Pause();
        }
        else
        {
            movie.Play();
        }
    }
#endif

    //from button
    //i do this for memory op
    public void GotoGame()
    {
        if (game == null)
        {
            game = Resources.Load("GamePlay") as GameObject;
            Instantiate(game);
            //get ref for later 
            game = GameObject.Find("GamePlay(Clone)");
        }
        
        menu = GameObject.Find("Menu(Clone)");
        Destroy(menu);

        game.SetActive(true);
    }

    public void GotoPickPlayer()
    {

        if (settings == null)
        {
            settings = Resources.Load("PickPlayer") as GameObject;
            Instantiate(settings);
            //get ref for later 
            settings = GameObject.Find("PickPlayer(Clone)");
        }

        menu = GameObject.Find("Menu(Clone)");
        Destroy(menu);

        settings.SetActive(true);
    }
}
