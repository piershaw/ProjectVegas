using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    private GameObject player;
    public Button joyPad, joyButtonA, joyButtonB;
    public float turnSpeed = 0.5f;
    public float speedDampTime = 0.5f;
    private float turnSpeedLimet = 9.0f;
    private Vector3 lastDpadPosition;
    private float turn;
    private bool turnAround;
    private Animator anim;
    private int runHash, joggingHash, speedHash;
    private float joyDpadX, joyDpadY;
    private float speed;
    private float runspeed = 1f;
    private float offset = 20;
    private bool usingKeys, dPad;
    private int touchCountDpad;
    private Rect dpadRect;



    public void Awake()
    {
        usingKeys = false;
        dPad = true;
        runHash = Animator.StringToHash("Run");
        joggingHash = Animator.StringToHash("Jogging");
        speedHash = Animator.StringToHash("SetSpeed");
        dpadRect = new Rect();
        GameController.state = GameController.GameState.Game; // keep
    }


    public void Start()
    {

        if (PlayerPrefs.GetString("Player") == "Female")
        {
            player = Instantiate(Resources.Load("girl")) as GameObject;
        }
        else
        {
            player = Instantiate(Resources.Load("FuseModel")) as GameObject;
        }

        player.transform.parent = this.gameObject.transform;

        anim = player.GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);

        lastDpadPosition = joyPad.GetComponent<RectTransform>().transform.position;
        turn = 0;
    }


    public void FixedUpdate()
    {

        joyDpadX = joyPad.GetComponent<RectTransform>().transform.position.x;
        joyDpadY = joyPad.GetComponent<RectTransform>().transform.position.y;

        dpadRect.Set(joyPad.GetComponent<RectTransform>().transform.position.x, joyPad.GetComponent<RectTransform>().transform.position.y, joyPad.GetComponent<RectTransform>().rect.width, joyPad.GetComponent<RectTransform>().rect.height);

        int c = Input.touchCount;


        if (c > 0)
        {
            for (int i = 0; i < c; i++)
            {
                if (dpadRect.Contains(Input.GetTouch(i).position))
                {
                    //Debug.Log(i);
                    dPad = true;
                }
            }


            //i made this so the dpad hass limits for UI
            if (dPad)
            {
                Touch t = Input.GetTouch(touchCountDpad);
                joyPad.GetComponent<RectTransform>().transform.position = new Vector3(
                Mathf.Clamp(t.position.x, lastDpadPosition.x - offset, lastDpadPosition.x + offset),
                Mathf.Clamp(t.position.y, lastDpadPosition.y - offset, lastDpadPosition.y + offset),
                0);

                if (t.phase == TouchPhase.Canceled || t.phase == TouchPhase.Ended)
                    dPad = false;

                if (t.phase == TouchPhase.Canceled || t.phase == TouchPhase.Ended || t.phase == TouchPhase.Began)
                {
                    joyPad.GetComponent<RectTransform>().transform.position = lastDpadPosition;

                }
            }
        }


        if (Input.GetKey(KeyCode.D) || joyDpadX >= lastDpadPosition.x + 19)
        {
            turn += turnSpeed * Time.deltaTime;
            if (turn > turnSpeedLimet)
                turn = turnSpeedLimet;

            speed = runspeed * Time.deltaTime;
            anim.SetFloat(speedHash, runspeed, speedDampTime, Time.deltaTime);
            anim.SetBool(runHash, true);
        }
        else if (Input.GetKey(KeyCode.A) || joyDpadX <= (lastDpadPosition.x - 19) && joyDpadX != 0)
        {
            turn += -turnSpeed * Time.deltaTime;
            if (turn < -turnSpeedLimet)
                turn = -turnSpeedLimet;

            speed = runspeed * Time.deltaTime;
            anim.SetFloat(speedHash, runspeed, speedDampTime, Time.deltaTime);
            anim.SetBool(runHash, true);
        }
        else if (Input.GetKey(KeyCode.W) || joyDpadY > lastDpadPosition.y + 3)
        {
            turnAround = false;
            anim.SetFloat(speedHash, runspeed, speedDampTime, Time.deltaTime);
            speed = runspeed * Time.deltaTime;
            turn = 0;
            anim.SetBool(runHash, true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (turnAround != true)
            {
                // turnAround = true;
                //turn -= 180;
            }
            speed = -runspeed * Time.deltaTime;
            anim.SetFloat(speedHash, runspeed, speedDampTime, Time.deltaTime);
            anim.SetBool(runHash, true);
        }
        else
        {
            anim.SetFloat(speedHash, 0);
            anim.SetBool(runHash,false);
            speed = 0;
            turn = 0;

        }


        player.transform.Translate(0, 0, speed);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            usingKeys = true;

        if (joyDpadX != 0 || usingKeys)
            player.transform.Rotate(0, turn, 0);

    }


    public void joyPadA()
    {
     //
    }

    public void joyPadB()
    {
     //
    }


}
