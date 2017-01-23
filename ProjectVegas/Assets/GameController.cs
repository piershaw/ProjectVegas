using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject game,menu,settings;
    public enum GameState
    {
        Menu,
        Game,
        Pause
    };

    public static GameState state;


    public void Awake () {
        menu = Resources.Load("Menu") as GameObject;
        Instantiate(menu);
        state = GameState.Menu;
        menu = GameObject.Find("Menu(Clone)");
       
    }


    public void Update(){

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return)) {
            Debug.Log("click");
     
         
          

            if (state == GameState.Menu) {
                Application.Quit();
              
            }
            else if (state == GameState.Game)
            {
                menu = Resources.Load("Menu") as GameObject;
                Instantiate(menu);
                menu = GameObject.Find("Menu(Clone)");
                game = GameObject.Find("GamePlay(Clone)");
                Destroy(game);
              
                state = GameState.Menu;
            }
        }
        
    }

    
}
